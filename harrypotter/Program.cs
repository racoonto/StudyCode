using System;
using System.Collections.Generic;
using System.Threading;

namespace harrypotter
{
    internal class Program
    {
        public const string magic01 = "익스펙토 페트로눔";

        private static Random random = new Random();
        public static int mydelay = 500;
        //public static bool isRun = false;

        private static void Main(string[] args)
        {
            PlayGame();
        }

        private static bool PlayGame()
        {
            do
            {
                Print("호그와트로부터 초대장이 날아왔습니다! \n입학을 원하면 이름을 서명해주세요");

                String Username = Console.ReadLine();
                User user = new User(Username, 0, 50);
                user.hp = user.maxHp;
                user.mana = user.MaxMana;

                Print("\n---------------------------------------------------------\n");
                Print($"친해하는 {Username} 씨에게,");
                Print("귀하가 호그와트 마법학교에 입학하게 되었다는 걸 알려드리게 되어서 기쁩니다.");
                Print("필요한 모든 책과 비품의 목록을 동봉하니 참고하시기 바랍니다.");
                Print("학기는 9월 1일에 시작합니다. 7월 31일까지 당신의 부엉이를 기다리겠습니다");
                Print("안녕히 계십시오");
                Print("미네르바 맥고나걸 교감");
                Print("");
                Print("준비물");
                Print("1: 마법 지팡이");
                Print("2: 무늬 없는 긴 망토(검정색)");
                Print("3: 표준 마법서(1학년)");
                Print("\n---------------------------------------------------------\n");

                Print("초대장 닫기_ Press any key");
                Console.ReadKey();

                Print("\n\n준비물을 사기 위해 다이애건 앨리에 왔습니다.");
                do
                {
                    Print("1: 지팡이 구입하기 2: 망토 구입하기");

                    string userStoreInput = Console.ReadLine();
                    switch (userStoreInput)
                    {
                        case "1": //지팡이 선택 : 공격력 결정
                            string userWnad;
                            int power;
                            CreateNewWand(out userWnad, out power);
                            user.power = power;
                            //Print("유저의 공격력 : " + user.power + "유저의 방어력 : " + user.defense);
                            break;

                        case "2": // 망토 선택 : 방어력 결정

                            string userCloak;
                            int defense;
                            CreateNewCloak(out userCloak, out defense);
                            user.defense = defense;
                            //Print("유저의 공격력 : " + user.power + "유저의 방어력 : " + user.defense);
                            break;
                    }
                } while (user.power == 0 || user.defense == 0);

                Console.WriteLine("필요한 물품을 모두 구매했습니다! \n호그와트로 출발합니다!!");

                Print("호그와트행 급행열차에 탑승합니다_ Press any key");
                Console.ReadKey();

                Print("\n     칙\n");
                Thread.Sleep(mydelay);
                Print("     칙\n");
                Thread.Sleep(mydelay);
                Print("     폭\n");
                Thread.Sleep(mydelay);
                Print("     폭\n");

                Print("\n호그와트에 도착했습니다!!\n");
                Thread.Sleep(mydelay);
                Print("인적사항을 기록하고 모험을 시작합니다!!");
                Thread.Sleep(mydelay);
                Print($"이름 : " + user.DisplayName + " \n레벨 : " + user.level + " \n경험치 : " + user.exp + " \nHP : " + user.maxHp + " \n공격력 : " + user.power + " \n방어력 : " + user.defense + " \n마나 : " + user.mana);

                Print($"{user.DisplayName}님의 여정을 응원합니다! 확인[Press any key]");
                Console.ReadKey();
                //Console.WriteLine("List 테스트 " + magicspell.Contains("익스펙토 페트로눔"));

                List<string> magicspell = new List<string>();
                magicspell.Add("익스펙토 페트로눔");
                magicspell.Add("스투페파이");
                magicspell.Add("봄바르다");
                magicspell.Add("엑스펠리아루무스");

                while (true)
                {
                    Print("\n모험을 선택해주세요");
                    Print("1. 수업 듣기");
                    Print("2. 금지된 숲에서 사냥하기");

                    string slectAdvanture = Console.ReadLine();

                    if (slectAdvanture == "1") // 수업 듣기
                    {
                        if (magicspell.Count > 0)
                        {
                            //수업 목록 보여주기
                            Print("\n듣고 싶은 수업을 선택하세요!");

                            foreach (string spel in magicspell)
                            {
                                int index = magicspell.IndexOf(spel) + 1;
                                Print(index + $":{spel}");
                            }

                            int SelectClass = int.Parse(Console.ReadLine()) - 1; //수업 선택

                            user.magicspell.Add(magicspell[SelectClass]); //유저에게 추가
                            Thread.Sleep(mydelay);
                            Print("\n마법 [ " + magicspell[SelectClass] + " ] 을/를 배웠습니다! \n이제 [ " + magicspell[SelectClass] + " ] 을/를 쓸 수 있습니다.");

                            magicspell.Remove(magicspell[SelectClass]); //리스트에서 삭제

                            //foreach (string spel in user.magicspell)
                            //{
                            //    Console.WriteLine("유저가 배웠던 마법 리스트 = " + spel);
                            //}

                            //foreach (string spel in magicspell)
                            //{
                            //    Console.WriteLine("안배운 마법 = " + spel);
                            //}
                        }
                        else
                        {
                            Print("\n더 이상 배울 수 있는 과목이 없습니다!\n[Press any key]");
                            Console.ReadKey();
                        }
                    }

                    if (slectAdvanture == "2") //사냥 하기
                    {
                        Print("\n금지된 숲에 입장하셨습니다.");
                        Print("몬스터가 출몰합니다!!");
                        Thread.Sleep(mydelay);
                        //몬스터 생성
                        int monsterCount = random.Next(1, 3);
                        List<Monster> monsters = new List<Monster>();
                        for (int i = 0; i < monsterCount; i++)
                        {
                            monsters.Add(new Monster(user.level));
                        }

                        Print($"{monsterCount}마리의 몬스터가 나타났습니다!\n");
                        Thread.Sleep(mydelay);

                        while (monsters.Count > 0)
                        {
                            Print("몬스터의 정보");
                            foreach (var m in monsters)
                            {
                                PrintMonster(m);
                            }

                            Thread.Sleep(mydelay);
                            PrintUser(user); //유저 정보 출력

                            Thread.Sleep(mydelay);

                            bool playerRun = PlayerTurn(user, monsters); //유저 행동 선택
                            if (playerRun)
                                break;
                            //if (isRun == true)
                            //{
                            //    Print("도망에 성공했습니다!");
                            //}
                            //else
                            //{
                            //    Print("도망에 실패했습니다");
                            //}

                            Thread.Sleep(mydelay);
                            MonsterTurn(user, monsters); // 몬스터 공격

                            //유저의 피가 0이 되었다면
                            if (user.hp <= 0)
                            {
                                Print($"{user.DisplayName}님은 사망했습니다. 유령이 되어 호그와트를 떠돕니다.");
                                Print("처음부터 다시 시작하시겠습니까?(R)etry / (Q)uit");

                                bool isQuit = GetAllowedAnswer("R", "Q") == "Q";
                                return isQuit;
                            }
                        }

                        //isRun = false;
                        Print("금지된 숲을 빠져나왔습니다.\n[Press any key]");
                        Console.ReadKey();

                        Print($"\n{user.DisplayName}님의 체력과 마나가 모두 회복되었습니다");
                        user.hp = user.maxHp;
                        user.mana = user.MaxMana;
                    }
                }
            } while (true); // 무한 반복. 나가는 조건은 나갈 것인가 묻는 조건에 q라고 입력해야함.
        }

