using System;
using System.Collections.Generic;
using System.Text;

namespace harrypotter
{
    internal class Monster
    {
        private static Random random = new Random();
        private static int idTotal;

        public int id;
        public string name;
        public int power;
        public int hp;

        public Monster(int Level)
        {
            id = ++idTotal;

            name = "몬스터" + id;
            power = random.Next(1, 2);
            hp = random.Next(1, 2) + Level;
        }

        virtual public void OnAttack(User targetPlayer)
        {
            targetPlayer.hp -= power;
            Console.WriteLine($"{name}의 공격으로 {targetPlayer.DisplayName}의 체력은 {targetPlayer.hp}가 되었다");
        }
    }
}