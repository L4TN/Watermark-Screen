using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Watermark
{
    public partial class Watermark : Form
    {
        
        //Attributes
        public string User = "HS PREVENT \r\n" + "Direitos reservados \r\n" + Environment.UserName + "\r\n" + Environment.MachineName + "\r\n";
        private const int WS_EX_TRANSPARENT = 0x20;
        public string hora = DateTime.Now.ToLongTimeString();
        public string data = DateTime.Now.ToString("dd/MM/yyyy");



        public Watermark()
        {
            ///
            ///<summary> This method contains the code that creates and initializes the user interface objects dragged on the form surface with the values provided by the programmer, using the Property Grid of the Form Designer. </summary>
            ///
            InitializeComponent();
            this.Location = Screen.AllScreens[0].WorkingArea.Location;

        }

        /// <summary>
        /// This function overwriting hexadecimal values of system making the Form click through and hidden.
        /// </summary>
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT; //Define the Background Transparency without colors 
                cp.ExStyle |= 0x80; //Hide Borderless Form from Alt+Tab
                return cp;
            }
        }

        /// <summary>
        ///  This function draw in screen the component.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watermark_Paint(object sender, PaintEventArgs e)
        {
            
            if (User != "")
            {
                // play with this drawing code to change your "watermark"  
                SizeF szF1 = e.Graphics.MeasureString(User + DateTime.Now.ToLongTimeString() + DateTime.Now.ToString("dd/MM/yyyy"), this.Font);
                int max = Math.Max(this.Width, this.Height);
                
                Antialising(e);
                
                for (int y = 0; y <= max; y = y + (2 * (int)szF1.Height))
                {
                    for (int x = 0; x <= max; x = x + (2 * (int)szF1.Height))
                    {
                        //e.Graphics.DrawString(dados, this.Font, Brushes.Black, 0, y);
                        var test = new SolidBrush(Color.FromArgb(255, Color.Red));
                        
                        e.Graphics.DrawString(User + DateTime.Now.ToLongTimeString(), this.Font, test, x, y);
                        
                        //Bibliotecas System.Drawing tem a classe Graphics e Drawing2D
                        //DrawString, DrawPath, Pen, SolidBrush,Brush
                    }
                }
            }
        }

        /// <summary>
        /// This function improve the quality of text drawed by Watermark_Paint method
        /// </summary>
        /// <param name="e"> Previous event that made the call to this function </param>
        private static void Antialising(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
        }

        /// <summary>
        ///  This function was defined by default template and is the event handler for Load event of the form when is loading.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
