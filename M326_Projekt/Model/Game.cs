using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_Projekt.Model
{
    public class Game
    {
        int moves = 9;

        Player player1;
        Player player2;
        int player1Score;
        int player2Score;
        PlayingField field;

        public string Score
        {
            get
            {
                return $"{player1.Name} {player1Score} : {player2Score} {player2.Name}\n";
            }
        }

        public Game(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            field = new PlayingField();
            field.millComplete += (player) =>
            {
                if (player == NodeStateEnum.PlayerA)
                {
                    player1Score++;
                }
                else
                {
                    player2Score++;
                }
            };
        }


        public void Start()
        {
            try
            {
                for (int i = 0; i < moves; i++)
                {
                    Render();
                    field.InsertNode(player1.MakeMove(field, NodeStateEnum.PlayerA), NodeStateEnum.PlayerA);
                    Render();
                    field.InsertNode(player2.MakeMove(field, NodeStateEnum.PlayerB), NodeStateEnum.PlayerB);
                    Render();
                }

                Console.Clear();
                if (player1Score == player2Score)
                {
                    Console.WriteLine("Unentschieden");
                }
                else if (player1Score > player2Score)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($@"
                                                                                               %   
   @@,  /@,  @@,,,,  &@    &@@    @@   @@, .@@*   @@@    @%  ,@@/    @   @@,,,,   @@@    &%   .@   
 *@          @@       @(   @.@   .@  .@      *@,  @.@@   @%  ,@ @%   @   @@       @(@@   &%    @   
 @@   %%%%   @@@@@@   /@  (& &&  @#  %@       @%  @. #@  @%  ,@  @%  @   @@@@@@   @( #@  &%    @   
 @@      @,  @@        @( @   @..@   (@       @/  @.  (@ @%  ,@   @@ @   @@       @(  ,@ &%    @   
  @@     @,  @@        .@%@   &@@,    @@     @@   @.   *@@%  ,@    @@@   @@       @(   *@@%        
    ,&@@%    /%%%%%*    #%     %%       #@@&*     %      %.   %     ,%   /%%%%%*  %*     %.   .@   

");
                }
                else
                {
                    Console.WriteLine($"{player2.Name} hat gewonnen");
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invalid move. You lost!");
            }
        }

        private void Render()
        {
            Console.Clear();
            Console.WriteLine(Score);
            field.Render();
        }
    }
}
