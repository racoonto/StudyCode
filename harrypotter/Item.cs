using System;
using System.Collections.Generic;
using System.Text;

namespace harrypotter
{
    public class Item
    {
        private static Random random = new Random();
        private static int idTotal;

        public int id;
        public string name;
        public int recovery;

        public Item()
        {
            id = ++idTotal;

            name = "회복 아이템" + id;
            recovery = random.Next(10, 20);
        }

        //virtual public void OnRecovery(User user)
        //{
        //    user.hp += recovery;
        //    Console.WriteLine($"HP 가 회복되었습니다. HP: {user.hp}");
        //}
    }
}