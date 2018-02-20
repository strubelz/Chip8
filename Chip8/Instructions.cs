using System;
using System.Runtime.CompilerServices;

namespace Chip8
{
    class Instructions
    {
        static Random rand = new Random();
        static byte[] randArr = new byte[1];

        //TODO refactor bytes (should be done)
        //set these values everytime before executing an instruction
        public static byte n1;
        public static byte n2;
        public static byte n3;
        public static byte n4;

        public static byte a;
        public static byte b;

        //needs to be initialized in Proram befor executing the first instruction
        public static EmuState State;

        //should never be called, is just there for completness
        public static void SYS_addr()
        {
            //TODO implement logging
            throw new NotImplementedException("this method should never be called");
        }

        public static void CLS()
        {
            throw new NotImplementedException("//TODO display not implemented");
        }

        public static void RET()
        {
            State.PC = State.stack.Pop();
        }

        public static void JP_addr()
        {
            State.PC = Decoder.BytesToShort(n2, b);
            Program.skip_PC_inc = true;
        }

        public static void CALL_addr()
        {
            State.stack.Push(State.PC);
            State.PC = Decoder.BytesToShort(n2, b);
            Program.skip_PC_inc = true;
        }

        public static void SE_Vx_byte()
        {
            if (State.V[n2] == b)
                State.PC += 2;
        }

        public static void SNE_Vx_byte()
        {
            if (State.V[n2] != b)
                State.PC += 2;
        }

        public static void SE_Vx_Vy()
        {
            if (State.V[n2] == State.V[n3])
                State.PC += 2;
        }

        public static void LD_Vx_byte()
        {
            State.V[n2] = b;
        }

        public static void ADD_Vx_byte()
        {
            State.V[n2] = (byte)(State.V[n2] + b);
        }

        public static void LD_Vx_Vy()
        {
            State.V[n2] = State.V[n3];
        }

        public static void OR_Vx_Vy()
        {
            State.V[n2] = (byte)(State.V[n2] | State.V[n3]);
        }

        public static void AND_Vx_Vy()
        {
            State.V[n2] = (byte)(State.V[n2] & State.V[n3]);
        }

        public static void XOR_Vx_Vy()
        {
            State.V[n2] = (byte)(State.V[n2] ^ State.V[n3]);
        }

        public static void ADD_Vx_Vy()
        {
            int result = State.V[n2] + State.V[n3];
            State.V[n2] = (byte)result;

            if (result > byte.MaxValue)
                State.V[0xF] = 1;
        }

        public static void SUB_Vx_Vy()
        {
            State.V[n2] = (byte)(State.V[n2] - State.V[n3]);

            if (State.V[n2] > State.V[n3])
                State.V[0xF] = 1;
        }

        public static void SHR_Vx()
        {
            State.V[n2] = (byte)(State.V[n2] / 2);

            if ((State.V[n2] & 1) == 1)          //check rightmost bit
                State.V[0xF] = 1;
        }

        public static void SUBN_Vx_Vy()
        {
            State.V[n2] = (byte)(State.V[n3] - State.V[n2]);

            if (State.V[n3] > State.V[n2])
                State.V[0xF] = 1;

        }

        public static void SHL_Vx()
        {
            State.V[n2] = (byte)(State.V[n2] * 2);

            if ((State.V[n2] & 0b1000_0000) >> 7 == 1)           //check leftmost bit
                State.V[0xF] = 1;
        }

        public static void SNE_Vx_Vy()
        {
            if (State.V[n2] != State.V[n3])
                State.PC += 2;
        }

        public static void LD_I_addr()
        {
            State.I = Decoder.BytesToShort(n2, b);
        }

        public static void JP_V0_addr()
        {
            State.PC += (ushort)(Decoder.BytesToShort(n2, b) + State.V[0]);
        }

        public static void RND_Vx_kk()
        {
            rand.NextBytes(randArr);
            State.V[n2] = randArr[0];
        }

        //TODO implement display
        public static void DRW_Vx_Vy_nibble()
        {
            throw new NotImplementedException("Display not implemented");
        }

        //TODO implement keyboard
        public static void SKP_Vx()
        {
            throw new NotImplementedException("Keyboard not implemented");
        }

        //TODO implement keyboard
        public static void SKNP_Vx()
        {
            throw new NotImplementedException("Keyboard not implemented");
        }

        public static void LD_Vx_DT()
        {
            State.V[n2] = State.DT;
        }
    }
}
