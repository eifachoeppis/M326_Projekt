using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_Projekt.Model
{
    public class PlayingField
    {
        public event Action<NodeStateEnum> millComplete;
        public Node[] Nodes { get; set; }
        public Line[] Lines { get; set; }

        public PlayingField()
        {
            Nodes = new Node[24];
            Lines = new Line[16];
            Initialize();
        }

        public void InsertNode(int position, NodeStateEnum player)
        {
            if (player == NodeStateEnum.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(player));
            }

            if (position < 0 || position > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            if (Nodes[position].State != NodeStateEnum.Empty)
            {
                throw new InvalidOperationException("Node has already been taken");    
            }

            Nodes[position].State = player;

            if (CheckForMill(position))
            {
                millComplete?.Invoke(player);
            }
        }

        private bool CheckForMill(int position)
        {
            var linesToCheck = Lines.Where(l => l.Nodes.Any(n => n.Position == position));
            if (position < 0 || position > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }
            
            if (Nodes[position].State == NodeStateEnum.Empty)
            {
                return false;
            }

            return linesToCheck.Any(l => l.CheckForMill());
        }

        public void Render()
        {
            Nodes[0].Render();
            Console.Write("\t\t\t");
            Nodes[1].Render();
            Console.Write("\t\t\t");
            Nodes[2].Render();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
            Console.Write("\t");
            Nodes[8].Render();
            Console.Write("\t\t");
            Nodes[9].Render();
            Console.Write("\t\t");
            Nodes[10].Render();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
            Console.Write("\t\t");
            Nodes[16].Render();
            Console.Write("\t");
            Nodes[17].Render();
            Console.Write("\t");
            Nodes[18].Render();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
            Nodes[7].Render();
            Console.Write("\t");
            Nodes[15].Render();
            Console.Write("\t");
            Nodes[23].Render();
            Console.Write("\t\t");
            Nodes[19].Render();
            Console.Write("\t");
            Nodes[11].Render();
            Console.Write("\t");
            Nodes[3].Render();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
            Console.Write("\t\t");
            Nodes[22].Render();
            Console.Write("\t");
            Nodes[21].Render();
            Console.Write("\t");
            Nodes[20].Render();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
            Console.Write("\t");
            Nodes[14].Render();
            Console.Write("\t\t");
            Nodes[13].Render();
            Console.Write("\t\t");
            Nodes[12].Render();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
            Nodes[6].Render();
            Console.Write("\t\t\t");
            Nodes[5].Render();
            Console.Write("\t\t\t");
            Nodes[4].Render();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}");
        }

        private void Initialize()
        {
            for (int i = 0; i < Nodes.Length; i++)
            {
                Nodes[i] = new Node
                {
                    Position = i,
                    State = NodeStateEnum.Empty
                };
            }

            int count = 0;

            for (int i = 0; i < Nodes.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Lines[count] = new Line
                    {
                        Nodes = new Node[]
                        {
                            Nodes[(i + 22) % 24],
                            Nodes[(i + 23) % 24],
                            Nodes[i]
                        }
                    };
                    count++;
                }
            }

            Lines[12] = new Line
            {
                Nodes = new Node[]
                {
                    Nodes[1],
                    Nodes[9],
                    Nodes[17]
                }
            };
            Lines[13] = new Line
            {
                Nodes = new Node[]
                {
                    Nodes[3],
                    Nodes[11],
                    Nodes[19]
                }
            };
            Lines[14] = new Line
            {
                Nodes = new Node[]
                {
                    Nodes[5],
                    Nodes[13],
                    Nodes[21]
                }
            };
            Lines[15] = new Line
            {
                Nodes = new Node[]
                {
                    Nodes[7],
                    Nodes[15],
                    Nodes[23]
                }
            };
        }
        
    }
}
