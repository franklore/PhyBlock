using System;
using System.Collections.Generic;

namespace PhyBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            PhyBlockGrid Grid = new PhyBlockGrid(15);
            Grid.Start();
            Grid.AddBlock(7, 7, new EnergyBlock(7, 7));
            while (true)
            {
                Console.ReadLine();
                Grid.Update();
                Grid.Print();
            }
        }
    }
}
