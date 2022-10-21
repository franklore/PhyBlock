using System;
using System.Collections.Generic;
using System.Timers;
using System.Text;

namespace PhyBlock
{
    public class PhyBlockGrid
    {
        private PhyAttributeGridInterface AttrGridStable;

        private PhyAttributeGridInterface AttrGridDynamic;

        List<PhyBlockBase>[,] PhyBlocks;

        int Size;

        public PhyBlockGrid(int Size)
        {
            this.Size = Size;
        }

        public void Start()
        {
            AttrGridStable = new PhyAttributeGrid(Size);
            AttrGridDynamic = new PhyAttributeGrid(Size);
            PhyBlocks = new List<PhyBlockBase>[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    PhyBlocks[i, j] = new List<PhyBlockBase>();
                    PhyBlocks[i, j].Add(new DefaultPhyBlock(i, j));
                }
            }
        }

        public void Update()
        {
            System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
            Stopwatch.Start();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    foreach (PhyBlockBase Block in PhyBlocks[i, j])
                    {
                        Block.Update(this);
                    }
                }
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    AddFloat(i, j, 0, -WorldAttribute.Instance.DiffuseFactor);
                }
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    float Value = AttrGridDynamic.GetFloat(i, j, 0);
                    AttrGridStable.SetFloat(i, j, 0, Value);
                }
            }
            Stopwatch.Stop();
            Console.WriteLine("Elapsed Time: {0}ms", Stopwatch.ElapsedMilliseconds);
        }

        public void Print()
        {
            Console.Clear();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(FloatToVisibleChar(GetFloat(i, j, 0)));
                    //Console.Write("{0:0.000}", GetFloat(i, j, 0));
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }

        public string FloatToVisibleChar(float Value)
        {
            if (Value >= 1)
            {
                return "█ ";
            }
            else if (Value >= 7.0f / 8 && Value < 1)
            {
                return "▇ ";
            }
            else if (Value >= 6.0f / 8 && Value < 7.0f / 8)
            {
                return "▆ ";
            }
            else if (Value >= 5.0f / 8 && Value < 6.0f / 8)
            {
                return "▅ ";
            }
            else if (Value >= 4.0f / 8 && Value < 5.0f / 8)
            {
                return "▄ ";
            }
            else if (Value >= 3.0f / 8 && Value < 4.0f / 8)
            {
                return "▃ ";
            }
            else if (Value >= 2.0f / 8 && Value < 3.0f / 8)
            {
                return "▂ ";
            }
            else if (Value >= 1.0f / 8 && Value < 2.0f / 8)
            {
                return "▁ ";
            }
            else
            {
                return "..";
            }
        }

        public float GetFloat(int x, int y, int i)
        {
            return AttrGridStable.GetFloat(x, y, i);
        }

        public void AddFloat(int x, int y, int i, float Value)
        {
            float OldValue = AttrGridDynamic.GetFloat(x, y, i);
            AttrGridDynamic.SetFloat(x, y, i, Math.Max(OldValue + Value, 0));
        }

        public void AddBlock(int x, int y, PhyBlockBase Block)
        {
            PhyBlocks[x, y].Add(Block);
        }
    }
}
