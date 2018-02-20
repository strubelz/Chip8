using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8
{
    [Serializable]
    class UShortStack
    {
        private ushort[] stack = new ushort[16];
        private short stackPointer = -1;

        public void Push(ushort s)
        {
            if (stackPointer == (stack.Length - 1))
            {
                throw new NotImplementedException("//TODO: log error");
                return;
            }
            stackPointer++;
            stack[stackPointer] = s;
        }

        public ushort Pop()
        {
            if (stackPointer == -1)
            {
                throw new NotImplementedException("//TODO: log error");
                return 0;
            }
            ushort s = stack[stackPointer];
            stackPointer--;
            return s;
        }

        public ushort Peek()
        {
            if (stackPointer == -1)
            {
                throw new NotImplementedException("//TODO: log error");
                return 0;
            }
            return stack[stackPointer];
        }
    }
}
