
namespace Hotel_Management
{
    partial class SignIn
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
            this.SuspendLayout();
            // 
            // SignIn
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "SignIn";

            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnHide;
    }
}

