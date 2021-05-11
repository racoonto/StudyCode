using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCode02
{
    internal class Player
    {
        public string userName;
        public int power;
        public int hp;
        private int maxHp = 10;

        public Player(string _userName, int power, int mapHp)
        {
            userName = _userName;
            this.power = power;
            maxHp = mapHp;
            this.hp = maxHp;
        }

        internal void RestoreHp()
        {
            if (hp < maxHp)
                hp++;
        }
    }
}