        private static void MonsterTurn(User user, List<Monster> monsters) // 몬스터 공격 턴
        {
            //몬스터 체력 회복
            foreach (var monster in monsters)
            {
                string log = monster.name.ToString();
                monster.hp += 1;
                Console.WriteLine($" 몬스터가 체력을 회복합니다. {log} 현재 HP : {monster.hp}");
                Thread.Sleep(mydelay);
            }

            //몬스터 공격
            foreach (var monster in monsters)
            {
                monster.OnAttack(user);
            }
        }

        private static bool PlayerTurn(User user, List<Monster> monsters) // 플레이어 공격 턴
        {
            bool actionFlag = false;
            while (!actionFlag)
            {
                Print("\n행동을 선택해주세요.");
                Print("1: 마법 공격  2: 회복 아이템 사용  3: 도망");
                char userInput = GetAllowedAnswer("1", "2", "3", "4")[0];

                switch (userInput)
                {
                    case '1': // 마법 공격
                        PlayerAttack(user, monsters); //유저 공격
                        actionFlag = true;
                        break;

                    case '2': // 회복
                        if (user.item.Count > 0)
                        {
                            if (user.hp == user.maxHp)
                            {
                                Print("이미 HP가 가득 차 있습니다.");
                                actionFlag = false;
                            }
                            else
                            {
                                user.hp += user.item[0].recovery;
                                //user.mana += user.item[0].recovery;
                                Print($"아이템을 사용했습니다. Hp가 회복됩니다. HP:{user.hp}/{user.maxHp}");
                                actionFlag = true;
                            }
                        }
                        else
                        {
                            Print("가지고 있는 포션이 없습니다.");
                            actionFlag = false;
                        }
                        break;

                    case '3': // 도망
                        int result = random.Next(0, 10);
                        bool successRun = result > 3;

                        string log;
                        if (successRun)
                            log = "성공적으로 도망쳤습니다";
                        else
                            log = "도망에 실패했습니다.";
                        Console.WriteLine(log);

                        return successRun;

                    default:
                        break;
                }
            }

            return false;
        }

