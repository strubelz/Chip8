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
        ulong lastTimestamp = 0;
        ulong lastTimerTimestamp = 0;
        int frequency = 500;                             //frequency in Hz
        int timer_frequency = 60;

        static void Main(string[] args)
        {
            Instructions.State = new EmuState();

            //initialize state
            Instructions.State.V = new byte[16];
            Instructions.State.stack = new UShortStack();
            Instructions.State.I = 0;
            Instructions.State.ST = 0;
            Instructions.State.DT = 0;
            Instructions.State.SP = 0;
            Instructions.State.PC = 0x200;               //start of useable memory

            
            if (!(args.Length >= 1)
            {
                throw new NotImplementedException("No input specified");
                return;
            }

            //load code into memory
            byte[] bytes = Files.ReadAllBytes(args[0]);
            
            ushort offset = 0x200;                       //start of useable memory
            for (int i = 0; i < bytes.Length; i++)
            {
                Instructions.State.mem[offset + i] = bytes[i];
            }
            
            lastTimestamp = DateTime.Now;
            lastTimerTimestamp = DateTime.Now;
            while (true)
            {

                if (( DateTime.Now - lastTimestamp ) >= ( 1/timer_frequency ))
                {
                    if (Instructions.State.DT != 0)
                        Instructions.State.DT -= 1;
                    
                    if (Instructions.State.ST != 0)
                        Instructions.State.ST -= 1;

                    lastTimerTimestamp = DateTime.Now;
                }

                if (( DateTime.Now - lastTimestamp ) >= ( 1/frequency ))
                {
                    Decoder.Decode(Instructions.State.PC, Instructions.State.PC + 1);
                    Instructions.State.PC += 2;
                    lastTimestamp = DateTime.Now;
                }
            }
        }
    }
}
