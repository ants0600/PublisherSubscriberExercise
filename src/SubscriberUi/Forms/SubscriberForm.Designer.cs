namespace SubscriberUi
{
	partial class SubscriberForm
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
			this.grpData = new System.Windows.Forms.GroupBox();
			this.btUnsubscribe = new System.Windows.Forms.Button();
			this.btSubscribe = new System.Windows.Forms.Button();
			this.txSubscriberName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.grpChats = new System.Windows.Forms.GroupBox();
			this.txChatHistory = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btSendMessage = new System.Windows.Forms.Button();
			this.txMessage = new System.Windows.Forms.TextBox();
			this.grpData.SuspendLayout();
			this.grpChats.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpData
			// 
			this.grpData.Controls.Add(this.btUnsubscribe);
			this.grpData.Controls.Add(this.btSubscribe);
			this.grpData.Controls.Add(this.txSubscriberName);
			this.grpData.Controls.Add(this.label1);
			this.grpData.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpData.Location = new System.Drawing.Point(0, 0);
			this.grpData.Name = "grpData";
			this.grpData.Size = new System.Drawing.Size(800, 58);
			this.grpData.TabIndex = 0;
			this.grpData.TabStop = false;
			this.grpData.Text = "Subscriber Data";
			// 
			// btUnsubscribe
			// 
			this.btUnsubscribe.Dock = System.Windows.Forms.DockStyle.Left;
			this.btUnsubscribe.Location = new System.Drawing.Point(598, 22);
			this.btUnsubscribe.Name = "btUnsubscribe";
			this.btUnsubscribe.Size = new System.Drawing.Size(133, 33);
			this.btUnsubscribe.TabIndex = 3;
			this.btUnsubscribe.Text = "Unsubscribe";
			this.btUnsubscribe.UseVisualStyleBackColor = true;
			this.btUnsubscribe.Click += new System.EventHandler(this.buttons_Click);
			// 
			// btSubscribe
			// 
			this.btSubscribe.Dock = System.Windows.Forms.DockStyle.Left;
			this.btSubscribe.Location = new System.Drawing.Point(476, 22);
			this.btSubscribe.Name = "btSubscribe";
			this.btSubscribe.Size = new System.Drawing.Size(122, 33);
			this.btSubscribe.TabIndex = 2;
			this.btSubscribe.Text = "Subscribe";
			this.btSubscribe.UseVisualStyleBackColor = true;
			this.btSubscribe.Click += new System.EventHandler(this.buttons_Click);
			// 
			// txSubscriberName
			// 
			this.txSubscriberName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txSubscriberName.Location = new System.Drawing.Point(116, 22);
			this.txSubscriberName.Name = "txSubscriberName";
			this.txSubscriberName.Size = new System.Drawing.Size(360, 26);
			this.txSubscriberName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(3, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 22);
			this.label1.TabIndex = 0;
			this.label1.Text = "Subscribe as *";
			// 
			// grpChats
			// 
			this.grpChats.Controls.Add(this.txChatHistory);
			this.grpChats.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpChats.Location = new System.Drawing.Point(0, 58);
			this.grpChats.Name = "grpChats";
			this.grpChats.Size = new System.Drawing.Size(800, 392);
			this.grpChats.TabIndex = 1;
			this.grpChats.TabStop = false;
			this.grpChats.Text = "Chats";
			// 
			// txChatHistory
			// 
			this.txChatHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txChatHistory.Location = new System.Drawing.Point(3, 22);
			this.txChatHistory.Multiline = true;
			this.txChatHistory.Name = "txChatHistory";
			this.txChatHistory.ReadOnly = true;
			this.txChatHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txChatHistory.Size = new System.Drawing.Size(794, 367);
			this.txChatHistory.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btSendMessage);
			this.groupBox1.Controls.Add(this.txMessage);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 370);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(800, 80);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Message";
			// 
			// btSendMessage
			// 
			this.btSendMessage.Dock = System.Windows.Forms.DockStyle.Right;
			this.btSendMessage.Location = new System.Drawing.Point(722, 22);
			this.btSendMessage.Name = "btSendMessage";
			this.btSendMessage.Size = new System.Drawing.Size(75, 55);
			this.btSendMessage.TabIndex = 1;
			this.btSendMessage.Text = "Send";
			this.btSendMessage.UseVisualStyleBackColor = true;
			this.btSendMessage.Click += new System.EventHandler(this.buttons_Click);
			// 
			// txMessage
			// 
			this.txMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txMessage.Location = new System.Drawing.Point(3, 22);
			this.txMessage.Multiline = true;
			this.txMessage.Name = "txMessage";
			this.txMessage.Size = new System.Drawing.Size(794, 55);
			this.txMessage.TabIndex = 0;
			// 
			// SubscriberForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpChats);
			this.Controls.Add(this.grpData);
			this.Name = "SubscriberForm";
			this.Text = "Subscriber";
			this.Load += new System.EventHandler(this.SubscriberForm_Load);
			this.grpData.ResumeLayout(false);
			this.grpData.PerformLayout();
			this.grpChats.ResumeLayout(false);
			this.grpChats.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpData;
		private System.Windows.Forms.Button btSubscribe;
		private System.Windows.Forms.TextBox txSubscriberName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpChats;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btSendMessage;
		private System.Windows.Forms.TextBox txMessage;
		private System.Windows.Forms.Button btUnsubscribe;
		private System.Windows.Forms.TextBox txChatHistory;
	}
}

