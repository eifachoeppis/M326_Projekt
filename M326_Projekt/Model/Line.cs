using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_Projekt.Model
{
    public class Line
    {
        public Node[] Nodes { get; set; }

        public bool CheckForMill()
        {
            if (NodesHaveSameState())
            {
                if (Nodes[0].State != NodeStateEnum.Empty)
                {
                    return true;
                }
            }
            return false;
        }

        public bool NodesHaveSameState()
        {
            return Nodes[0].State == Nodes[1].State && Nodes[1].State == Nodes[2].State;
        }

        public int EmptyNodesLeft()
        {
            return Nodes.Count(n => n.State == NodeStateEnum.Empty);
        }
    }
}
