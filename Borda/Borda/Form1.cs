using System.Drawing.Drawing2D;

namespace Borda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OutlineForeColor = Color.Green;
            OutlineWidth = 2;
        }

        public Color OutlineForeColor { get; set; }
        public float OutlineWidth { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
            using (GraphicsPath gp = new GraphicsPath())
            using (Pen outline = new Pen(OutlineForeColor, OutlineWidth)
            { LineJoin = LineJoin.Round })
            using (StringFormat sf = new StringFormat())
            using (Brush foreBrush = new SolidBrush(ForeColor))
            {
                gp.AddString(Text, Font.FontFamily, (int)Font.Style,
                    /*Font.Size*/ 48, ClientRectangle, sf);
                e.Graphics.ScaleTransform(1.3f, 1.35f);
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawPath(outline, gp);
                e.Graphics.FillPath(foreBrush, gp);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

