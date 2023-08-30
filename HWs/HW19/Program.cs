using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using HW19;
using Microsoft.VisualBasic.CompilerServices;

namespace HW19
{
    public class LargeNumber:IEnumerable<byte>
    {
        public List<byte> _numberdata = new List<byte>();
        public IEnumerator<byte> GetEnumerator()
        {
            return _numberdata.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //public static LargeNumber operator +(LargeNumber number1, LargeNumber number2)
        //{
        //    return LargeNumber
        // }
        //public static LargeNumber operator -(LargeNumber number1, LargeNumber number2)
        //{
        //    return LargeNumber
        //}
        //public static LargeNumber operator *(LargeNumber number1, LargeNumber number2)
        //{
        //    return LargeNumber
        //}
        //public static LargeNumber operator /(LargeNumber number1, LargeNumber number2)
        //{
        //    return LargeNumber
        //}


        public LargeNumber(string number)
        {
            //_numberdata = new List<byte>(number.Length);
            //_numberdata.AddRange(number.Select(num => (byte)(num - '0')));
            foreach (char c in number)
            {
                _numberdata.Add(byte.Parse(c.ToString()));
            }
        }
    }
       

    }
        

        //private static IEnumerable<byte> SummTwoArrays(IEnumerable<byte> array1, IEnumerable<byte> array2)
        //{
        //    var num1Reverced= new List<byte>(array1.Reverse());
        //    var num2Reverced = new List<byte>(array2.Reverse());
        //    return array1.Reverse();
        //    if (num1Reverced.Count < num2Reverced.Count) (num1Reverced, num2Reverced) = (num2Reverced, num1Reverced);


        //}


    //}

    internal class Program
    {
        static void Main(string[] args)
        {
        LargeNumber ln1 = new LargeNumber ("2121245432");
        foreach (char c in ln1) 
        {
            Console.WriteLine(Convert.ToChar(c));
        }


    }
}
