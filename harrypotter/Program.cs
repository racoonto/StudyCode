using System;
using System.Collections.Generic;

namespace harrypotter
{
    internal class Program
    {
        private static Random random = new Random();

        private static void Main(string[] args)
        {
            Print("호그와트로부터 초대장이 날아왔습니다! \n입학을 원하면 이름을 서명해주세요");

            String Username = Console.ReadLine();
            User user = new User(Username, 0, 0);

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

            Print("\n\n준비물을 사기위해 다이애건 앨리에 왔습니다.");
            Print("1: 지팡이 구입하기 2: 망토 구입하기");

            string userStoreInput = Console.ReadLine();

            switch (userStoreInput)
            {
                case "1": //지팡이 선택 : 공격력 결정

                    String userWnadInput;
                    do
                    {
                        string userWnad;
                        int power;

                        CreateNewWand(out userWnad, out power);

                        Print("\n\n지팡이를 집었습니다.");
                        Print(userWnad + "\n공격력" + power);
                        Print("이 지팡이로 하시겠습니까? Y/N");

                        userWnadInput = Console.ReadLine();
                        if (userWnadInput.ToLower() == "y")
                        {
                            Print("지팡이를 장착했습니다!\n");
                            user.power = power;
                        }
                        else
                        {
                            Print("새로운 지팡이를 선택합니다\n");
                        }
                    } while (userWnadInput.ToLower() == "n");
                    break;

                case "2": // 망토 선택 : 방어력 결정

                    String userClockInput;
                    do
                    {
                        string userCloak;
                        int defense;

                        CreateNewCloak(out userCloak, out defense);

                        Print("\n\n망토를 집었습니다");
                        Print(userCloak + "\n방어력 : " + defense);
                        Print("이 망토로 하시겠습니까? Y/N");

                        userClockInput = Console.ReadLine();
                        if (userClockInput.ToLower() == "y")
                        {
                            Print("망토를 둘렀습니다!\n");
                            user.defense = defense;
                        }
                        else
                        {
                            Print("새로운 망토를 선택합니다\n");
                        }
                    } while (userClockInput.ToLower() == "n");

                    break;
            }
        }

        private static void CreateNewCloak(out string userCloak, out int defense)
        {
            List<String> cloakList = new List<string>();
            cloakList.Add("닥터 스트레인저가 쓰던 망토");
            cloakList.Add("슈퍼맨이 쓰던 낡은 망토");
            cloakList.Add("1학년을 위한 새 망토");
            cloakList.Add("투명 망토");

            int indexCloak = random.Next(0, 4);
            userCloak = cloakList[indexCloak];
            defense = random.Next(5, 11);
        }

        private static void CreateNewWand(out string userWnad, out int power)
        {
            List<String> wandList = new List<string>(); //랜덤 지팡이 이름
            wandList.Add("딱총나무 지팡이 : 재료. 테스트랄 꼬리 털 ");
            wandList.Add("호두나무 지팡이 : 재료. 용의 심장 줄");
            wandList.Add("산사나무 지팡이 : 재료. 유니콘 꼬리 털");
            wandList.Add("호랑가시나무 지팡이 : 재료. 피닉스(불사조) 깃털");

            int indexWand = random.Next(0, 4); // 랜덤 지팡이
            userWnad = wandList[indexWand];
            power = random.Next(5, 11); //랜덤 공격력
        }

        private static void Print(String log)
        {
            Console.WriteLine(log);
        }
    }
}