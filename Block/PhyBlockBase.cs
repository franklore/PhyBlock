using System;
using System.Collections.Generic;
using System.Text;

namespace PhyBlock
{
    public abstract class PhyBlockBase
    {
        public int x, y;

        public PhyBlockBase(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract void Update(PhyBlockGrid Grid);
    }
}
