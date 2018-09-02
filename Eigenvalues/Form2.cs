using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eigenvalues
{

    public partial class Form2 : Form
    {


        private bool isDragging = false;

        private Point lastCursor;
        private Point lastForm;

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;

            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location =
                    Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }





        ////Координаты мышки
        //private int x = 0; private int y = 0;

        //// Нажатие кнопки мышки
        //private void Form1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    x = e.X; y = e.Y;
        //}
        //// Движение мышки
        //private void Form1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //    {
        //        this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));

        //    }
        //}


        private Form1 _form1;

        Label[,] L;
        double[,] A;
        double[] B; double[] B1; double[] B2;
        double[] V;
        double[] Lu1; double[] Lu2; double[] Lu3; double[] Lu4;
        double[,] UL;
        double N;
        int n;
        bool tr=true;
        int pog;
        int m1;
        int m2;
        int m3;
        int Ypos = 0;
        bool a;
        public Form2(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
            textBox1.Focus();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _form1.Visible = true;
        }
        public static void WriteLine(string shapka, ref int Y0, ref Panel panel)
        {
            Label lab = new Label
            {
                Parent = panel,
                Left = 20,
                Top = Y0 + 25,

                Text = shapka,
                Width = 500,
                Height = 13
            };

            Y0 += 50;
        }

        public static void ZeroMass(double[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = 0;
            }
        }
        public static void FindX(double[] b, double[] c, double n)
        {
            for (int i = 0; i < b.Length; i++)
            {
                c[i] = b[i] / n;
            }
        }
        public static void FindY(double[] a, double[,] b, double[] c)
        {

            for (int i = 0; i < c.Length; i++)
            {
                for (int j = 0; j < c.Length; j++)
                {
                    a[i] += b[i, j] * c[j];


                }
            }

        }
        public static void Diag(double[,] a,double[]b,int no)
        {
            for (int i = 0; i <no ; i++)
            {
                b[i] = a[i, i];
            }

        }

        public static double LenghtV(double[] b)
        {
            double n = 0;
            for (int i = 0; i <= b.Length - 1; i++)
            {
                n = b[i] * b[i] + n;
            }
            n = Math.Sqrt(n);
            return n;

        }

        static bool Long(string s)
        {
            bool T = true;
            for (int i = 1; i <= s.Length - 1; i++)
            {
                if (s[i] == '-')
                {
                    T = false;
                }
            }
            return T;
        }

        static bool Ce(string s)
        {
            bool T = true;
            for (int i = 1; i <= s.Length - 1; i++)
            {
                if (s[i] == '-')
                {
                    T = false;
                }
            }
            return T;
        }
        static int Len(string s, char ch)
        {
            int k = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == ch)
                {
                    k += 1;
                }
            }

            return k;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && Convert.ToInt32(textBox1.Text) > 1 && textBox2.Text != "")
            {
                tr = false;
                WriteLine("Матрица А и Нулевое приближение собственного вектора Y: ", ref Ypos, ref panel1);
                a = true;
                n = Convert.ToInt32(textBox1.Text);
                A = new double[n, n];
                B = new double[n];
                UL = new double[n, n];
                L = new Label[n, n + 1];

                m1 = 0;
                m2 = 0;
                m3 = 0;

                groupBox2.Visible = true;
                button2.Visible = true;
                button2.Enabled = true;
                textBox3.Enabled = true;
                textBox3.Text = "";
                label3.Text = "Элемент [1,1] =";
                textBox3.Focus();
                button1.Enabled = false;
                textBox3.Left = 100;
                button2.Left = 197;


            }
            else
            {
                
                MessageBox.Show("Корректно введите размерность матрицы и погрешность!");
               
                textBox1.Focus();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox3.Text != "")
            {
                if (textBox3.Text[0] != ',' && textBox3.Text[textBox3.Text.Length - 1] != ',')
                {
                    if (Len(textBox3.Text, ',') <= 1 && Ce(textBox3.Text))
                    {
                        if (textBox3.Text != "" && textBox3.Text != "-")
                        {
                            if (a)
                            {
                                L[m1, m2] = new Label
                                {
                                    Parent = panel1,
                                    Left = (50 * m2) + 20,
                                    Top = 50 + 25 * m1
                                };
                                string str;
                                if (Convert.ToDouble(textBox3.Text) >= 0)
                                {
                                    str = " ";
                                }
                                else
                                {
                                    str = "-";
                                }
                                double g = Convert.ToDouble(textBox3.Text);
                                if (m2 > n - 1 || (m2 == 0 && g >= 0)) { L[m1, m2].Text = "   " + Convert.ToString(Math.Abs(Convert.ToDouble(textBox3.Text))); }
                                else L[m1, m2].Text = str + "   " + Convert.ToString(Math.Abs(Convert.ToDouble(textBox3.Text)));
                                L[m1, m2].Width = 50;
                                A[m1, m2] = Convert.ToDouble(textBox3.Text);


                                if (m1 == n - 1 && m2 == n - 1)
                                {

                                    textBox3.Left = 297;
                                    button2.Left = 394;
                                    label3.Text = "Нулевое приближение собственного вектора Y[" + Convert.ToString(m3 + 1) + "] =";

                                    for (int i = 0; i <= n - 1; i++)
                                    {
                                        Label LL = new Label
                                        {
                                            Parent = panel1,
                                            Left = 50 * n + 20,
                                            Top = 50 + 25 * i,
                                            Text = "I",
                                            Width = 10
                                        };
                                    }
                                    a = false;
                                }
                                else

                                    if (m2 == n - 1 && m1 != n - 1)
                                {
                                    m2 = 0;
                                    m1 += 1;
                                    label3.Text = "Элемент [" + Convert.ToString(m1 + 1) + "," + Convert.ToString(m2 + 1) + "]=";
                                }
                                else
                                {
                                    m2 += 1;
                                    label3.Text = "Элемент [" + Convert.ToString(m1 + 1) + "," + Convert.ToString(m2 + 1) + "]=";

                                }



                                textBox3.Focus();
                                textBox3.Text = "";

                            }
                            else
                            {
                                L[m3, n] = new Label
                                {
                                    Parent = panel1,
                                    Left = 50 * n + 50,
                                    Top = 50 + 25 * m3,
                                    Text = textBox3.Text,
                                    Width = 40
                                };
                                B[m3] = Convert.ToDouble(textBox3.Text);



                                if (m3 == n - 1)
                                {
                                    label3.Text = "Элемент [1,1] =";

                                    groupBox2.Visible = false;
                                    textBox3.Enabled = false;
                                    button3.Visible = true;
                                    button3.Enabled = true;
                                    label4.Enabled = true;
                                    label4.Visible = true;
                                    label5.Enabled = true;
                                    label5.Visible = true;
                                    label6.Enabled = true;
                                    label6.Visible = true;
                                    label7.Enabled = true;
                                    label7.Visible = true;
                                    label8.Enabled = true;
                                    label8.Visible = true;
                                    label9.Enabled = true;
                                    label9.Visible = true;
                                    label10.Enabled = true;
                                    label10.Visible = true;
                                    



                                }
                                else
                                {

                                    m3 += 1;
                                    label3.Text = "Нулевое приближение собственного вектора Y[" + Convert.ToString(m3 + 1) + "] =";

                                    textBox3.Focus();
                                    textBox3.Text = "";

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите элемент!");
                        }
                    }
                    else
                    {
                        textBox3.Text = "";
                        MessageBox.Show("Не корректный формат данных!");
                        textBox3.Focus();
                    }
                }
                else
                {
                    textBox3.Text = "";
                    MessageBox.Show("Не корректный формат данных!");
                    textBox3.Focus();
                }
            }
            else
            {
                textBox3.Text = "";
                MessageBox.Show("Не корректный формат данных!");
                textBox3.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }

            if (number == 13 && tr == true)
            {
                button1_Click(this, EventArgs.Empty);
                
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13 )
            {
                button2_Click(this, EventArgs.Empty);
                
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != ',' && number != 0x08)
            {
                e.Handled = true;
            }

            if (number == 13 && tr==true)
            {
                button1_Click(this, EventArgs.Empty);
                
            }
        }
        



        private void button3_Click(object sender, EventArgs e)
        {
            bool check = true; bool check2 = true;
            int t = 0;
            Lu1 = new double[n]; Lu2 = new double[n]; Lu3 = new double[n]; Lu4 = new double[n]; B1 = new double[n]; B2 = new double[n];
            V = new double[n];
            while (check == true)
            {
                N = LenghtV(B);
                FindX(B, V, N);//V=Массиву X(Y/длиннуY)
                ZeroMass(B);
                FindY(B, A, V);
                for (int i = 0; i < B.Length; i++)
                {
                    Lu2[i] = B[i] / V[i];
                    B1[i] = V[i];
                    if (Math.Abs(Lu2[i] - Lu1[i]) < Convert.ToDouble(textBox2.Text))
                    {
                        check = false;
                    }
                    Lu1[i] = Lu2[i];
                    t++;

                }

            }
            int no = V.Length;
            ZeroMass(V);
            Diag(A, V, no);
            for (int i = 0; i < V.Length; i++)
            {
                B[i] = Lu2[i] - V[i];
                //label10.Text += Convert.ToString(B[i]);
                //label10.Text += Convert.ToString("; ");

            }
            ZeroMass(V);
            while (check2 == true)
            {
                N = LenghtV(B);
                FindX(B, V, N);//V=Массиву X(Y/длиннуY)
                ZeroMass(B);
                FindY(B, A, V);
                for (int i = 0; i < B.Length; i++)
                {
                    Lu4[i] = B[i] / V[i];
                    B2[i] = V[i];
                    if (Math.Abs(Lu4[i] - Lu3[i]) < Convert.ToDouble(textBox2.Text))
                    {
                        check2 = false;
                    }
                    Lu3[i] = Lu4[i];


                }

            }

            label5.Text += Convert.ToString(t);
            for (int i = 0; i < Lu2.Length; i++)
            {
                
                label7.Text += Convert.ToString(Math.Round(B1[i],3));
                label7.Text += Convert.ToString("; ");
                label8.Text += Convert.ToString(Math.Round(Lu2[i],3));
                label8.Text += Convert.ToString("; ");
                label9.Text += Convert.ToString(Math.Round(B2[i],3));
                label9.Text += Convert.ToString("; ");
                label10.Text += Convert.ToString(Math.Round(Lu4[i],3));
                label10.Text += Convert.ToString("; ");
            }





            //for (int i = 0; i < B.Length; i++)
            //{
            //    label4.Text += Convert.ToString(B[i]);
            //    label4.Text += Convert.ToString(',');
            //}
            button3.Enabled = false;
            }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ypos = 0;
            panel1.Controls.Clear();
            groupBox2.Visible = false;
            textBox1.Focus();
            button3.Visible = false;
            button3.Enabled = false;
            label4.Enabled = false;
            label4.Visible = false;
            label5.Enabled = false;
            label5.Visible = false;
            label6.Enabled = false;
            label6.Visible = false;
            label7.Enabled = false;
            label7.Visible = false;
            label8.Enabled = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            button1.Enabled = true;
            tr = true;
            label7.Text = "Max X:"; label8.Text = "Max λ:"; label9.Text = "Min X:"; label10.Text = "Min λ:"; label5.Text = "Количество итераций: ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //textBox1.Text = Convert.ToString(3);
            //textBox2.Text = "0,0001";
            //button1_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(5);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(1);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(2);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(1);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(4);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(1);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(2);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(1);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(3);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(1);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(2);
            //button2_Click(this, EventArgs.Empty);
            //textBox3.Text = Convert.ToString(2);
            //button2_Click(this, EventArgs.Empty);


            //A[1, 1] = 5;
            //A[1, 2] = 1;
            //A[1, 3] = 2;
            //A[2, 1] = 1;
            //A[2, 2] = 4;
            //A[2, 3] = 1;
            //A[3, 1] = 2;
            //A[3, 2] = 1;
            //A[3, 3] = 3;


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        //Координаты мышки
        private int mousex = 0; private int mousey = 0;

       

        

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            mousex = e.X; mousey = e.Y;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - mousex), this.Location.Y + (e.Y - mousey));

            }
        }
    }
}
