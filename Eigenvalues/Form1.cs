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
    public partial class Form1 : Form
    {
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2(this) { Visible = false };
            InitializeComponent();
            form4 = new Form4(this) { Visible = false };
            form5 = new Form5(this) { Visible = false };
            form6 = new Form6(this) { Visible = false };
            form7 = new Form7(this) { Visible = false };
        }
        private Form4 form4;
        private Form5 form5;
        private Form6 form6;
        private Form7 form7;


        private void Form2_Load(object sender, EventArgs e)
        {

        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            form2.Visible = true;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Location= new Point(11,26);
            pictureBox2.Location = new Point(7, 34);
            pictureBox2.Width = 240;
            pictureBox2.Height = 60;
            button1.Width = 236;
            button1.Height = 57;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Location = new Point(13, 34);
            pictureBox2.Location = new Point(9, 34);
            pictureBox2.Width = 235;
            pictureBox2.Height = 55;
            button1.Width= 231;
            button1.Height = 52;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Location = new Point(11, 100);
            pictureBox3.Location = new Point(7, 108);
            pictureBox3.Width = 240;
            pictureBox3.Height = 60;
            button2.Width = 236;
            button2.Height = 57;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Location = new Point(13, 108);
            pictureBox3.Location = new Point(9, 108);
            pictureBox3.Width = 235;
            pictureBox3.Height = 55;
            button2.Width = 231;
            button2.Height = 52;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Location = new Point(11, 174);
            pictureBox4.Location = new Point(7, 182);
            pictureBox4.Width = 240;
            pictureBox4.Height = 60;
            button3.Width = 236;
            button3.Height = 57;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Location = new Point(13, 182);
            pictureBox4.Location = new Point(9, 182);
            pictureBox4.Width = 235;
            pictureBox4.Height = 55;
            button3.Width = 231;
            button3.Height = 52;
        }


        private int mousex = 0; private int mousey = 0;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mousex = e.X; mousey = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - mousex), this.Location.Y + (e.Y - mousey));

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            form4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            form5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            form6.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            form7.Visible = true;
        }
    }
}
