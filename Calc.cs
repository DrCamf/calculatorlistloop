using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatorlistloop
{
    class Calc
    {
        //this takes 2 lists with numbers and math functions and does the calculation
        public double Calc_do(double sum, int i, List<double> number, List<string> mode, bool isMinus)
        {
            number.RemoveAt(0);
            foreach (var tell in number)
            {
                if (mode[i] == "plus") sum += tell;
                else if (mode[i] == "minus")
                {
                    sum -= tell;
                    isMinus = true;
                }
                else if (mode[i] == "multi")
                {
                    if (i == 0) sum *= tell;
                    else if (i > 0 && isMinus) sum -= (number.ElementAt(i - 1) * tell) - ((number.ElementAt(i - 1)));
                    else
                    {
                        sum -= number.ElementAt(i - 1);
                        sum += number.ElementAt(i - 1) * tell;
                    }
                }
                else if (mode[i] == "divi") sum += (number.ElementAt(i - 1) / tell) - number.ElementAt(i - 1);

                i++;
            }
            return sum;
        }

        //this does the calculation from a string
        public double str_Calc(string str, bool isMinusBefore)
        {
            List<double> pTal = new List<double>();
            List<string> ptegn = new List<string>();

            double number;
            string[] nums = str.Split(' ');

            for (int h = 0; h <= nums.Length - 1; h++)
            {
                if (Double.TryParse(nums[h], out number)) pTal.Add(number);

                if (nums[h] == "+") ptegn.Add("plus");

                if (nums[h] == "-") ptegn.Add("minus");

                if (nums[h] == "*") ptegn.Add("multi");

                if (nums[h] == "/") ptegn.Add("divi");
            }

            double sumn = pTal[0];

            double summm = Calc_do(sumn, 0, pTal, ptegn, isMinusBefore);

            return summm;
        }
    }
}
