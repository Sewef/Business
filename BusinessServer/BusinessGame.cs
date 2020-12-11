using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServer
{
    class BusinessGame
    {
        private Board board;
        private Player[] players;
        private ushort playersCount;
        private int roundCount = 0;

        private int diceSize = 6;

        public BusinessGame(ushort playersCount)
        {
            this.board = new Board();
            this.playersCount = playersCount;
        }

        public void play()
        {
            players = new Player[playersCount];
            for (ushort i=0; i<playersCount; i++)
                players[i] = new Player();

            while (true)
            {
                doRound();
                Console.Read();
                Console.Read();
            }
        }

        private void doRound()
        {
            roundCount++;
            Console.WriteLine(new String('-', 40));
            Console.WriteLine("Round {0}", roundCount);
            foreach (Player player in players)
            {
                doTurn(player);
            }
        }

        private void doTurn(Player player)
        {
            int[] dices;

            if (player.getState() == Player.State.STATE_NORMAL)
            {
                int i = 0;
                do
                {
                    dices = new int[] { Globals.rng.Next(diceSize) + 1, Globals.rng.Next(diceSize) + 1 };

                    if (dices[0] == dices[1])
                        i++;

                    if (i == 3)
                    {
                        Console.WriteLine("Player {0}: {1} and {2}, 3 doubles, go to jail", player.getColor(), dices[0], dices[1]);
                        player.setCase(board.getJailCase());
                        player.setState(Player.State.STATE_JAIL);
                    }
                    else
                    {
                        int newCase = player.getCase() + dices[0] + dices[1];
                        if (newCase >= board.size)
                            newCase -= board.size;
                        player.setCase(newCase);
                        Console.WriteLine("Player {0}: {1} and {2}, go to {3}", player.getColor(), dices[0], dices[1], player.getCase());
                    }

                } while (dices[0] == dices[1] && i < 3);
            }
            else if (player.getState() == Player.State.STATE_JAIL)
            {
                Console.WriteLine("Player {0}: In jail", player.getColor());
            }

        }
    }
}
