using System;
using System.Collections.Generic;
using System.Text;

namespace harrypotter
{
    internal class User
    {
        private string userName;
        public int power = 0;
        public int maxHp = 0;
        public int hp = 10;
        public int defense = 0;
        public int level = 1;
        public int exp = 0; // 경험치
        public int mana = 10; // 마나
        private List<int> magicspell = new List<int>();

        public string DisplayName
        {
            get { return $"{userName}"; }
        }

        public User(string userName, int power, int maxHp)
        {
            this.userName = userName;
            this.power = power;
            this.maxHp = maxHp;
        }
    }
}