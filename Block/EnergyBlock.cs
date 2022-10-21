using System;
using System.Collections.Generic;
using System.Text;

namespace PhyBlock
{
    class EnergyBlock : PhyBlockBase
    {
        public EnergyBlock(int x, int y) : base(x, y)
        {
        }

        public override void Update(PhyBlockGrid Grid)
        {
            Grid.AddFloat(x, y, 0, 0.5f);
        }
    }
}
