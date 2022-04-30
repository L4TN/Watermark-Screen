using System.Windows.Forms;

namespace Timer_Implementado
{
    public partial class TimeTicker : Form
    {
        private Graphics g;
        private Font DispFont;
        private string CDate;
        private SolidBrush MyBrush;
        public TimeTicker()
        {
            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            g.DrawString(CDate.Substring(11), DispFont, MyBrush, 30, 30);
        }

        //Timer Event
        protected void OnTimer(object source, EventArgs e)
        {
            CDate = DateTime.Now.ToString();
            g.Clear(Color.FromArgb(216, 208, 200));
            g.DrawString(CDate.Substring(11), DispFont, MyBrush, 30, 30);
        }
        


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}