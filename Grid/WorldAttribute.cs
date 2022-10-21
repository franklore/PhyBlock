using System;
using System.Collections.Generic;
using System.Text;

namespace PhyBlock
{
    class WorldAttribute
    {
        public float DiffuseFactor;

        private static WorldAttribute _Instance;

        public static WorldAttribute Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new WorldAttribute();
                    _Instance.ReadConfig();
                }
                return _Instance;
            }
        }

        private void ReadConfig()
        {
            DiffuseFactor = 0.01f;
        }
    }
}
