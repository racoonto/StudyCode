using System;
using System.Collections.Generic;
using System.Text;

namespace mudgame
{
    internal class Monster
    {
        private static Random random = new Random();
        private static int idTotal;

        public int id;
        public string name;
        public int power;
        public int hp;

        public Monster()
        {
            id = ++idTotal;

            name = "몬스터" + id;
            power = random.Next(1, 2);
            hp = random.Next(1, 2);
        }
    }
}