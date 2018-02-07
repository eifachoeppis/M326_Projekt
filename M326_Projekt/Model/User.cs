using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_Projekt.Model
{
    public class User : Player
    {
        public User(string name)
        {
            Name = name;
        }

        public override int MakeMove(PlayingField field)
        {
            Console.Write("Position: ");
            var input = Console.ReadLine();

            int position;
            if(!Int32.TryParse(input, out position))
            {
                throw new ArgumentException("Enter valid Coordinate");
            }
            
            return position;
        }
    }
}
