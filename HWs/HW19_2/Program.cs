using System;
using System.Collections.Generic;

public class BigIntegerLite
{
    private List<byte> bytes;

    public BigIntegerLite()
    {
        bytes = new List<byte>();
    }

    public BigIntegerLite(byte[] byteArray)
    {
        bytes = new List<byte>(byteArray);
    }

    public void SetValue(byte[] byteArray)
    {
        bytes = new List<byte>(byteArray);
    }

    public byte[] ToByteArray()
    {
        return bytes.ToArray();
    }

    public void Add(BigIntegerLite other)
    {
        int maxLength = Math.Max(bytes.Count, other.bytes.Count);
        int carry = 0;

        for (int i = 0; i < maxLength; i++)
        {
            if (i < bytes.Count)
                carry += bytes[i];

            if (i < other.bytes.Count)
                carry += other.bytes[i];

            if (i < bytes.Count)
                bytes[i] = (byte)(carry % 256);
            else
                bytes.Add((byte)(carry % 256));

            carry /= 256;
        }

        if (carry > 0)
            bytes.Add((byte)carry);
    }

    public override string ToString()
    {
        return string.Join("", bytes);
    }
    public void Subtract(BigIntegerLite other)
    {
        int maxLength = Math.Max(bytes.Count, other.bytes.Count);
        int borrow = 0;

        for (int i = 0; i < maxLength; i++)
        {
            int diff = borrow;

            if (i < bytes.Count)
                diff += bytes[i];

            if (i < other.bytes.Count)
                diff -= other.bytes[i];

            if (diff < 0)
            {
                borrow = -1;
                diff += 256;
            }
            else
            {
                borrow = 0;
            }

            if (i < bytes.Count)
                bytes[i] = (byte)diff;
            else
                bytes.Add((byte)diff);
        }

        while (bytes.Count > 1 && bytes.Last() == 0)
            bytes.RemoveAt(bytes.Count - 1);
    }
    //public void Multiply(BigIntegerLite other)
    //{
    //    List<byte> resultBytes = new List<byte>(new byte[bytes.Count + other.bytes.Count]);

    //    for (int i = 0; i < bytes.Count; i++)
    //    {
    //        int carry = 0;

    //        for (int j = 0; j < other.bytes.Count; j++)
    //        {
    //            int product = bytes[i] * other.bytes[j] + resultBytes[i + j] + carry;
    //            carry = product / 256;
    //            resultBytes[i + j] = (byte)(product % 256);
    //        }

    //        if (carry > 0)
    //            resultBytes[i + other.bytes.Count] = (byte)carry;
    //    }

    //    while (resultBytes.Count > 1 && resultBytes.Last() == 0)
    //        resultBytes.RemoveAt(resultBytes.Count - 1);

    //    bytes = resultBytes;
    //}

    public static BigIntegerLite operator +(BigIntegerLite left, BigIntegerLite right)
    {
        BigIntegerLite result = new BigIntegerLite(left.bytes.ToArray());
        result.Add(right);
        return result;
    }
    public static BigIntegerLite operator -(BigIntegerLite left, BigIntegerLite right)
    {
        BigIntegerLite result = new BigIntegerLite(left.bytes.ToArray());
        result.Subtract(right);
        return result;
    }
    //public static BigIntegerLite operator /(BigIntegerLite dividend, BigIntegerLite divisor)
    //{
    //    BigIntegerLite quotient, remainder;
    //    dividend.Divide(divisor, out quotient, out remainder);
    //    return quotient;
    //}
    //public static BigIntegerLite operator *(BigIntegerLite left, BigIntegerLite right)
    //{
    //    BigIntegerLite result = new BigIntegerLite(new byte[] { 0 });
    //    result.Multiply(left);
    //    result.Multiply(right);
    //    return result;
    //}
//    public bool IsZero()
//    {
//        return bytes.Count == 1 && bytes[0] == 0;
//    }
//    public static BigIntegerLite Pow(int baseValue, int exponent)
//    {
//        BigIntegerLite result = new BigIntegerLite(new byte[] { 1 });

//        for (int i = 0; i < exponent; i++)
//            result.Multiply(new BigIntegerLite(new byte[] { (byte)baseValue }));

//        return result;
//    }
//    public void Divide(BigIntegerLite divisor, out BigIntegerLite quotient, out BigIntegerLite remainder)
//    {
//        if (divisor.IsZero())
//            throw new DivideByZeroException();

//        BigIntegerLite dividend = new BigIntegerLite(bytes.ToArray());
//        quotient = new BigIntegerLite();
//        remainder = new BigIntegerLite();

//        while (dividend >= divisor)
//        {
//            int shift = 0;
//            BigIntegerLite tempDivisor = divisor;

//            while (dividend >= (tempDivisor << 1))
//            {
//                tempDivisor <<= 1;
//                shift++;
//            }

//            dividend -= tempDivisor;
//            quotient += BigIntegerLite.Pow(2, shift);
//        }

//        remainder = dividend;
//    }
//    public static bool operator <=(BigIntegerLite left, BigIntegerLite right)
//    {
//        if (left == right)
//            return true;

//        if (left.bytes.Count < right.bytes.Count)
//            return true;

//        if (left.bytes.Count > right.bytes.Count)
//            return false;

//        for (int i = left.bytes.Count - 1; i >= 0; i--)
//        {
//            if (left.bytes[i] < right.bytes[i])
//                return true;

//            if (left.bytes[i] > right.bytes[i])
//                return false;
//        }

//        return true;
//    }
//    private void LeftShift(int shift)
//    {
//        int byteShift = shift / 8;
//        int bitShift = shift % 8;

//        for (int i = 0; i < byteShift; i++)
//        {
//            bytes.Insert(0, 0);
//        }

//        byte carry = 0;
//        for (int i = bytes.Count - 1; i >= 0; i--)
//        {
//            byte temp = (byte)(bytes[i] << bitShift);
//            bytes[i] = (byte)(temp | carry);
//            carry = (byte)(temp >> 8);
//        }

//        if (carry > 0)
//        {
//            bytes.Insert(0, carry);
//        }
//    }
//    public static BigIntegerLite operator <<(BigIntegerLite value, int shift)
//    {
//        BigIntegerLite result = new BigIntegerLite();
//        result.bytes.AddRange(value.bytes);
//        result.LeftShift(shift);
//        return result;
//    }

    
//    public static bool operator >=(BigIntegerLite left, BigIntegerLite right)
//    {
//        if (left.bytes.Count > right.bytes.Count)
//            return true;
//        if (left.bytes.Count < right.bytes.Count)
//            return false;

//        for (int i = left.bytes.Count - 1; i >= 0; i--)
//        {
//            if (left.bytes[i] > right.bytes[i])
//                return true;
//            if (left.bytes[i] < right.bytes[i])
//                return false;
//        }

//        return true; // Equal case
//    }
//}
class Program
{
    static void Main(string[] args)
    {
        BigIntegerLite num1 = new BigIntegerLite(new byte[] { 1, 2, 3 });
        BigIntegerLite num2 = new BigIntegerLite(new byte[] { 4, 5, 6 });

        //num1.Add(num2);

        Console.WriteLine((num1 + num2).ToString()); // Output: Sum: 566
        Console.WriteLine((num2 - num1).ToString()); // Output: Sum: 333
        //Console.WriteLine((num1 * num2).ToString()); // Output: Sum: 56 088
        //Console.WriteLine((num1 - num2).ToString());
    }
}
}




