using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8
{
    class Decoder
    {
        public static byte GetHigh(byte b)
        {
            return Convert.ToByte((b & 0xF0) >> 4);
        }

        public static byte GetLow(byte b)
        {
            return Convert.ToByte(b & 0x0F);
        }

        public static ushort BytesToShort(byte a, byte b)
        {
            return BitConverter.ToUInt16(new byte[] { a, b }, 0);
        }

        public static void Decode(byte a, byte b)
        {
            byte n1 = GetHigh(a);
            byte n2 = GetLow(a);
            byte n3 = GetHigh(b);
            byte n4 = GetLow(b);

            //set bytes in Instructions //TODO

            byte[] bytes = new byte[]{n1, n2, n3, n4};



            switch (Convert.ToInt32(n1))
            {
                case 0x00:
                    PatternTable.Table[bytes].Invoke();
                    break;

            }
        }
    }
}
