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
            string first =  " |                       |                       |";
            string second = " |       |               |               |       |";
            string third =  " |       |       |               |       |       |";

            Nodes[0].Render();
            Console.Write(new string('-', 22));
            Nodes[1].Render();
            Console.Write(new string('-', 22));
            Nodes[2].Render();
            Console.WriteLine($"{Environment.NewLine}{first}{Environment.NewLine}{first}");
            Console.Write(" |      ");
            Nodes[8].Render();
            Console.Write(new string('-', 14));
            Nodes[9].Render();
            Console.Write(new string('-', 14));
            Nodes[10].Render();
            Console.Write("       |");
            Console.WriteLine($"{Environment.NewLine}{second}{Environment.NewLine}{second}");
            Console.Write(" |       |      ");
            Nodes[16].Render();
            Console.Write(new string('-', 6));
            Nodes[17].Render();
            Console.Write(new string('-', 6));
            Nodes[18].Render();
            Console.Write("       |       |");
            Console.WriteLine($"{Environment.NewLine}{third}{Environment.NewLine}{third}");
            Nodes[7].Render();
            Console.Write(new string('-', 6));
            Nodes[15].Render();
            Console.Write(new string('-', 6));
            Nodes[23].Render();
            Console.Write("\t\t");
            Nodes[19].Render();
            Console.Write(new string('-', 6));
            Nodes[11].Render();
            Console.Write(new string('-', 6));
            Nodes[3].Render();
            Console.WriteLine($"{Environment.NewLine}{third}{Environment.NewLine}{third}");
            Console.Write(" |       |      ");
            Nodes[22].Render();
            Console.Write(new string('-', 6));
            Nodes[21].Render();
            Console.Write(new string('-', 6));
            Nodes[20].Render();
            Console.Write("       |       |");
            Console.WriteLine($"{Environment.NewLine}{second}{Environment.NewLine}{second}");
            Console.Write(" |      ");
            Nodes[14].Render();
            Console.Write(new string('-', 14));
            Nodes[13].Render();
            Console.Write(new string('-', 14));
            Nodes[12].Render();
            Console.Write("       |");
            Console.WriteLine($"{Environment.NewLine}{first}{Environment.NewLine}{first}");
            Nodes[6].Render();
            Console.Write(new string('-', 22));
            Nodes[5].Render();
            Console.Write(new string('-', 22));
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
                    int index = (i + 22) % 24;

                    if (i % 8 == 0)
                    {
                        index = (index + 8) % 24;
                    }

                    Lines[count] = new Line
                    {
                        Nodes = new Node[]
                        {
                            Nodes[index],
                            Nodes[index + 1],
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
