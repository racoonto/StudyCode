using System;
using System.Collections.Generic;
using System.Text;

namespace harrypotter
{
    internal class User
    {
        private string userName;
        public int power;
        public int maxHp;
        public int hp = 0;
        public int defense = 0;
        public int level = 1;
        public int exp = 0;
        public int mana = 0;

        public string DisplayName
        {
            get { return $"({userName})"; }
        }

        public User(string userName, int power, int maxHp)
        {
            this.userName = userName;
            this.power = power;
            this.maxHp = maxHp;
        }
    }
}