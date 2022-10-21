using System;
using System.Collections.Generic;
using System.Text;

namespace PhyBlock
{
    public class PhyAttributeGrid : PhyAttributeGridInterface
    {
        float[,,] FloatAttribute;

        int Size = 15;

        int AttributeCount = 4;

        public PhyAttributeGrid(int Size)
        {
            this.Size = Size;
            FloatAttribute = new float[Size, Size, AttributeCount];
        }

        bool CheckParam(int x, int y, int i)
        {
            return x >= 0 && x < Size && y >= 0 && y < Size && i >= 0 && i <= AttributeCount;
        }

        public double GetDouble(int x, int y, int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int x, int y, int i)
        {
            if (CheckParam(x, y, i))
            {
                return FloatAttribute[x, y, i];
            }
            else
            {
                return 0;
            }
        }

        public int GetInt(int x, int y, int i)
        {
            throw new NotImplementedException();
        }

        public void SetDouble(int x, int y, int i, double Value)
        {
            throw new NotImplementedException();
        }

        public void SetFloat(int x, int y, int i, float Value)
        {
            if (CheckParam(x, y, i))
            {
                FloatAttribute[x, y, i] = Value;
            }
        }

        public void SetInt(int x, int y, int i, int Value)
        {
            throw new NotImplementedException();
        }
    }
}
