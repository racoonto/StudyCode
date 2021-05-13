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
            power = random.Next(5, 15);
            hp = random.Next(15, 20) + Level;
        }

        virtual public void OnAttack(User targetPlayer)
        {
            targetPlayer.hp -= power;
            Console.WriteLine($"{name}이 공격했습니다! {targetPlayer.DisplayName}님의 HP: {targetPlayer.hp}가 되었습니다.\n");
        }

        virtual public void OnHit(User user, int damage, int dePower, int userMana)
        {
            if (damage > 0)
            {
                Console.WriteLine($"몬스터가 {damage}만큼 타격을 입었습니다");
            }
            if (dePower > 0)
            {
                Console.WriteLine($"몬스터가 무장해제를 당했습니다. 몬스터의 공격력이 {dePower} 만큼 깍였습니다.");
            }

            hp -= damage;
            power -= dePower;
            user.mana -= userMana;

            if (power < 0)
            {
                power = 0; // 몬스터의 공격력이 0보다 작으면 값은 0 고정
            }
        }

        public class Troll : Monster
        {
            public Troll(int Level) : base(Level)
            {
                name = "트롤";
                power += Level;
            }

            public override void OnAttack(User user)
            {
                power -= user.defense; //공격력에서 유저의 방어값을 뺀다.
                if (power > 0)
                {
                    user.hp -= power;
                    Console.WriteLine($"{name}의 공격으로 {user.DisplayName}의 체력은 {user.hp}가 되었습니다.");
                }
                else
                {
                    Console.WriteLine($"{name}의 공격은 먹히지 않았습니다.\n망토가 공격을 막아준 듯 하다.");
                }
            }
        }
    }
}