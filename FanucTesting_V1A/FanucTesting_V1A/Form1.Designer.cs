namespace FanucTesting_V1A
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IPAddress = new TextBox();
            btnConnect = new Button();
            SuspendLayout();
            // 
            // IPAddress
            // 
            IPAddress.Location = new Point(320, 175);
            IPAddress.Name = "IPAddress";
            IPAddress.Size = new Size(100, 27);
            IPAddress.TabIndex = 0;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(307, 208);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(113, 42);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "CONNECT";
            btnConnect.Click += btnConnect_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConnect);
            Controls.Add(IPAddress);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox IPAddress;
        private Button btnConnect;
    }
}