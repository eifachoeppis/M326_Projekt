﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_Projekt.Model
{
    public class Bot : Player
    {
        public Bot()
        {
            Name = "Computer";
        }

        public override int MakeMove(PlayingField field)
        {
            return field.Nodes.First(n => n.State == NodeStateEnum.Empty).Position;
        }
    }
}
