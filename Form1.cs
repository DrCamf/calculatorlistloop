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

    public partial class Form1 : Form
    {
        List<double> tal = new List<double>();
        List<string> tegn = new List<string>();
        List<double> pTal = new List<double>();
        List<string> ptegn = new List<string>();
        bool isMinus2Before;
        bool isLeftPara;
        string para;

        public Form1()
        {
            InitializeComponent();
        }

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

        private void btn_Plus_Click(object sender, EventArgs e)
        {
            if (isLeftPara)
            {
                hej.Text += " + ";
            } else
            {
                tal.Add(Convert.ToDouble(hej.Text));
                tegn.Add("plus");
                hej.Text = "";
            }
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            isMinus2Before = true;
            if (isLeftPara)
            {
                hej.Text += " - ";
            }
            else
            {
                tal.Add(Convert.ToDouble(hej.Text));
                tegn.Add("minus");
                hej.Text = "";
            }
        }

        private void btn_multi_Click(object sender, EventArgs e)
        {
            if (isLeftPara)
            {
                hej.Text += " - ";
            }
            else
            {
                tal.Add(Convert.ToDouble(hej.Text));
                tegn.Add("multi");
                hej.Text = "";
            }
        }

        private void btn_divi_Click(object sender, EventArgs e)
        {
            if (isLeftPara)
            {
                hej.Text += " - ";
            }
            else
            {
                tal.Add(Convert.ToDouble(hej.Text));
                tegn.Add("divi");
                hej.Text = "";
            }
        }

        private void btn_Comma_Click(object sender, EventArgs e)
        {
            if (hej.Text.Contains(",")) hej.Text += "";
            else hej.Text += ",";
        }

        private void btn_PosiNega_Click(object sender, EventArgs e) { hej.Text = "-" + hej.Text; }

        private void btn_Equal_Click(object sender, EventArgs e)
        {
            tal.Add(Convert.ToDouble(hej.Text));

            double summ = Calc(tal.First<double>(), 0, tal, tegn, isMinus2Before);

            hej.Text = Convert.ToString(summ);

            tal.Clear();
            tegn.Clear();
        }

        private double Calc(double sum, int i, List<double> number, List<string> mode, bool isMinus)
        {
            tal.RemoveAt(0);
            foreach (var tell in number)
            {
                if (mode[i] == "plus")
                {
                    sum += tell;
                }
                else if (mode[i] == "minus")
                {
                    sum -= tell;
                    isMinus = true;
                }
                else if (mode[i] == "multi")
                {
                    if (i == 0)
                    {
                        sum *= tell;
                    }
                    else if (i > 0 && isMinus)
                    {
                        sum -= (number.ElementAt(i - 1) * tell) - ((number.ElementAt(i - 1)));
                    }
                    else
                    {
                        sum -= number.ElementAt(i - 1);
                        sum += number.ElementAt(i - 1) * tell;
                    }
                }
                else if (mode[i] == "divi")
                {
                    sum += (number.ElementAt(i - 1) / tell) - number.ElementAt(i - 1);
                }
                i++;
            }
            return sum;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tal.Clear();
            tegn.Clear();
            hej.Text = "";
            isMinus2Before = false;
        }

        private void btn_OneBack_Click(object sender, EventArgs e) { hej.Text = hej.Text.Remove(hej.Text.Length - 1); }

        private void btn_kvadrat_Click(object sender, EventArgs e)
        {
            double talk;
            talk = Convert.ToDouble(hej.Text);
            talk = Math.Sqrt(talk);
            hej.Text = Convert.ToString(talk);

        }

        private void btn_Potens_Click(object sender, EventArgs e)
        {
            double sum = Convert.ToDouble(hej.Text);
            sum *= sum;
            hej.Text = Convert.ToString(sum);
        }

        private void btn_Pow_Click(object sender, EventArgs e)
        {

        }

        private void btn_Pi_Click(object sender, EventArgs e)
        {
            double pi_value = Math.PI;
            hej.Text = Convert.ToString(pi_value);
        }

        private void btn_second_Click(object sender, EventArgs e)
        {
            if (hej.Text.Substring(0, 1) == "-")
            {
                StringBuilder sb = new StringBuilder(hej.Text);
                sb.Replace("-", "+", 0, 1);
                hej.Text = sb.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder(hej.Text);
                sb.Replace("+", "-", 0, 1);
                hej.Text = sb.ToString();
            }
        }

        private void btn_leftPara_Click(object sender, EventArgs e)
        {
            isLeftPara = true;
            hej.Text += "(";
        }

        private void btn_rigthPara_Click(object sender, EventArgs e)
        {

            para = hej.Text.Substring(1, hej.Text.Length - 1);

            string[] nums = para.Split(' ');
            double sumn = Convert.ToDouble(nums.First<string>());
            List<string> mellem = new List<string>();
            foreach (string item in nums)
            {
                mellem.Add(item);
            }
            
            for(int h = 0; h <= mellem.Count-1; h++)
            {
                if (mellem[h] == "+")
                {
                    ptegn.Add("plus");
                    mellem.Remove(mellem[h]);
                }
                if (mellem[h] == "-")
                {
                    ptegn.Add("minus");
                    
                }
                if (mellem[h] == "*")
                {
                    ptegn.Add("multi");
                    
                }
                if (mellem[h] == "/")
                {
                    ptegn.Add("divi");
                    
                }
                
            }


            pTal = mellem.ToList();

            double summm = Calc(sumn, 0, pTal, ptegn, isMinus2Before);
            hej.Text = Convert.ToString(summm);








            




        }
    

         
    }
}
