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
    public partial class Form7 : Form
    {
        Label[,] L;
        double[,] A;
        double[] B;
        double[,] UL;
        int n;
        int m1;
        int m2;
        int m3;
        int Ypos = 0;
        bool a;
        bool b;
        double eps = 0.01;
        public Form7()
        {
            InitializeComponent();
        }
        private Form1 _form1;
        public Form7(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
            textBox1.Focus();
        }



        private void Form7_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            groupBox2.Parent = panel1.Parent;
            groupBox2.Left = 0;
            groupBox2.Top = 0;

            panel1.Left = 0;

            panel1.Top = groupBox2.Height;
            panel1.Height = groupBox1.Height - groupBox2.Height;
        }
        public static void WriteIteration(string shapka, double[] O, int count, ref int Y0, ref Panel panel)
        {
            Label lab = new Label();

            lab.Parent = panel;
            lab.Left = 70;
            lab.Top = Y0;
            //Y0 += 50;
            lab.Text = shapka;
            lab.Width = 100;
            lab.Height = 13;

            for (int j = 0; j < count; j++)
            {
                Label label = new Label();

                label.Parent = panel;
                label.Left = 180 + (200 * j) + 20;
                label.Top = Y0;
                label.Text = "X[" + Convert.ToString(j + 1) + "] = " + Convert.ToString(O[j]);
                label.Width = 200;
                label.Height = 13;
            }
            Y0 += 20;

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
        public static void WriteStroka(string shapka, double[] O, int count, ref int Y0, ref Panel panel)
        {
            Label lab = new Label();

            lab.Parent = panel;
            lab.Left = 70;
            lab.Top = Y0;
            Y0 += 50;
            lab.Text = shapka;
            lab.Width = 150;
            lab.Height = 13;

            for (int j = 0; j < count; j++)
            {
                Label label = new Label();

                label.Parent = panel;
                label.Left = (50 * j) + 20;
                label.Top = Y0;
                label.Text = /*"X" + Convert.ToString(j + 1) + " = " +*/ Convert.ToString(O[j]);
                label.Width = 50;
                label.Height = 13;
            }
            Y0 += 20;

        }

        public static void WriteMass(string shapka, double[,] O, int count, ref int Y0, ref Panel panel)
        {
            Label lab = new Label();

            lab.Parent = panel;
            lab.Left = 70;
            lab.Top = Y0;
            Y0 += 20;
            lab.Text = shapka;
            lab.Width = 70;
            lab.Height = 13;
            for (int i = 0; i < count; i++)
            {
                Y0 += 25;
                for (int j = 0; j < count; j++)
                {

                    Label label = new Label();

                    label.Parent = panel;
                    label.Left = (50 * j) + 20;
                    label.Top = Y0;
                    label.Text = Convert.ToString(O[i, j]);
                    label.Width = 50;
                    label.Height = 13;
                }
            }

            Y0 += 50;
        }

        public static void WriteSLAU(string shapka, double[,] O, double[] Otv, int count, ref int Y0, ref Panel panel)
        {
            Label lab = new Label();

            lab.Parent = panel;
            lab.Left = 70;
            lab.Top = Y0;
            Y0 += 20;
            lab.Text = shapka;
            lab.Width = 70;
            lab.Height = 13;
            for (int i = 0; i < count; i++)
            {
                Y0 += 25;
                for (int j = 0; j <= count + 1; j++)
                {

                    Label label = new Label();

                    label.Parent = panel;
                    label.Left = (50 * j) + 20;
                    label.Top = Y0;
                    if (j < count)
                    {
                        label.Text = Convert.ToString(O[i, j]) + "  X" + Convert.ToString(j + 1);
                    }
                    else if (j == count)
                    {
                        label.Text = " = ";
                    }
                    else if (j > count)
                    {
                        label.Text = Convert.ToString(Otv[i]);
                    }
                    label.Width = 50;
                    label.Height = 13;
                }
            }

            Y0 += 50;
        }

        static double SUMU(int i, int j, double[,] UL)
        {
            double SUM = 0;
            for (int k = 0; k <= i; k++)
            {
                SUM += (UL[i, k] * UL[k, j]);
            }
            return SUM;
        }

        static double SUML(int i, int j, double[,] UL)
        {
            double SUM = 0;
            for (int k = 0; k < j; k++)
            {
                SUM += (UL[i, k] * UL[k, j]);
            }
            return SUM;
        }
        public static double[] MultiplyMatrix(double[,] Am, double[] Y, int n)
        {
            double[] Y1 = new double[n];
            //Y[0] = 1; Y[1] = 2; Y[2] = 2;
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += Am[i, j] * Y[j];
                }
                Y1[i] = sum;
                //MessageBox.Show(Convert.ToString(Y1[i]));
            }
            return Y1;
        }

        public static void nulVector(ref double[] Y, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Y[i] = 0;
            }
        }

        public static bool CheckB(double[] Bb, int n)
        {
            bool da = true;
            int ch = 0;
            for (int i = 0; i < 0; i++)
            {
                if (Bb[i] == 0)
                { ch++; }
            }
            if (ch == n) { da = false; }
            return da;
        }

        public static double[] lenvector(double[] vec, int n)
        {
            double len = 0;
            for (int i = 0; i < n; i++)
            {
                len += vec[i] * vec[i];
            }
            len = Math.Sqrt(len);

            for (int i = 0; i < n; i++)
            {
                vec[i] = vec[i] / len;
            }

            return vec;
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

        public static bool diag_element_max(double[] mas, int pos, int n)
        {
            bool BB = true;
            for (int i = 0; i < pos; i++)
            {
                if (Math.Abs(mas[i]) >= Math.Abs(mas[pos]))
                {
                    BB = false; break;
                }
            }
            for (int i = pos + 1; i < n; i++)
            {
                if (Math.Abs(mas[i]) >= Math.Abs(mas[pos]))
                {
                    BB = false; break;
                }
            }

            return BB;
        }

        public static bool DXEPS(double[] X, double[] Xpred, double eps, int n)
        {
            bool p = false;
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(X[i] - Xpred[i]) <= eps)
                {
                    p = true;
                }
                else
                {
                    p = false;
                }
                //MessageBox.Show("X[" + Convert.ToString(i) + "] = " + Convert.ToString(X[i]) + "   Xpred[" + Convert.ToString(i) + "] = " + Convert.ToString(Xpred[i]) + "    Результат " + Convert.ToString(Math.Abs(X[i] - Xpred[i])));
                for (int j = 0; j < n; j++)
                {
                    // MessageBox.Show("X[" + Convert.ToString(j) + "] = " + Convert.ToString(X[j]) + "   Xpred[" + Convert.ToString(j) +  "] = " + Convert.ToString(Xpred[j]) + "    Результат " + Convert.ToString(Math.Abs(X[j] - Xpred[j])));
                }
            }
            return p;
        }

        public static double MaxDiagElem(double[,] Am, int n, ref int x, ref int y)
        {
            double Max = 0;
            x = 0;
            y = 0;

            for (int i = 0; i < n; i++)
            {
                //MessageBox.Show("i = "+Convert.ToString(i));
                for (int j = i + 1; j < n; j++)
                {
                    if (Am[i, j] > Max) { Max = Am[i, j]; x = i; y = j; }
                    ///MessageBox.Show("j = "+Convert.ToString(j));
                }
            }
            //MessageBox.Show("MaxDIAG =" + Convert.ToString(Max));
            return Max;

        }

        public static double MaxDiagModElem(double[,] Am, int n)
        {
            double Max = 0;
            int x = 0;
            int y = 0;

            for (int i = 0; i < n; i++)
            {
                //MessageBox.Show("i = "+Convert.ToString(i));
                for (int j = i + 1; j < n; j++)
                {
                    Am[i, j] = Math.Abs(Am[i, j]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                //MessageBox.Show("i = "+Convert.ToString(i));
                for (int j = i + 1; j < n; j++)
                {
                    if (Am[i, j] > Max) { Max = Am[i, j]; x = i; y = j; }
                    //MessageBox.Show(Convert.ToString(Am[i, j]));
                }
            }
            //MessageBox.Show("MaxDIAG =" + Convert.ToString(Max));
            return Max;

        }

        public static double SumDiag(double[,] Am, int n)
        {
            double Sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        Sum += Am[i, j] * Am[i, j];
                    }
                }
            }
            return Sum;
        }

        public static double SumNotDiag(double[,] Am, int n)
        {
            double Sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        Sum += Am[i, j] * Am[i, j];
                    }
                }
            }
            return Sum;
        }

        public static void NULL(ref double[,] mas, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        mas[i, j] = 1;
                    }
                    else mas[i, j] = 0;
                }
            }
        }

        public static double[,] TranspMatrix(double[,] mas, int n)
        {
            double tmp = 0;
            double[,] A = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmp = mas[i, j];
                    A[i, j] = mas[j, i];
                    A[j, i] = tmp;
                }
            }
            return A;
        }

        public static double[,] MultiMatrix(double[,] Am, double[,] Y, int n)
        {
            double[,] Y1 = new double[n, n];

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (int j = 0; j < n; j++)
                {
                    Y1[i, j] = 0;
                    for (int l = 0; l < n; l++)
                    {
                        Y1[i, j] += Am[i, l] * Y[l, j];
                        Y1[i, j] = Math.Round(Y1[i, j], 4);
                        //MessageBox.Show("sum "+Convert.ToString(sum));
                    }
                    //Y1[i, j] = sum;
                    //Y1[i, j] = sum;
                }

                //MessageBox.Show(Convert.ToString(Y1[i]));
            }
            return Y1;
        }

        public static double[,] MultiHMatrix(double[,] Am, double[,] Y, int n)
        {
            double[,] Y1 = new double[n, n];

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (int j = 0; j < n; j++)
                {
                    Y1[i, j] = 0;
                    for (int l = 0; l < n; l++)
                    {
                        Y1[i, j] += Am[i, l] * Y[l, j];
                        //Y1[i, j] = Math.Round(Y1[i, j], 4);
                        //MessageBox.Show("sum "+Convert.ToString(sum));
                    }
                    //Y1[i, j] = sum;
                    //Y1[i, j] = sum;
                }

                //MessageBox.Show(Convert.ToString(Y1[i]));
            }
            return Y1;
        }

        public static double[,] RavnoMatrix(double[,] A, double[,] B, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    B[i, j] = A[i, j];
                }
            }
            return B;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && Convert.ToInt32(textBox1.Text) > 1 && textBox3.Text != "")
            {
                a = true;
                b = false;
                n = Convert.ToInt32(textBox1.Text);
                A = new double[n, n];
                B = new double[n];
                UL = new double[n, n];
                //T = new TextBox[n, n];
                L = new Label[n, n];
                m1 = 0;
                m2 = 0;
                m3 = 0;
                eps = Convert.ToDouble(textBox3.Text);
                groupBox2.Visible = true;
                button3.Visible = true;
                button3.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Enabled = false;
                textBox3.Enabled = false;
                textBox2.Text = "";
                label2.Text = "Элемент [1,1] =";
                textBox2.Focus();
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Указано некорректрое число элементов либо не указана погрешность!");
                textBox1.Focus();

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }

            if (number == 13)
            {
                textBox3.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (textBox2.Text[0] != ',' && textBox2.Text[textBox2.Text.Length - 1] != ',')
                {
                    if (Len(textBox2.Text, ',') <= 1 && Ce(textBox2.Text))
                    {
                        if (textBox2.Text != "" && textBox2.Text != "-")
                        {
                            if (a)
                            {
                                L[m1, m2] = new Label();

                                L[m1, m2].Parent = panel1;
                                L[m1, m2].Left = (50 * m2) + 20;
                                L[m1, m2].Top = 100 + 25 * m1;
                                string str = "";
                                /*if (Convert.ToDouble(textBox2.Text) >= 0)
                                {
                                    str = "+";
                                }
                                else
                                {
                                    str = "-";
                                }*/
                                double g = Convert.ToDouble(textBox2.Text);
                                L[m1, m2].Text = (textBox2.Text);
                                L[m1, m2].Width = 50;
                                A[m1, m2] = Convert.ToDouble(textBox2.Text);


                                //MessageBox.Show(Convert.ToString(L[m1, m2].Left) + "   " + Convert.ToString(L[m1, m2].Top) + "  "  + Convert.ToString(m1) + "   " + Convert.ToString(m2));
                                if (m1 == n - 1 && m2 == n - 1)
                                {
                                    a = false;
                                    b = true;
                                    //MessageBox.Show("");
                                }
                                else

                                if (m2 == n - 2 && m1 == n - 1)
                                {
                                    a = false;
                                    //MessageBox.Show("");
                                }

                                if (m2 == n - 1 && m1 != n - 1)
                                {
                                    m2 = 0;
                                    m1 += 1;
                                    label2.Text = "Элемент [" + Convert.ToString(m1 + 1) + "," + Convert.ToString(m2 + 1) + "]=";

                                }
                                else
                                {
                                    m2 += 1;
                                    label2.Text = "Элемент [" + Convert.ToString(m1 + 1) + "," + Convert.ToString(m2 + 1) + "]=";

                                }

                                /*if (m2 == n - 1 && m1 == n - 1)
                                {
                                    MessageBox.Show("ffdfdfdf");
                                }*/

                                textBox2.Focus();
                                textBox2.Text = "";

                            }

                            /* if (b)
                             {
                                 // MessageBox.Show("");
                                 Label L = new Label();

                                 L.Parent = panel1;
                                 L.Left = (50 * m3) + 20;
                                 L.Top = 100 + 25 * (2 * m1);
                                 L.Text = Convert.ToString(textBox2.Text);
                                 m3++;
                                 if (m3 == n)
                                 { b = false; }
                             }*/

                            else
                            {
                                //Label LL = new Label();
                                L[m1, m2] = new Label();
                                L[m1, m2].Parent = panel1;
                                L[m1, m2].Left = (50 * m2) + 20;
                                L[m1, m2].Top = 100 + 25 * m1;

                                double g = Convert.ToDouble(textBox2.Text);
                                L[m1, m2].Text = textBox2.Text;

                                L[m1, m2].Width = 40;
                                A[m1, m2] = Convert.ToDouble(textBox2.Text);
                                //B[m2] = Convert.ToDouble(textBox2.Text);

                                //MessageBox.Show("FFF");

                                label2.Text = "Элемент [1,1] =";
                                button3.Enabled = false;
                                groupBox2.Visible = false;
                                textBox2.Enabled = false;
                                


                            }

                        }
                        else
                        {
                            MessageBox.Show("Введите элемент!");
                        }
                    }
                    else
                    {
                        textBox2.Text = "";
                        MessageBox.Show("Не корректный формат данных, эжжи!!!");
                        textBox2.Focus();
                    }
                }
                else
                {
                    textBox2.Text = "";
                    MessageBox.Show("Не корректный формат данных, эжжи!!!");
                    textBox2.Focus();
                }
            }
            else
            {
                textBox2.Text = "";
                MessageBox.Show("Не корректный формат данных, эжжи!!!");
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                button3_Click(this, EventArgs.Empty);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ypos = 0;
            panel1.Controls.Clear();
            groupBox2.Visible = false;
            button3.Visible = false;
            textBox2.Enabled = false;
            button1.Enabled = true;
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Focus();
        }

        private void Form7_Resize(object sender, EventArgs e)
        {
            panel1.Left = 0;

            panel1.Top = groupBox2.Height;
            //panel1.Width = groupBox2.Width - groupBox1.Width;
            panel1.Height = groupBox1.Height - groupBox2.Height;
        }
        
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (number == 13)
            {
                button1_Click(this, EventArgs.Empty);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ypos = 0;
            panel1.Controls.Clear();
            double[,] AA = A;
            double[,] H0 = new double[n, n]; // массив аш нулевое мур мур мяу
            double[,] multisumH = new double[n, n];




            int iter = 0;
            double fi0 = 0;
            while (true)
            {

                int i = 0;
                int j = 0;
                double Aij = MaxDiagElem(AA, n, ref i, ref j);
                fi0 = (Math.Atan((2 * AA[i, j]) / (AA[i, i] - AA[j, j]))) / 2;
                NULL(ref H0, n);
                if (iter == 0)
                {
                    multisumH = RavnoMatrix(H0, multisumH, n);
                }
                H0[i, j] = -Math.Sin(fi0);
                H0[j, i] = Math.Sin(fi0);
                H0[i, i] = Math.Cos(fi0);
                H0[j, j] = Math.Cos(fi0);
                double[,] Ht = TranspMatrix(H0, n);
                if (iter == 0)
                {
                    multisumH = RavnoMatrix(H0, multisumH, n);
                }
                else if (iter > 0)
                {

                    multisumH = MultiHMatrix(multisumH, H0, n);
                }


                double[,] Aprom = new double[n, n];
                Aprom = MultiMatrix(Ht, AA, n);

                AA = MultiMatrix(Aprom, H0, n);

                double T = MaxDiagModElem(AA, n);




                if (T < eps)
                {
                    WriteLine("Собств. вектора:", ref Ypos, ref panel1);
                    WriteMass("", multisumH, n, ref Ypos, ref panel1);
                    double[] snznach = new double[n];
                    for (int k = 0; k < n; k++)
                    {
                        snznach[k] = AA[k, k];

                    }

                    WriteLine("Собств. значения:", ref Ypos, ref panel1);
                    WriteStroka("", snznach, n, ref Ypos, ref panel1);

                    for (int k = 0; k < n; k++)
                    {
                        for (int k2 = 0; k2 < n; k2++)
                        {
                            snznach[k] = multisumH[k2, k];

                        }
                        //WriteLine("X" + Convert.ToString(k + 1) + ": ", ref Ypos, ref panel1);
                        //WriteStroka("", snznach, n, ref Ypos, ref panel1);
                    }


                    break;
                }
                iter++;
                



            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _form1.Visible = true;
        }
        private int mousex = 0; private int mousey = 0;

        private void Form7_MouseDown(object sender, MouseEventArgs e)
        {
            mousex = e.X; mousey = e.Y;
        }

        private void Form7_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - mousex), this.Location.Y + (e.Y - mousey));

            }
        }
    }
}
