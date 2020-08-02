namespace Chat_Application_Client
{
    partial class OpeningForm
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
            this.signInBtn = new System.Windows.Forms.Button();
            this.signUpBtn = new System.Windows.Forms.Button();
            this.welcomeMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signInBtn
            // 
            this.signInBtn.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInBtn.Location = new System.Drawing.Point(286, 118);
            this.signInBtn.Name = "signInBtn";
            this.signInBtn.Size = new System.Drawing.Size(167, 50);
            this.signInBtn.TabIndex = 0;
            this.signInBtn.Text = "Sign In";
            this.signInBtn.UseVisualStyleBackColor = true;
            // 
            // signUpBtn
            // 
            this.signUpBtn.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpBtn.Location = new System.Drawing.Point(286, 174);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(167, 50);
            this.signUpBtn.TabIndex = 1;
            this.signUpBtn.Text = "Sign Up";
            this.signUpBtn.UseVisualStyleBackColor = true;
            // 
            // welcomeMsg
            // 
            this.welcomeMsg.AutoSize = true;
            this.welcomeMsg.Font = new System.Drawing.Font("Calibri", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeMsg.Location = new System.Drawing.Point(127, 32);
            this.welcomeMsg.Name = "welcomeMsg";
            this.welcomeMsg.Size = new System.Drawing.Size(472, 46);
            this.welcomeMsg.TabIndex = 2;
            this.welcomeMsg.Text = "Welcome to Chat Application";
            this.welcomeMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OpeningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.welcomeMsg);
            this.Controls.Add(this.signUpBtn);
            this.Controls.Add(this.signInBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpeningForm";
            this.ShowIcon = false;
            this.Text = "OpeningForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OpeningForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signInBtn;
        private System.Windows.Forms.Button signUpBtn;
        private System.Windows.Forms.Label welcomeMsg;
    }
}