        private static void PlayerAttack(User user, List<Monster> monsters)
        {
            //공격할 몬스터 선택
            Print("공격할 몬스터를 선택해주세요");
            List<string> allowedAnswer = new List<string>();
            for (int i = 0; i < monsters.Count; i++)
            {
                var m = monsters[i];
                int monsterNumber = i + 1;
                Print($"{monsterNumber} : {m.name} 공격력:{m.power}, 체력:{m.hp}");

                allowedAnswer.Add(monsterNumber.ToString());
            }

            string userInput = GetAllowedAnswer(allowedAnswer.ToArray()); //유저 입력 받기
            int userSelected = int.Parse(userInput) - 1;

            var selectedMonster = monsters[userSelected]; //선택한 몬스터

            bool IsAttacked = false;
            do
            {
                if (user.magicspell.Count == 0)
                {
                    //마법을 아직 배우지 않았다면
                    Print("배운 마법이 없습니다. 지팡이로 몬스터를 한대 칩니다. 공격력: 1");
                    selectedMonster.OnHit(user, 1, 0, 0);
                    break;
                }
                else
                {
                    Print("사용할 마법을 선택해 주세요");
                    Print("0:마법 정보 보기");
                    foreach (string spel in user.magicspell)
                    {
                        int index = user.magicspell.IndexOf(spel) + 1;
                        Print(index + $":{spel}");
                    }
                    String SelMagic = Console.ReadLine(); //사용할 마법 입력받기

                    String userMagic;

                    switch (SelMagic) //선택한 마법을 userMagic에 넣어준다. 숫자와 이름이 달라서.
                    {
                        case "0":
                            userMagic = null;
                            Print("[어둠의 마법 방어술 주문 목록]");
                            Print("\n익스펙토 페트로눔 - 공격력:10 소요마나:30");
                            Print("스투페파이 - 공격력:6 소요마나:18");
                            Print("봄바르다 - 공격력:8 소요마나:24");
                            Print("엑스펠리아루무스 - 공격력:0 소요마나:15(몬스터 무장해제, 몬스터의 공격력 -5)\n");

                            Print("확인[Press any key]\n");
                            Console.ReadKey();
                            break;

                        case "1":
                            userMagic = user.magicspell[0];
                            Print($"{user.DisplayName}" + " : " + $"{user.magicspell[0]}!!!");
                            break;

                        case "2":
                            userMagic = user.magicspell[1];
                            Print($"{user.DisplayName}" + " : " + $"{user.magicspell[1]}!!!");
                            break;

                        case "3":
                            userMagic = user.magicspell[2];
                            Print($"{user.DisplayName}" + " : " + $"{user.magicspell[2]}!!!");
                            break;

                        case "4":
                            userMagic = user.magicspell[3];
                            Print($"{user.DisplayName}" + " : " + $"{user.magicspell[3]}!!!");
                            break;

                        default:
                            userMagic = null;
                            break;
                    }

                    switch (userMagic) // 선택한 마법 실행
                    {
                        case "익스펙토 페트로눔":
                            MagicAttack(user, selectedMonster, 10, 0, 30);
                            IsAttacked = true;
                            break;

                        case "스투페파이":
                            MagicAttack(user, selectedMonster, 6, 0, 18);
                            IsAttacked = true;
                            break;

                        case "봄바르다":
                            MagicAttack(user, selectedMonster, 8, 0, 24);
                            IsAttacked = true;
                            break;

                        case "엑스펠리아루무스":
                            MagicAttack(user, selectedMonster, -user.power, 5, 15);
                            IsAttacked = true;
                            break;

                        default:
                            break;
                    }
                }
            } while (IsAttacked == false); //마법 정보보기때문. 공격을 한번 하면 빠져나감

            //몬스터가 죽었는지 확인
            onMonsterDie(user, monsters, selectedMonster);
        }

