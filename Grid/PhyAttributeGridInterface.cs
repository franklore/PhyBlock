using System;
using System.Collections.Generic;
using System.Text;

namespace PhyBlock
{
    public interface PhyAttributeGridInterface
    {
        float GetFloat(int x, int y, int i);

        int GetInt(int x, int y, int i);

        double GetDouble(int x, int y, int i);

        void SetFloat(int x, int y, int i, float Value);

        void SetInt(int x, int y, int i, int Value);

        void SetDouble(int x, int y, int i, double Value);
    }
}
