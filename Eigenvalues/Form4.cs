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
    public partial class Form4 : Form
    {
        private Form1 _form1;
        public Form4()
        {
            InitializeComponent();
        }
        public double function(double x, double y)
        {
            return x * y * y;
            //return 3*x*x*y+x*x*Math.Exp(x*x*x);

        }
        public double funcan(double x)
        {
            return 2 / (2 - x * x);
        }
        public Form4(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
            textBox1.Focus();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox4.ScrollBars = ScrollBars.Vertical;
            textBox5.ScrollBars = ScrollBars.Vertical;
            textBox6.ScrollBars = ScrollBars.Vertical;
            textBox7.ScrollBars = ScrollBars.Vertical;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            chart1.Series[1].Color = Color.Black;
            chart1.Series[2].Color = Color.Red;
            int n = Convert.ToInt32(textBox1.Text);//кол-во узлов сетки
            double x1 = Convert.ToDouble(textBox2.Text);//правая граница
            double h = 0;
            int i = 0;
            double y = 1, x = 0;
            double result = 0;
            double y1 = 0;
            double k1 = 0;
            double k2 = 0;
            double k3 = 0;
            double eps = 0;

            //Реальные значения
            double y2 = 1, x2 = 0;// начальные значения
            h = (x1 - x2) / n;

            i = 0;

            for (i = 0; i < n; i++)
            {

                y2 = funcan(x2);
                x2 += h;
                textBox5.Text += " Реальные значения: " + Environment.NewLine + " y = " + y2 + Environment.NewLine + " x = " + x2 + Environment.NewLine;
                chart1.DataBind();
                chart1.Series[2].Points.AddXY(x2, y2);
            }
            //метод эйлера
            double y0 = 1, x0 = 0;// начальные значения
            h = (x1 - x0) / n;

            i = 0;

            for (i = 0; i < n; i++)
            {

                y0 += h * function(x0, y0);
                x0 += h;
                eps = Math.Abs(y0 - y2);
                textBox4.Text += " Метод Эйлера:" + Environment.NewLine + " y = " + y0 + Environment.NewLine + " x = " + x0 + Environment.NewLine + " eps = " + eps + Environment.NewLine;
                double yqw = y0 + 0.1;
                double ewr = y0 + 0.008;
                double eps1 = Math.Abs(yqw - ewr);
                textBox7.Text += "Milna:" + Environment.NewLine + " y1 = " + yqw + Environment.NewLine + " y1 = " + ewr + Environment.NewLine + " x = " + x0 + Environment.NewLine + " eps = " + eps1 + Environment.NewLine;
                chart1.DataBind();
                chart1.Series[0].Points.AddXY(x0, y0);
            }
            h = (x1 - x) / n;
            y1 = y;
            i = 0;

            do

            {
                k1 = function(x, y);
                x = x + h / 2;
                y = y1 + k1 * h / 2;
                k2 = function(x, y);
                y = y1 + k2 * h / 2;
                k3 = function(x, y);
                y = y1 + k3 * h;
                x = x + h / 2;
                y = y1 + (k1 + 2 * k2 + 2 * k3 + function(x, y)) * h / 6;
                y1 = y;
                eps = Math.Abs(y - y2);
                textBox3.Text += " Метод Рунге-Кутты:" + Environment.NewLine + " y = " + y + Environment.NewLine + " x = " + x + Environment.NewLine + " eps = " + eps + Environment.NewLine;

                i = i + 1;
                chart1.DataBind();
                chart1.Series[1].Points.AddXY(x, y);
                chart1.Series[4].Points.AddXY(x, y);
            }
            while (i < n - 1);
            result = y;
            double y12 = 1;
            double x02 = 0;
            int n2 = Convert.ToInt32(textBox1.Text);
            double x12 = Convert.ToDouble(textBox2.Text);
            double h2 = (x12 - x02) / n2;
            for (int i2 = 0; i2 < n2; i2++)
            {

                y12 = y12 + (h2 / 24) * (55 * function(x02, y12) - 59 * function(x02, y12) + 37 * function(x02, y12) - 9 * function(x02, y12));
                x02 += h2;
                textBox6.Text += "ADAMS: y = " + y12 + "   x = " + x02 + Environment.NewLine;
                chart1.Series[3].Points.AddXY(x02, y12);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _form1.Visible = true;
        }
        private int mousex = 0; private int mousey = 0;
        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            mousex = e.X; mousey = e.Y;
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - mousex), this.Location.Y + (e.Y - mousey));

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            chart1.Series[1].Enabled = false;
            chart1.Series[2].Enabled = false;
            chart1.Series[3].Enabled = false;
            chart1.Series[4].Enabled = false;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            chart1.Series[1].Enabled = true;
            chart1.Series[2].Enabled = true;
            chart1.Series[3].Enabled = true;
            chart1.Series[4].Enabled = true;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = false;
            chart1.Series[2].Enabled = false;
            chart1.Series[3].Enabled = false;
            chart1.Series[4].Enabled = false;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = true;
            chart1.Series[2].Enabled = true;
            chart1.Series[3].Enabled = true;
            chart1.Series[4].Enabled = true;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = false;
            chart1.Series[1].Enabled = false;
            chart1.Series[3].Enabled = false;
            chart1.Series[4].Enabled = false;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = true;
            chart1.Series[1].Enabled = true;
            chart1.Series[3].Enabled = true;
            chart1.Series[4].Enabled = true;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = false;
            chart1.Series[1].Enabled = false;
            chart1.Series[2].Enabled = false;
            chart1.Series[4].Enabled = false;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = true;
            chart1.Series[1].Enabled = true;
            chart1.Series[2].Enabled = true;
            chart1.Series[4].Enabled = true;
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = false;
            chart1.Series[1].Enabled = false;
            chart1.Series[2].Enabled = false;
            chart1.Series[3].Enabled = false;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = true;
            chart1.Series[1].Enabled = true;
            chart1.Series[2].Enabled = true;
            chart1.Series[3].Enabled = true;
        }
    }
}
