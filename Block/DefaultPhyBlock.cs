using System;
using System.Collections.Generic;
using System.Text;

namespace PhyBlock
{
    class DefaultPhyBlock : PhyBlockBase
    {
        public DefaultPhyBlock(int x, int y) : base(x, y)
        {

        }

        public override void Update(PhyBlockGrid Grid)
        {
            float v = Grid.GetFloat(x, y, 0);
            if (v > 0)
            {
                Grid.AddFloat(x, y, 0, -v * 0.5f);
                Grid.AddFloat(x + 1, y, 0, v * 0.125f);
                Grid.AddFloat(x - 1, y, 0, v * 0.125f);
                Grid.AddFloat(x, y + 1, 0, v * 0.125f);
                Grid.AddFloat(x, y - 1, 0, v * 0.125f);
            }
        }
    }
}
