using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_Projekt.Model
{
    public abstract class Player
    {
        public string Name { get; protected set; }
        public abstract int MakeMove(PlayingField field);
    }
}