        private static void MagicAttack(User user, Monster selectedMonster, int power, int dePower, int mana)
        {
            if (user.mana > mana)
            {
                selectedMonster.OnHit(user, power + user.power, dePower, mana);
            }
            else
            {
                Print("마나가 부족해서 주문이 취소되었습니다.");
                Print("지팡이로 몬스터를 한대 칩니다.");
                selectedMonster.OnHit(user, 1, 0, 0);
            }
        }

        private static void onMonsterDie(User user, List<Monster> monsters, Monster monster)
        {
            if (monster.hp <= 0)
            {
                Print($"{monster.name}이 죽었습니다\n");
                monsters.Remove(monster);

                //경험치 획득
                user.GetExp(10);

                bool dropitem = random.Next(1, 10) > 5;
                if (dropitem)
                {
                    Item potion = new Item();
                    Print($"몬스터가 {potion.name}을 떨어뜨렸습니다.");

                    if (user.item.Count > 2) //3개까지 줍기 가능
                    {
                        Print("더 이상 아이템을 주울 수 없습니다.");
                    }
                    else
                    {
                        user.item.Add(potion);
                        Print($"포션을 주웠습니다. 포션 갯수:{user.item.Count}");
                    }
                }
            }
        }

        private static void CreateNewWand(out string userWnad, out int power)
        {
            String userWnadInput;
            do
            {
                List<String> wandList = new List<string>(); //랜덤 지팡이 이름
                wandList.Add("[딱총나무 지팡이] 재료 : 테스트랄 꼬리 털 ");
                wandList.Add("[호두나무 지팡이] 재료 : 용의 심장 줄");
                wandList.Add("[산사나무 지팡이] 재료 : 유니콘 꼬리 털");
                wandList.Add("[호랑가시나무 지팡이] 재료 : 피닉스(불사조) 깃털");

                int indexWand = random.Next(0, 4); // 랜덤 지팡이
                userWnad = wandList[indexWand];
                power = random.Next(5, 11); //랜덤 공격력

                Print("\n지팡이를 집었습니다. " + userWnad + "\n공격력" + power);
                Print("이 지팡이로 하시겠습니까? Y/N");

                userWnadInput = Console.ReadLine();
                if (userWnadInput.ToLower() == "y")
                {
                    Print("\n지팡이를 장착했습니다!\n");
                }
                else
                {
                    Print("\n새로운 지팡이를 선택합니다\n");
                }
            } while (userWnadInput.ToLower() == "n");
        }

        private static void CreateNewCloak(out string userCloak, out int defense)
        {
            String userClockInput;
            do
            {
                List<String> cloakList = new List<string>();
                cloakList.Add("닥터 스트레인저가 쓰던 망토");
                cloakList.Add("슈퍼맨이 쓰던 낡은 망토");
                cloakList.Add("1학년을 위한 새 망토");
                cloakList.Add("투명 망토");

                int indexCloak = random.Next(0, 4);
                userCloak = cloakList[indexCloak];
                defense = random.Next(5, 11);

                Print("\n망토를 집었습니다. [" + userCloak + "]\n방어력 : " + defense);
                Print("이 망토로 하시겠습니까? Y/N");

                userClockInput = Console.ReadLine();
                if (userClockInput.ToLower() == "y")
                {
                    Print("\n망토를 둘렀습니다!\n");
                }
                else
                {
                    Print("\n새로운 망토를 선택합니다\n");
                }
            } while (userClockInput.ToLower() == "n");
        }

        private static void Print(String log)
        {
            Console.WriteLine(log);
        }

        private static void PrintUser(User user)
        {
            Print("\n당신의 정보");
            Print($"이름: {user.DisplayName} 레벨:{user.level} 경험치:{user.exp} HP:{user.hp}/{user.maxHp} 공격력:{user.power} 방어력:{user.defense} 마나:{user.mana}/{user.MaxMana}");
        }

        private static void PrintMonster(Monster monster)
        {
            Print($"{monster.name} 공격력:{monster.power}, 체력:{monster.hp}");
        }

        private static string GetAllowedAnswer(params string[] alllowsAnserStringArray)
        {
            string retryOrQuit;
            List<string> allowedAnswer = new List<string>(alllowsAnserStringArray);
            do
            {
                retryOrQuit = Console.ReadLine().ToUpper();
            } while (allowedAnswer.Contains(retryOrQuit) == false);
            return retryOrQuit;
        }
    }
}