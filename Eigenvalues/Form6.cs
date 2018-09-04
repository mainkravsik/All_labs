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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private Form1 _form1;
        public Form6(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
            textBox1.Focus();
        }
        public double func1y(double x, double y, double z)
        {
            return (y * y) / (z - x);
        }

        public double func2z(double x, double y, double z)
        {
            return y + 1;
        }

        public double funcan1(double x, double y, double z)
        {
            return Math.Exp(-2 * x);
        }

        public double funcan2(double x, double y, double z)
        {
            return 5 * Math.Exp(-2 * x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Visible = true;
            textBox4.Visible = true;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            //textBox5.ScrollBars = ScrollBars.Vertical;
            textBox4.ScrollBars = ScrollBars.Vertical;
            textBox3.ScrollBars = ScrollBars.Vertical;
            chart1.Series[0].Color = Color.Black;
            chart1.Series[1].Color = Color.Black;
            double eps = 0;
            double eps1 = 0;
            int n = Convert.ToInt32(textBox1.Text);//кол-во узлов сетки
            double x1 = Convert.ToDouble(textBox2.Text);//правая граница
            double h1 = 0;
            int i = 0;
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[2].Color = Color.Red;
            chart1.Series[3].Color = Color.Red;
            double h0 = 0;
            double y1 = 4, x = 0, z1 = 2;
            h0 = (x1 - x) / n;
            do
            {
                y1 += h0 * func1y(x, y1 + 0.001, z1 + 0.01);
                z1 += h0 * func2z(x, y1 + 0.01, z1 + 0.02);
                x += h0;
                textBox3.Text += "Реальные значения:" + Environment.NewLine + " Реал1 = " + y1 + Environment.NewLine + " Реал2 = " + z1 + Environment.NewLine + " t =" + x + Environment.NewLine;
                i = i + 1;
                chart1.Series[2].Points.AddXY(x, y1);
                chart1.Series[3].Points.AddXY(x, z1);
            }
            while (i < n);
            y1 += 1;
            double y0 = 4, x0 = 0, z0 = 2;
            double result = 0;
            h1 = (x1 - x0) / n;
            i = 0;
            do
            {
                y0 += h1 * func1y(x0, y0, z0);
                z0 += h1 * func2z(x0, y0, z0);
                x0 += h1;

                textBox4.Text += "Метод Эйлера:" + Environment.NewLine + " Эйлер = " + y0 + Environment.NewLine + " Эйлер = " + z0 + Environment.NewLine + " t =" + x0 + Environment.NewLine;


                i = i + 1;
                chart1.Series[0].Points.AddXY(x0, y0);
                chart1.Series[1].Points.AddXY(x0, z0);
                eps = Math.Abs(y1 - y0);
                eps1 = Math.Abs(z1 - z0);
                //  textBox5.Text += "Погрешность по y = " + eps + Environment.NewLine + "Погрешность по z = " + eps1 + Environment.NewLine;
                result = y0;

            }
            while (i < n);


        }
        private int mousex = 0; private int mousey = 0;


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _form1.Visible = true;
        }

        private void Form6_MouseDown(object sender, MouseEventArgs e)
        {
            mousex = e.X; mousey = e.Y;
        }

        private void Form6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - mousex), this.Location.Y + (e.Y - mousey));

            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            chart1.Series[1].Enabled = false;
            chart1.Series[2].Enabled = false;
            chart1.Series[3].Enabled = false;
            
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            chart1.Series[1].Enabled = true;
            chart1.Series[2].Enabled = true;
            chart1.Series[3].Enabled = true;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = false;
            chart1.Series[2].Enabled = false;
            chart1.Series[3].Enabled = false;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = true;
            chart1.Series[2].Enabled = true;
            chart1.Series[3].Enabled = true;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = false;
            chart1.Series[1].Enabled = false;
            chart1.Series[3].Enabled = false;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = true;
            chart1.Series[1].Enabled = true;
            chart1.Series[3].Enabled = true;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = false;
            chart1.Series[1].Enabled = false;
            chart1.Series[2].Enabled = false;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = true;
            chart1.Series[1].Enabled = true;
            chart1.Series[2].Enabled = true;
        }
    }
}
