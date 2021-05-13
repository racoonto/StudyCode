using System;
using System.Collections.Generic;
using System.Text;

namespace harrypotter
{
    public class User
    {
        private string userName;
        public int power = 0;
        public int maxHp = 0;
        public int hp = 50;
        public int defense = 0;
        public int level = 1;
        public int exp = 0; // 경험치
        public int MaxMana = 100;
        public int mana = 100; // 마나
        public List<string> magicspell = new List<string>();
        public List<Item> item = new List<Item>();

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

        internal void GetExp(int getExp)
        {
            exp += getExp;

            if (exp >= level * 10)
            {
                //레벨얼
                level++;
                exp = 0;
                power += 3;
                defense += 1;
                maxHp += 5;
                MaxMana += 5;

                //hp = maxHp;
                //mana = MaxMana;

                Console.WriteLine($"{DisplayName}님이 레벨업했습니다!! Level: {level}");
            }
        }

        //internal void RestoreHp()
        //{
        //    if (item.Count > 0)
        //    {
        //        if (hp < maxHp)
        //            hp += 5;
        //        if (mana < MaxMana)
        //            mana += 15;
        //    }
        //}
    }
}