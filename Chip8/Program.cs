using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8
{
    class Program
    {

        public static bool skip_PC_inc = false;

        static void Main(string[] args)
        {
            EmuState State = new EmuState();

            //initialize state
            State.V = new byte[16];
            State.stack = new UShortStack();
            State.I = 0;
            State.ST = 0;
            State.DT = 0;
            State.SP = 0;
            State.PC = 0x200;               //start of useable memory

            Instructions.State = State;
        }
    }
}
