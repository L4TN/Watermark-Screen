using System.Timers;

namespace Watermark
{
    public partial class Watermark : Form
    {
        public string User = "HS PREVENT \r\n" + "Direitos reservados \r\n" + Environment.UserName + "\r\n" + Environment.MachineName + "\r\n";
        private const int WS_EX_TRANSPARENT = 0x20;

        public Watermark()
        {
            InitializeComponent();
            this.Opacity = .30;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Watermark_Paint;
            //this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;

        }
        // this makes the form ignore all clicks, so it is "passthrough"
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT; //Define a Transparencia de Fundo
                cp.ExStyle |= 0x80; //Hide Borderless Form from Alt+Tab
                return cp;
            }
        }

        public string hora = DateTime.Now.ToLongTimeString();
        public string data = DateTime.Now.ToString("dd/MM/yyyy");
        
        private void Watermark_Paint(object sender, PaintEventArgs e)
        {
           

            if (User != "")
                {
                    // play with this drawing code to change your "watermark"  
                    SizeF szF1 = e.Graphics.MeasureString(User + DateTime.Now.ToLongTimeString() + DateTime.Now.ToString("dd/MM/yyyy"), this.Font);
                    int max = Math.Max(this.Width, this.Height);
                
                    //Tira o serrilhado da fonte
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    e.Graphics.TextRenderingHint =System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                   

                        for (int y = 0; y <= max; y = y + (2 * (int)szF1.Height))
                        {
                            for (int x = 0; x <= max; x = x + (3 * (int)szF1.Height))
                            {
                                //e.Graphics.DrawString(dados, this.Font, Brushes.Black, 0, y);
                                var test = new SolidBrush(Color.FromArgb(255, Color.LightGray));
                                e.Graphics.DrawString(User + DateTime.Now.ToLongTimeString()  , this.Font, test, x, y);
                                //Bibliotecas System.Drawing tem a classe Graphics e Drawing
                                //DrawString, DrawPath, Pen, SolidBrush,Brush
                            }
                        }
                }
            
            
        }
        private void Form1_Load(object sender, EventArgs e)
        { 

        }

    }
}
