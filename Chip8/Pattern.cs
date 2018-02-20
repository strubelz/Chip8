using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8
{
    class Pattern
    {
        private byte n1;
        private byte n2;
        private byte n3;
        private byte n4;

        public Pattern(byte n1, byte n2, byte n3, byte n4)
        {
            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
            this.n4 = n4;
        }
    }
}
