namespace MultiChatServer {
    partial class ChatForm {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tblMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.layout_right_connInfo = new System.Windows.Forms.TableLayoutPanel();
            this.ConnectedTree = new System.Windows.Forms.TreeView();
            this.ReadyTree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tblMainLayout.SuspendLayout();
            this.layout_right_connInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPort
            // 
            this.txtPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPort.Location = new System.Drawing.Point(523, 10);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 2, 3, 3);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(67, 27);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "15000";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPort.Location = new System.Drawing.Point(419, 9);
            this.lblPort.Margin = new System.Windows.Forms.Padding(1);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(99, 30);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "포트 번호";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(594, 9);
            this.btnStart.Margin = new System.Windows.Forms.Padding(1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(97, 30);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BeginStartServer);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(232, 10);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 2, 3, 3);
            this.txtAddress.MaxLength = 260;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(183, 27);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "127.0.0.1";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Location = new System.Drawing.Point(109, 9);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(1);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(118, 30);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "서버 주소";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblMainLayout
            // 
            this.tblMainLayout.ColumnCount = 6;
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tblMainLayout.Controls.Add(this.lblAddress, 1, 0);
            this.tblMainLayout.Controls.Add(this.txtAddress, 2, 0);
            this.tblMainLayout.Controls.Add(this.btnStart, 5, 0);
            this.tblMainLayout.Controls.Add(this.lblPort, 3, 0);
            this.tblMainLayout.Controls.Add(this.txtPort, 4, 0);
            this.tblMainLayout.Controls.Add(this.txtHistory, 0, 1);
            this.tblMainLayout.Controls.Add(this.lblMsg, 0, 0);
            this.tblMainLayout.Controls.Add(this.layout_right_connInfo, 4, 1);
            this.tblMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainLayout.Location = new System.Drawing.Point(0, 0);
            this.tblMainLayout.Name = "tblMainLayout";
            this.tblMainLayout.Padding = new System.Windows.Forms.Padding(8);
            this.tblMainLayout.RowCount = 2;
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMainLayout.Size = new System.Drawing.Size(700, 493);
            this.tblMainLayout.TabIndex = 1;
            // 
            // txtHistory
            // 
            this.tblMainLayout.SetColumnSpan(this.txtHistory, 4);
            this.txtHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHistory.Location = new System.Drawing.Point(11, 43);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ReadOnly = true;
            this.txtHistory.Size = new System.Drawing.Size(505, 439);
            this.txtHistory.TabIndex = 10;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMsg.Location = new System.Drawing.Point(11, 8);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(94, 32);
            this.lblMsg.TabIndex = 12;
            this.lblMsg.Tag = "Stop";
            this.lblMsg.Text = "서버 중지됨";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layout_right_connInfo
            // 
            this.layout_right_connInfo.ColumnCount = 1;
            this.tblMainLayout.SetColumnSpan(this.layout_right_connInfo, 2);
            this.layout_right_connInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout_right_connInfo.Controls.Add(this.ConnectedTree, 0, 3);
            this.layout_right_connInfo.Controls.Add(this.ReadyTree, 0, 1);
            this.layout_right_connInfo.Controls.Add(this.label1, 0, 0);
            this.layout_right_connInfo.Controls.Add(this.label2, 0, 2);
            this.layout_right_connInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_right_connInfo.Location = new System.Drawing.Point(522, 43);
            this.layout_right_connInfo.Name = "layout_right_connInfo";
            this.layout_right_connInfo.RowCount = 4;
            this.layout_right_connInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layout_right_connInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layout_right_connInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layout_right_connInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layout_right_connInfo.Size = new System.Drawing.Size(167, 439);
            this.layout_right_connInfo.TabIndex = 14;
            // 
            // ConnectedTree
            // 
            this.ConnectedTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectedTree.Location = new System.Drawing.Point(3, 264);
            this.ConnectedTree.Name = "ConnectedTree";
            this.ConnectedTree.Size = new System.Drawing.Size(161, 172);
            this.ConnectedTree.TabIndex = 13;
            // 
            // ReadyTree
            // 
            this.ReadyTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReadyTree.Location = new System.Drawing.Point(3, 46);
            this.ReadyTree.Name = "ReadyTree";
            this.ReadyTree.Size = new System.Drawing.Size(161, 169);
            this.ReadyTree.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 43);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ready";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 43);
            this.label2.TabIndex = 16;
            this.label2.Text = "Connected";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChatForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(700, 493);
            this.Controls.Add(this.tblMainLayout);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.Name = "ChatForm";
            this.Text = "서버";
            this.tblMainLayout.ResumeLayout(false);
            this.tblMainLayout.PerformLayout();
            this.layout_right_connInfo.ResumeLayout(false);
            this.layout_right_connInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tblMainLayout;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TreeView ConnectedTree;
        private System.Windows.Forms.TableLayoutPanel layout_right_connInfo;
        private System.Windows.Forms.TreeView ReadyTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

