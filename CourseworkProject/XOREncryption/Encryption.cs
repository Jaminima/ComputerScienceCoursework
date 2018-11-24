using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace XOREncryption
{
    public class Encryption
    {
        static Dictionary<string, BigInteger> TokenKeys = new Dictionary<string, BigInteger> { };
        public static string Encrypt(string sRaw, string Token)
        {
            BigInteger Key = TokenKeys[Token];
            int[] iRaw = Encryption.TextToBinary(sRaw), iKey = Encryption.IntToBinary(Key);
            int[] Enc = Encryption.XOR(iRaw, iKey);
            return Enc;
        }

        public static string Decrypt(string Enc, string Token)
        {
            BigInteger Key = TokenKeys[Token];
            string Raw = "";
            return Enc;
        }

        public static int[] TextToBinary(string Text)
        {
            byte[] BteArray = System.Text.Encoding.UTF8.GetBytes(Text);
            return BteArraytoBinArray(BteArray,true);
        }

        public static int[] IntToBinary(BigInteger Int)
        {
            byte[] BteArray = Int.ToByteArray();
            return BteArraytoBinArray(BteArray,false);
        }

        static int[] BteArraytoBinArray(byte[] BteArray,bool bReverse)
        {
            int[] BinArray = new int[BteArray.Length * 8];
            int BinArrayPos = 0;
            for (int i = 0; i < BteArray.Length; i++)
            {
                string BinBte = Reverse(Convert.ToString(BteArray[i], 2).PadLeft(8, '0'),bReverse);
                for (int q = 7; q >= 0; q--)
                { BinArray[BinArrayPos] = int.Parse(BinBte[q].ToString()); BinArrayPos++; }
            }
            return BinArray;
        }

        public static int[] XOR(int[] Text,int[] Key)
        {
            int[] Out = new int[Text.Length];int CText,CKey;
            for (int i = 0; i < Text.Length; i++)
            {
                CText = Text[i]; CKey = Key[i % Key.Length];
                if (CText != CKey) { Out[i] = 1; }
                else { Out[i] = 0; }
            }
            return Out;
        }

        static string Reverse(string s,bool bReverse)
        {
            if (!bReverse) return s;
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
