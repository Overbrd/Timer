using System.Timers;
using System.Windows.Forms;

namespace Countdown
{
    public partial class Form1 : Form
    {
        System.Timers.Timer t;
        int h, m, s;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Enabled = false;
            t.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                txtResult.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            t.Stop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
        }
    }
}