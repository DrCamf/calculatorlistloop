using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculatorlistloop
{
    // This is my calculator that I've made using lists and loops
    public partial class Form1 : Form
    {
        List<double> tal = new List<double>();
        List<string> tegn = new List<string>();

        List<double> x = new List<double>();
        List<double> y = new List<double>();

        Pen myPen = new Pen(Color.Black);
        Pen GPen = new Pen(Color.Black);
        Graphics g = null;

        bool isMinus2Before, sincosM, udvid;
        bool isLeftPara;
        
        double numb = 0;
        Calc doIt = new Calc();
        string symbol;
        double talPow = 0;

        public Form1()
        {
            InitializeComponent();
        }
        //This is were the buttons are made to numbers in the textbox
        #region //Input
        private void btn_0_Click(object sender, EventArgs e) { hej.Text += "0"; }

        private void btn_1_Click(object sender, EventArgs e) { hej.Text += "1"; }

        private void btn_2_Click(object sender, EventArgs e) { hej.Text += "2"; }

        private void btn_3_Click(object sender, EventArgs e) { hej.Text += "3"; }

        private void btn_4_Click(object sender, EventArgs e) { hej.Text += "4"; }

        private void btn_5_Click(object sender, EventArgs e) { hej.Text += "5"; }

        private void btn_6_Click(object sender, EventArgs e) { hej.Text += "6"; }

        private void btn_7_Click(object sender, EventArgs e) { hej.Text += "7"; }

        private void btn_8_Click(object sender, EventArgs e) { hej.Text += "8"; }

        private void btn_9_Click(object sender, EventArgs e) { hej.Text += "9"; }


        #endregion

        //basic functions are the simpel math functions and the main calculation is done
        #region //Basic functions
        private void btn_Plus_Click(object sender, EventArgs e)
        {
            if (isLeftPara) hej.Text += " + ";
            else
            {
                if (Double.TryParse(hej.Text, out numb))
                {
                    tal.Add(numb);
                    tegn.Add("plus");
                    hej.Text = "";
                }
                else inputError();
            }
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            isMinus2Before = true;
            if (isLeftPara) hej.Text += " - ";
            else
            {
                if (Double.TryParse(hej.Text, out numb))
                {
                    tal.Add(numb);
                    tegn.Add("minus");
                    hej.Text = "";
                }
                else inputError();
            }
        }

        private void btn_multi_Click(object sender, EventArgs e)
        {
            if (isLeftPara) hej.Text += " * ";
            else
            {
                if (Double.TryParse(hej.Text, out numb))
                {
                    tal.Add(numb);
                    tegn.Add("multi");
                    hej.Text = "";
                }
                else inputError();
            }
        }

        private void btn_divi_Click(object sender, EventArgs e)
        {
            if (isLeftPara) hej.Text += " / ";
            else
            {
                if (Double.TryParse(hej.Text, out numb))
                {
                    tal.Add(numb);
                    tegn.Add("divi");
                    hej.Text = "";
                }
                else inputError();
            }
        }

        private void btn_Comma_Click(object sender, EventArgs e)
        {
            if (hej.Text.Contains(",")) hej.Text += "";
            else hej.Text += ",";
        }

        private void btn_PosiNega_Click(object sender, EventArgs e) { hej.Text = "-" + hej.Text; }

        private void btn_leftPara_Click(object sender, EventArgs e)
        {
            isLeftPara = true;
            hej.Text += "(";
        }

        private void btn_rigthPara_Click(object sender, EventArgs e)
        {
            string para = hej.Text.Substring(1, hej.Text.Length - 1);

            hej.Text = Convert.ToString(doIt.str_Calc(para, isMinus2Before));

            isLeftPara = false;
        }

        private void btn_Equal_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(hej.Text, out numb)) tal.Add(Convert.ToDouble(hej.Text));
            else inputError();
            
            double summ = doIt.Calc_do(tal.First<double>(), 0, tal, tegn, isMinus2Before);

            if (symbol == "pow") summ = Math.Pow(talPow, Convert.ToDouble(hej.Text)); 
            
            hej.Text = Convert.ToString(summ);

            tal.Clear();
            tegn.Clear();
            symbol = "";
        }
        #endregion

        // this is were the more scientific math functions are calculated
        #region //Extended functions
        private void btn_OneBack_Click(object sender, EventArgs e) { hej.Text = hej.Text.Remove(hej.Text.Length - 1); }

        private void btn_kvadrat_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(hej.Text, out numb)) hej.Text = Convert.ToString(Math.Sqrt(numb));
            else inputError();
            hej.Text = "";
        }

        private void btn_Potens_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(hej.Text, out numb)) hej.Text = Convert.ToString(numb * numb);
            else inputError();
            hej.Text = "";
        }

        private void btn_Pow_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(hej.Text, out numb))
            {
                talPow = numb;
                symbol = "pow";
            }
            hej.Text = Convert.ToString(numb * numb);

            hej.Text = "";
        }

        private void btn_Pi_Click(object sender, EventArgs e)
        {
            hej.Text = Convert.ToString(Math.PI);
        }

        private void btn_second_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(hej.Text);

            if (hej.Text.Substring(0, 1) == "-") sb.Replace("-", "+", 0, 1);
            else sb.Replace("+", "-", 0, 1);

            hej.Text = sb.ToString();
        }

        private void btn_sincos_Click(object sender, EventArgs e) { sincosM = true; }

        private void btn_sin_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(hej.Text, out numb))
            {
                if (sincosM)
                {
                    hej.Text = Convert.ToString(Math.Asin(numb));
                }
                else
                {
                    hej.Text = Convert.ToString(Math.Sin(numb));
                }
            }
            else inputError();
            sincosM = false;
        }

        private void btn_cos_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(hej.Text, out numb))
                if (sincosM)
                {
                    hej.Text = Convert.ToString(Math.Acos(numb));
                }
                else
                {
                    hej.Text = Convert.ToString(Math.Cos(numb));
                }
            else inputError();
            sincosM = false;
        }

        private void btn_tan_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(hej.Text, out numb))
                if (sincosM)
                {
                    hej.Text = Convert.ToString(Math.Atan(numb));
                }
                else
                {
                    hej.Text = Convert.ToString(Math.Tan(numb));
                }
            else inputError();
            sincosM = false;
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(hej.Text, out numb))
            {
                hej.Text = Convert.ToString(Math.Log(numb));
            }
            else inputError();
        }
        #endregion

        //this is the not quite finished functions for the graph
        #region //Skema graph

        private void btn_X_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(hej.Text, out numb)) x.Add(numb);
            else inputError();
            hej.Text = "";
        }

        private void btn_Y_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(hej.Text, out numb)) y.Add(numb);
            else inputError();
            hej.Text = "";
        }

        private void btn_DrawGraph_Click(object sender, EventArgs e)
        {
            //int cx = x.Count();
            //if (x.Count == y.Count)
            //{

            // for (int gp = 0; gp <= cx-1; gp++)
            //{
            //     Point[] g_point =
            //             new Point(Convert.ToInt32(x[gp]),Convert.ToInt32(y[gp]));

            //     if (gp != cx - 1)
            //     {
            //         g_point. = x[gp];
            //         g_point.y = y[gp];
            //         g_point[gp] = new Point(Convert.ToInt32(x[gp+1]), Convert.ToInt32(y[gp+1])) ;
            //     }else
            //     {
            //         g_point[gp] =
            //             new Point(Convert.ToInt32(x[gp]), Convert.ToInt32(y[gp]));
            //     }

            //     };
            //      g.DrawLines(GPen, g_point);
            //    }

            //}
            //else MessageBox.Show("Der er ikke lige mange x som y", "Ikke lige antal", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void graph_canvas_Paint(object sender, PaintEventArgs e)
        {
            GPen.Width = 2;
            myPen.Width = 1;
            g = graph_canvas.CreateGraphics();
            drawLine();
        }

        private void drawLine()
        {
            int antal = 20;
            int skema_size = 400;


            for (int i = antal; i <= skema_size; i += antal)
            {
                Point[] point_x = { new Point(i, 0),
                new Point(i, 400),
                new Point(i, 0) };

                Point[] point_y = {new Point(0, i),
                new Point(800, i),
                new Point(0, i) };

                g.DrawLines(myPen, point_x);
                g.DrawLines(myPen, point_y);

            }

        }

        private void btn_skema_Click(object sender, EventArgs e)
        {

            for (int k = 380; k >= 20; k -= 20)
            {

                Label value_y = new Label();
                value_y.Location = new Point(0, 392 - k);
                value_y.Size = new Size(25, 13);
                value_y.Text = Convert.ToString(k);

                Label value_x = new Label();
                value_x.Location = new Point(k - 10, 387);
                value_x.Size = new Size(25, 13);
                value_x.Text = Convert.ToString(k);

                graph_canvas.Controls.Add(value_y);
                graph_canvas.Controls.Add(value_x);
            }
        }
        #endregion

        //this captures user input errors
        private void inputError()
        {
            MessageBox.Show("Du har tastet bogstaver i stedet for tal", "Forkert indtastning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // this clears all variables and textbox
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tal.Clear();
            tegn.Clear();
            x.Clear();
            y.Clear();
           
            hej.Text = "";
            isMinus2Before = false;
            sincosM = false;
        }

        //this function extends and takes in the graph area
        private void btn_ucVid_Click(object sender, EventArgs e)
        {
            if (udvid)
            {
                this.Size = new Size(380, 489);
                udvid = false;
            }
            else
            {
                this.Size = new Size(840, 489);
                udvid = true;
            }
        }

        
    }
}
