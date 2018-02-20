using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8
{
    class PatternTable
    {
        public static Dictionary<byte[], Action> Table = new Dictionary<byte[], Action>();

        static PatternTable()
        {
            //0xFF is a placeholder for any number
            //only the last four bits of any byte are used

            Table.Add(new byte[]{0x00, 0xFF, 0xFF, 0xFF}, null);
            Table.Add(new byte[]{0x00, 0x00, 0x0E, 0x00}, () => Instructions.CLS());
        }

    }
}
