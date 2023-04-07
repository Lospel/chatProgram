using System;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MultiChatClient {

    delegate void SetTextDelegate(string s);

    public partial class ChatForm : Form {

        public ChatForm() {
            InitializeComponent();
        }
        TcpClient tcpClient = null;
        NetworkStream ntwStream = null;
        ChatHandler chatHandler = new ChatHandler();
        

        void OnConnectToServer(object sender, EventArgs e) {

            if (btnConnect.Text == "연결")
            {
                try
                {
                    tcpClient = new TcpClient();
                    tcpClient.Connect(System.Net.IPAddress.Parse(txtAddress.Text),int.Parse(txtPort.Text));
                    ntwStream = tcpClient.GetStream();

                    chatHandler.Setup(this, ntwStream, this.txtHistory);
                    Thread chatThread = new Thread(new ThreadStart(chatHandler.ChatProcess));
                    chatThread.Start();

                    Message_Snd("<" + tb_ClientName.Text + "> 님께서 접속하셨습니다.", true);

                    btnConnect.Text = "나가기";
                    lb_Connect.Text = "연결중";

                }
                catch (System.Exception Err)
                {
                    MessageBox.Show("Server 오류 발생 또는 Start 되지 않았음\n\n" + Err.Message, "Client");
                }
            }
            else
            {
                Message_Snd("<" + tb_ClientName.Text + "> 님께서 접속을 종료하셨습니다.", false);
                btnConnect.Text = "연결";
                lb_Connect.Text = "연결 대기중";
                chatHandler.ChatClose();
                ntwStream.Close();
                tcpClient.Close();
            }
        }


        private void Message_Snd(string lstMessage, Boolean Msg)
        {
            try
            {
                string dataToSend = lstMessage + "\r\n";
                byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                ntwStream.Write(data, 0, data.Length);

            }
            catch (Exception Ex)
            {
                if (Msg == true)
                {
                    MessageBox.Show("서버가 Start되지 않았거나\n\n" + Ex.Message, "Client");
                    btnConnect.Text = "입장";
                    chatHandler.ChatClose();
                    ntwStream.Close();
                    tcpClient.Close();
                }
            }
        }

        public void SetText(string text)
        {
            if (this.txtHistory.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtHistory.AppendText(text);
            }
        }

        public class ChatHandler
        {
            private TextBox txtChatMsg;
            private NetworkStream netStream;
            private StreamReader strReader;
            private ChatForm form1;

            public void Setup(ChatForm form1, NetworkStream netStream, TextBox txtChatMsg)
            {
                this.txtChatMsg = txtChatMsg;
                this.netStream = netStream;
                this.form1 = form1;
                this.netStream = netStream;
                this.strReader = new StreamReader(netStream);
            }

            public void ChatClose()
            {
                netStream.Close();
                strReader.Close();
            }

            public void ChatProcess()
            {

                while (true)
                {
                    try
                    {
                        string lstMessage = strReader.ReadLine();
                
                        if (lstMessage != null && lstMessage != "")
                        {
                            form1.SetText(lstMessage + "\r\n");
                        }
                    }
                    catch (System.Exception)
                    {
                        break;
                    }
                
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Message_Snd("<" + tb_ClientName.Text + ">" + txtTTS.Text, true);
            txtTTS.Text = "";
        }

    }
}