using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8
{
    [Serializable]
    struct EmuState
    {
        public byte[] mem;          //size 4096 (4kb)
        public byte[] V;            //registers (0-F)
        public UShortStack stack;   //size 16
        public ushort I;            //special register
        public byte ST;             //sound timer
        public byte DT;             //delay timer
        public byte SP;             //stack pointer         //currently unused
        public ushort PC;           //program counter
    }
}
