using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;


namespace WatermarkScreen
{
    public partial class Watermark : Form
    {
        //Attributes
        public string Text_Show;
        public string Time_Date;
        private const int WS_EX_TRANSPARENT = 0x20;

        //This Function make the Constructor Method, calling InitializeComponent() to do it
        public Watermark()
        {
            ///
            ///<summary> This method contains the code that creates and initializes the user interface objects dragged on the form surface with the values provided by the programmer, using the Property Grid of the Form Designer. </summary>
            ///
            InitializeComponent();
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
            Text_Show = "Your Company Name here \r\n" + "Direitos reservados \r\n" + Environment.UserName + "\r\n";

            /// "SizeF" Stores an ordered pair of floating-point numbers, typically the width and height of a rectangle, 
            /// "szF1" receive de value of return of "MeasureString()" and initializes a new instance of the SizeF structure from the specified dimensions, this dimensions size 
            /// "MeasureString()" Measures the specified string when drawn with the specified Font text.
            SizeF szF1 = e.Graphics.MeasureString(Text_Show + Time_Date, this.Font);

            //Returns the larger of two specified numbers.
            int max = Math.Max(this.Width, this.Height);

            //Is the Object used to draw lines, instead "Soolid Brush" we could use too classes "Pen", "Brush".
            var ToolDraw = new SolidBrush(Color.FromArgb(255, Color.Red));

            //
            double wid1 = (this.Width % szF1.Width) / 2;
            double wid2 = Math.Truncate(this.Width / szF1.Width);
            double hei1 = (this.Height % szF1.Height) / 2;
            double hei2 = Math.Truncate(this.Height / szF1.Height);

            Antialising(e);

            for (int i = 0; i < hei2; i++)
            {
                if ((i % 2) == 0)
                {
                    for (int j = 0; j < wid2; j = j + 2)
                    {
                        e.Graphics.DrawString(Text_Show+ Timer(), this.Font, ToolDraw, (float)(wid1 + szF1.Width * j), (float)(hei1 + szF1.Height * i));
                    }
                }
                else
                {
                    for (int j = 0; j < wid2 - 1; j = j + 2)
                    {
                        e.Graphics.DrawString(Text_Show+ Timer(), this.Font, ToolDraw, (float)(wid1 + szF1.Width * (j + 1)), (float)(hei1 + szF1.Height * i));
                    }
                    // for (double x = (1 * (int)szF1.Width) ; x <= this.Width; x = x + (2 * (int)szF1.Width))
                    //{

                    // e.Graphics.DrawString(Text, this.Font, ToolDraw, (float)x, (float)y);
                    //Bibliotecas System.Drawing tem a classe Graphics e Drawing2D
                    //DrawString, DrawPath, Pen, SolidBrush,Brush
                    //}
                }   
            }

            e.Graphics.DrawString(Environment.MachineName, this.Font, ToolDraw, this.Width - 250, this.Height - 225);


            this.Invalidate();
            GC.Collect(0);
            Thread.Sleep(1000);
            this.Update();
            
        }

        private string Timer() {
     
            Time_Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return Time_Date;
        }

        /// <summary>
        /// This method imporve the quality of text drawed by Watermark_Paint method
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
        private void Watermark_Load(object sender, EventArgs e)
        {

        }
    }
}
