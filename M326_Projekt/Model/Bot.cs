using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_Projekt.Model
{
    public class Bot : Player
    {
        static Random random = new Random();

        public Bot()
        {
            Name = "Computer";
        }

        public override int MakeMove(PlayingField field, NodeStateEnum player)
        {
            NodeStateEnum enemy = player == NodeStateEnum.PlayerA ? NodeStateEnum.PlayerB : NodeStateEnum.PlayerA;

            // strategy 1
            var line1 = field.Lines.FirstOrDefault(l => l.Nodes.Where(n => n.State == player).Count() == 2 && l.Nodes.Any(n => n.State == NodeStateEnum.Empty));

            if (line1 != null)
            {
                return line1.Nodes.First(n => n.State == NodeStateEnum.Empty).Position;
            }

            // strategy 2
            var line2 = field.Lines.FirstOrDefault(l => l.Nodes.Where(n => n.State == enemy).Count() == 2 && l.Nodes.Any(n => n.State == NodeStateEnum.Empty));

            if (line2 != null)
            {
                return line2.Nodes.First(n => n.State == NodeStateEnum.Empty).Position;
            }

            // strategy 3
            var line3 = field.Lines.FirstOrDefault(l => l.EmptyNodesLeft() == 2 && l.Nodes.Any(n => n.State == player));

            if (line3 != null)
            {
                return line3.Nodes.First(n => n.State == NodeStateEnum.Empty).Position;
            }

            // strategy 4
            var nodes = field.Nodes.Where(n => n.State == NodeStateEnum.Empty).ToList();

            return nodes.ElementAt(random.Next(nodes.Count)).Position;

        }
    }
}
