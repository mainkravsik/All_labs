using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eigenvalues
{
    public partial class Form5 : Form
    {
        private Form1 _form1;
        public Form5()
        {
            InitializeComponent();
        }
        public Form5(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
            textBox1.Focus();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        double f1(double x1, double x2)
        {
            return Math.Sqrt((x1 * (x2 + 5) - 1) / 2);
        }

        double f2(double x1, double x2)
        {
            return Math.Sqrt(x1 + 3 * Math.Log10(x1));
        }

        double f1p(double x1, double x2)
        {
            return (-(x2 + 1) / (Math.Sqrt(-x2 * x2 - 2 * x2 - 3)));
        }

        double f2p(double x1, double x2)
        {
            return (4 * x1);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double x1_p, x2_p;
            int iter = 0;
            double x1 = Convert.ToDouble(textBox1.Text);
            double x2 = Convert.ToDouble(textBox2.Text);
            double eps = Convert.ToDouble(textBox4.Text);
            do
            {
                iter++;
                x1_p = x1;
                x2_p = x2;
                x1 = f1(x1_p, x2_p);
                x2 = f2(x1_p, x2_p);

            }
            while ((Math.Abs(x1_p - x1) > eps) && (Math.Abs(x2_p - x2) > eps));
            textBox3.Text += " x1 = " + x1_p + "  x2 = " + x2_p + " iter = " + iter + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(textBox1.Text);
            double x2 = Convert.ToDouble(textBox2.Text);
            double eps = Convert.ToDouble(textBox4.Text);
            double x1pp, x2pp;
            int iter = 0;
            do
            {
                iter++;
                x1pp = x1;
                x2pp = x2;
                x1 = f1(x1pp, x2pp);
                x2 = f2(x1, x2pp);

            }
            while ((Math.Abs(x1pp - x1) > eps) && (Math.Abs(x2pp - x2) > eps));
            textBox3.Text += " x1 = " + x1 + "  x2 = " + x2 + " iter = " + iter + Environment.NewLine;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _form1.Visible = true;
        }
        private int mousex = 0; private int mousey = 0;
        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            mousex = e.X; mousey = e.Y;
        }

        private void Form5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - mousex), this.Location.Y + (e.Y - mousey));

            }
        }

        
    }
}
