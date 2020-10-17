using System;
using System.Linq;

namespace LeetCode
{
    public class AddBinaryTest
    {
        public AddBinaryTest()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Add Binary Test");
            Console.WriteLine("----------------------------------------------------------");
        }

        public string AddBinary(string a, string b)
        {
            string returnValue = "";
            //***
            //*** Get the maximum length of the two input
            //***
            int maxLength = a.Length > b.Length ? a.Length : b.Length;
            //***
            //*** Add leading zeros to each input
            //***
            a = a.PadLeft(maxLength, '0');
            b = b.PadLeft(maxLength, '0');

            char cof = '0';
            for (int i = maxLength - 1; i >= 0; i--)
            {
                //***
                //*** perform the addition on the bits
                //***
                var response = Add(a.ElementAtOrDefault(i), b.ElementAtOrDefault(i), cof);
                returnValue = response.result + returnValue;
                cof = response.cof;
            }

            if (cof == '1')
            {
                //***
                //*** Add the carrying bit to the start
                //***
                returnValue = "1" + returnValue;
            }
            else
            {
                //***
                //*** Remove leading zeros if any
                //***
                for (int i = 0; i < returnValue.Length; i++)
                {
                    if (returnValue[i] == '1')
                    {
                        returnValue = returnValue.Substring(i);
                        break;
                    }
                }
            }


            return returnValue;
        }

        private (char result, char cof) Add(char a = '0', char b = '0', char cof = '0')
        {
            if (a == '1' && b == '1')
            {
                if (cof == '1')
                {
                    return ('1', '1');
                }
                else
                {
                    return ('0', '1');
                }
            }
            else if ((a == '1' && b == '0') || (b == '1' && a == '0'))
            {
                if (cof == '1')
                {
                    return ('0', '1');
                }
                else
                {
                    return ('1', '0');
                }
            }
            else
            {
                if (cof == '1')
                {
                    return ('1', '0');
                }
                else
                {
                    return ('0', '0');
                }
            }
        }
    }
}