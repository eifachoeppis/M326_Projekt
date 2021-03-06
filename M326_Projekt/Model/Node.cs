﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_Projekt.Model
{
    public class Node
    {
        public int Position { get; set; }
        public NodeStateEnum State { get; set; }

        public void Render()
        {
            switch (State)
            {
                case NodeStateEnum.PlayerA:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" X");
                    break;
                case NodeStateEnum.PlayerB:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" O");
                    break;
                default:
                    Console.Write($"{Position:D2}");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
