using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using static MultiChatServer.ChatForm;

namespace MultiChatServer {

    public delegate void Connect(ChatForm.ClientHandler handle);

    public delegate void Connected(ChatForm.ClientHandler handle);

    public delegate void Disconnected(ChatForm.ClientHandler handle);

    public delegate void RecvMessage(ChatForm.ClientHandler handle, string msg);



    public partial class ChatForm : Form {

        private TcpListener chatServer = null;
        
        private List<ClientHandler> connectionList = new List<ClientHandler>(100);
        private List<ClientHandler> readyList = new List<ClientHandler>(100);
        private List<ClientHandler> connectedList = new List<ClientHandler>(100);

        private static ArrayList clientSocketArray = new ArrayList();
        public ChatForm() {
            InitializeComponent();
            chatServer = new TcpListener(IPAddress.Any, int.Parse(txtPort.Text));
        }

        void BeginStartServer(object sender, EventArgs e) {
            try
            {
                if (lblMsg.Tag.ToString() == "Stop")
                {
                    chatServer.Start();
                    Thread waitThread = new Thread(new ThreadStart(AcceptClient));
                    waitThread.Start();

                    lblMsg.Text = "서버 시작됨";
                    lblMsg.Tag = "Start";
                    btnStart.Text = "종료";
                }
                else
                {
                    chatServer.Stop();
                    connectionList.Clear();

                    lblMsg.Text = "서버 중지됨";
                    lblMsg.Tag = "Stop";
                    btnStart.Text = "시작";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 : " + ex.Message);
            }
        }
        private void AcceptClient()
        {
            Socket socketClient = null;
            while (true)
            {
                try
                {
                    socketClient = chatServer.AcceptSocket();
                    ClientHandler clientHandler = new ClientHandler(socketClient);
                    clientHandler.connectEventHandler += ConnectTreeAdd;
                    clientHandler.connectedEventHandler += ConnectedTreeAdd;
                    clientHandler.receiveMessageHandler += RecvMessage;
                    clientHandler.disconnectedHandler += Disconnected;

                    clientHandler.Initialize();
                    connectionList.Add(clientHandler);

                    clientHandler.Startup();
                }
                catch (System.Exception e)
                {
                    clientSocketArray.Remove(socketClient);
                    break;
                }
            }
        }

        public void ConnectTreeAdd(ChatForm.ClientHandler handle)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker) delegate { ConnectTreeAdd(handle); });
            }
            else
            {
                TreeNode root = null;
                if (ReadyTree.Nodes.Count == 0)
                {
                    root = new TreeNode("Ready Tree");
                    ReadyTree.Nodes.Add(root);
                }
                else
                    root = ReadyTree.Nodes[0];

                root.Nodes.Add(new TreeNode(handle.Id));
                readyList.Add(handle);
            }
        }

        public void ConnectTreeDelete(ChatForm.ClientHandler handle)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { ConnectTreeDelete(handle); });
            }
            else
            {
                TreeNode root = null;
                if (ReadyTree.Nodes.Count == 0)
                {
                    root = new TreeNode("Ready Tree");
                    ReadyTree.Nodes.Add(root);
                }
                else
                    root = ReadyTree.Nodes[0];

                foreach (TreeNode childNode in root.Nodes)
                {
                    if (childNode.Text == handle.Id)
                    {
                        root.Nodes.Remove(childNode);
                        readyList.Remove(handle);
                        break;
                    }

                }
            }
        }

        public void ConnectedTreeAdd(ChatForm.ClientHandler handle)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { ConnectedTreeAdd(handle); });
            }
            else
            {
                TreeNode root = null;
                if (ConnectedTree.Nodes.Count == 0)
                {
                    root = new TreeNode("Connected Tree");
                    ConnectedTree.Nodes.Add(root);
                }
                else
                    root = ConnectedTree.Nodes[0];

                root.Nodes.Add(new TreeNode(handle.NickName));
                connectedList.Add(handle);
                ConnectTreeDelete(handle);
            }
        }

        public void RecvMessage(ChatForm.ClientHandler handle, string msg)
        {

            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { RecvMessage(handle, msg);});
            else
            {
                if (msg != null && msg.Length >0)
                {
                    txtHistory.AppendText(msg);
                }
                
            }
            
        }

        public void Disconnected(ChatForm.ClientHandler handle)
        {
            TreeNode root = null;

            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate {  Disconnected(handle);});
            else
            {
                if (ConnectedTree.Nodes.Count == 0)
                {
                    ConnectedTree.Nodes.Clear();
                }
                else
                    root = ConnectedTree.Nodes[0];

                foreach (TreeNode childNode in root.Nodes)
                {
                    if (childNode.Text == handle.Id)
                    {
                        root.Nodes.Remove(childNode);
                        connectedList.Remove(handle);
                        break;
                    }

                }
            }
        }


        public class ClientHandler
        {
            public event Connect connectEventHandler;
            public event Connected connectedEventHandler;
            public event RecvMessage receiveMessageHandler;
            public event Disconnected disconnectedHandler;

            private Socket _client;
            private NetworkStream netStream;
            private StreamReader strReader;

            private string _id;
            private string _nickName;

            private bool recvLoop = false;
            private Thread recvThrd = null;

            public string Id => _id;

            public string NickName => _nickName;


            public ClientHandler(Socket client)
            {
                _client = client;
            }

            public void Initialize()
            {
                this.netStream = new NetworkStream(_client);
                this.strReader = new StreamReader(netStream);

                this._id = _client.RemoteEndPoint.ToString();

                ChatForm.clientSocketArray.Add(_client);
            }

            public void Startup()
            {
                recvThrd = new Thread(onRecvLoop)
                {
                    IsBackground = true
                };

                recvLoop = true;
                recvThrd.Start();
                
                connectEventHandler.Invoke(this);
            }

            public void onRecvLoop()
            {
                // 나중에 stx checksum etx 프로토콜로 해당 유저명을 가져와서 대입.
                _nickName = _id;

                Thread.Sleep(3000);
                connectedEventHandler.Invoke(this);

                while (recvLoop)
                {
                    try
                    {
                        string lstMessage = strReader.ReadLine();
                        if (lstMessage != null && lstMessage.Length > 0)
                        {
                            receiveMessageHandler.Invoke(this, lstMessage + "\r\n");
                            byte[] bySend_Data = Encoding.UTF8.GetBytes(lstMessage + "\r\n");
                            lock (clientSocketArray)
                            {
                                foreach(Socket socket in clientSocketArray)
                                {
                                    NetworkStream stream = new NetworkStream(socket);
                                    stream.Write(bySend_Data,0, bySend_Data.Length);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"클라이언트와 접속이 종료되었습니다.");
                        disconnectedHandler.Invoke(this);
                        clientSocketArray.Remove(_client);
                        break;
                    }
                }
            }
        }
    }
}