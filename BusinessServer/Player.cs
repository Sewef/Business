using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServer
{

    class Player
    {
        private int money;
        private int numCase;
        private State state;
        private string color;

        public Player()
        {
            this.color = getRandomColor();
            this.money = 25000;
            this.state = State.STATE_NORMAL;
        }

        public string getColor()
        {
            return this.color;
        }

        public int getMoney()
        {
            return this.money;
        }

        public void setMoney(int amount)
        {
            this.money = amount;
        }

        public void addMoney(int amount)
        {
            this.money += amount;
        }

        public int getCase()
        {
            return this.numCase;
        }

        public void setCase(int newCase)
        {
            this.numCase = newCase;
        }

        public enum State: ushort
        {
            STATE_NORMAL,
            STATE_JAIL,
        };

        public State getState()
        {
            return this.state;
        }

        public void setState(State state)
        {
            this.state = state;
        }

        private string getRandomColor()
        {
            string[] lines = Properties.Resources.colorsList.Split(';');
            return lines[Globals.rng.Next(lines.Length)];
        }
    }
}
