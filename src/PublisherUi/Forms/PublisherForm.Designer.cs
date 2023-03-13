namespace PublisherUi
{
	partial class PublisherForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txMessage = new System.Windows.Forms.TextBox();
			this.grpSubscriber = new System.Windows.Forms.GroupBox();
			this.cbSubscriber = new System.Windows.Forms.ComboBox();
			this.btPublish = new System.Windows.Forms.Button();
			this.grpChat = new System.Windows.Forms.GroupBox();
			this.txChatHistory = new System.Windows.Forms.TextBox();
			this.grpBottom = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.grpSubscriber.SuspendLayout();
			this.grpChat.SuspendLayout();
			this.grpBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txMessage);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new System.Drawing.Point(3, 22);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
			this.groupBox1.Size = new System.Drawing.Size(832, 102);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Send Message";
			// 
			// txMessage
			// 
			this.txMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txMessage.Location = new System.Drawing.Point(10, 29);
			this.txMessage.Multiline = true;
			this.txMessage.Name = "txMessage";
			this.txMessage.Size = new System.Drawing.Size(812, 63);
			this.txMessage.TabIndex = 1;
			// 
			// grpSubscriber
			// 
			this.grpSubscriber.Controls.Add(this.cbSubscriber);
			this.grpSubscriber.Controls.Add(this.btPublish);
			this.grpSubscriber.Dock = System.Windows.Forms.DockStyle.Right;
			this.grpSubscriber.Location = new System.Drawing.Point(902, 22);
			this.grpSubscriber.Name = "grpSubscriber";
			this.grpSubscriber.Size = new System.Drawing.Size(256, 102);
			this.grpSubscriber.TabIndex = 3;
			this.grpSubscriber.TabStop = false;
			this.grpSubscriber.Text = "Subscriber";
			// 
			// cbSubscriber
			// 
			this.cbSubscriber.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbSubscriber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSubscriber.FormattingEnabled = true;
			this.cbSubscriber.Location = new System.Drawing.Point(3, 22);
			this.cbSubscriber.Name = "cbSubscriber";
			this.cbSubscriber.Size = new System.Drawing.Size(157, 28);
			this.cbSubscriber.TabIndex = 1;
			// 
			// btPublish
			// 
			this.btPublish.Dock = System.Windows.Forms.DockStyle.Right;
			this.btPublish.Location = new System.Drawing.Point(160, 22);
			this.btPublish.Name = "btPublish";
			this.btPublish.Size = new System.Drawing.Size(93, 77);
			this.btPublish.TabIndex = 2;
			this.btPublish.Text = "Publish";
			this.btPublish.UseVisualStyleBackColor = true;
			this.btPublish.Click += new System.EventHandler(this.buttons_Click);
			// 
			// grpChat
			// 
			this.grpChat.Controls.Add(this.txChatHistory);
			this.grpChat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpChat.Location = new System.Drawing.Point(0, 0);
			this.grpChat.Name = "grpChat";
			this.grpChat.Padding = new System.Windows.Forms.Padding(10);
			this.grpChat.Size = new System.Drawing.Size(1161, 613);
			this.grpChat.TabIndex = 1;
			this.grpChat.TabStop = false;
			this.grpChat.Text = "Chats";
			// 
			// txChatHistory
			// 
			this.txChatHistory.BackColor = System.Drawing.Color.GhostWhite;
			this.txChatHistory.Dock = System.Windows.Forms.DockStyle.Top;
			this.txChatHistory.Location = new System.Drawing.Point(10, 29);
			this.txChatHistory.Multiline = true;
			this.txChatHistory.Name = "txChatHistory";
			this.txChatHistory.ReadOnly = true;
			this.txChatHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txChatHistory.Size = new System.Drawing.Size(1141, 451);
			this.txChatHistory.TabIndex = 0;
			// 
			// grpBottom
			// 
			this.grpBottom.Controls.Add(this.groupBox1);
			this.grpBottom.Controls.Add(this.grpSubscriber);
			this.grpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpBottom.Location = new System.Drawing.Point(0, 486);
			this.grpBottom.Name = "grpBottom";
			this.grpBottom.Size = new System.Drawing.Size(1161, 127);
			this.grpBottom.TabIndex = 4;
			this.grpBottom.TabStop = false;
			// 
			// PublisherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.ClientSize = new System.Drawing.Size(1161, 613);
			this.Controls.Add(this.grpBottom);
			this.Controls.Add(this.grpChat);
			this.Name = "PublisherForm";
			this.Text = "Publisher Form";
			this.Load += new System.EventHandler(this.PublisherForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.grpSubscriber.ResumeLayout(false);
			this.grpChat.ResumeLayout(false);
			this.grpChat.PerformLayout();
			this.grpBottom.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox grpChat;
		private System.Windows.Forms.TextBox txMessage;
		private System.Windows.Forms.Button btPublish;
		private System.Windows.Forms.ComboBox cbSubscriber;
		private System.Windows.Forms.GroupBox grpSubscriber;
		private System.Windows.Forms.TextBox txChatHistory;
		private System.Windows.Forms.GroupBox grpBottom;
	}
}

