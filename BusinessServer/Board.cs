using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServer
{
    class Board
    {
        public ushort size = 32;

        private ushort jail = 8;
        private boardCase[] currentBoard;

        private struct boardCase
        {
            public bool isBonus;
            private bool isProtected;
        }

        public Board()
        {
            this.currentBoard = new boardCase[size];
            populateBoard();
        }

        private void populateBoard()
        {
            int i = 0;
            do
            {
                int random = Globals.rng.Next(this.size)+1;
                if (!currentBoard[random].isBonus)
                {
                    currentBoard[random].isBonus = true;
                    i++;

                    Console.WriteLine("Case {0} is bonus", random);
                }
            } while (i < 3);
        }

        public int getJailCase()
        {
            return this.jail;
        }
    }
}
