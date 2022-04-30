using System.Windows.Forms;
namespace Timer_Implementado
{
    partial class TimeTicker
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
            // TimeTicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "TimeTicker";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            DispFont = new Font("Arial", 35, FontStyle.Bold);
            MyBrush = new SolidBrush(Color.Black);
            CDate = DateTime.Now.ToString();
            g = Graphics.FromHwnd(this.Handle);

            //Criando o Timer
            System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
            aTimer.Interval = 1000; // 1000 milliseconds
            aTimer.Enabled = true;
            aTimer.Tick += new EventHandler(OnTimer);

            //Setting Form Properties
            this.Size = new Size(275, 150);
            this.Text = "Time Ticker";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        #endregion
    }
}