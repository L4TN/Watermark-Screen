using System;
using System.Drawing;
using System.Windows.Forms;

namespace WatermarkScreen
{
    partial class Watermark
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Watermark
            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(259, 111);

            //I used a Monospace Font to 
            this.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Watermark";

            this.Opacity = .18; //Define the opacity of Forms 
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Watermark_Paint;
            //this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.WindowState = FormWindowState.Maximized;
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            //this.Location
            this.Load += new System.EventHandler(this.Watermark_Load);

            //Criando o Timer
            System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
            aTimer.Interval = 1000; // 1000 milliseconds
            aTimer.Enabled = true;
            ///
            ///<summary> Ocorre quando o intervalo especificado tiver terminado e o temporizador estiver habilitado. </summary>
            ///<see href="https://docs.microsoft.com/pt-br/dotnet/api/system.windows.forms.timer?view=windowsdesktop-6.0"> </see>>
            ///

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

