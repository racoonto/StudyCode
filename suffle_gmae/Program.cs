using System;
using System.IO;

namespace StudyCode01 // 텍스트 셔플게임
{
    internal class Program
    {
        //셔플된 문자열 가져오기
        private static string Shuffle(string s)
        {
            int len = s.Length; //문자열의 길이 = 문자 배열의 길이가 됨

            //문자열에서 문자 배열로 변환
            char[] cs = s.ToCharArray();

            //문자 길이의 횟수 셔플
            Random rnd = new Random();
            int i;
            for (i = 0; i < len; i++)
            {
                //바꿀 위치 결정
                int n1 = rnd.Next(len);//바꿀위치(1)
                int n2 = n1;//바꿀위치(2)
                while (n2 == n1)
                    n2 = rnd.Next(len);

                //문자 바꾸기
                char tmp = cs[n1]; //tmp는 일시 자리 피하기용 변수
                cs[n1] = cs[n2];
                cs[n2] = tmp;
            }

            //문자 배열에서 문자열로 변환
            string t = new string(cs);
            return t;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("**셔플 퀴즈**");
            FileStream fs;
            StreamReader r;
            try
            {
                //파일 열기
                //Systme.Text.Encoding.Default는 시스템 기본 값인
                //Shift-JIS 형식의 파일을 일거 들였음을 나타냅니다.
                fs = new FileStream("q.txt", FileMode.Open);
                r = new StreamReader(fs, System.Text.Encoding.Default);
            }
            catch (IOException e)
            {
                Console.WriteLine("문제 파일을 읽어 들이지 못했습니다.");
                Console.WriteLine(e.Message);
                return;
            }
            string s, t, a; // s:정답 t:문제 a:사용자의 회담
            int n = 1; // 문제번호
            s = r.ReadLine(); // 정답 문자열 읽어 들이기
            while (s != null)
            {
                t = Shuffle(s);
                Console.WriteLine("Q{0} '{1}'을 바르게 나열하면 어떻게 됩니까?", n, t);
                int miss = 0;
                while (miss < 3)
                {
                    a = Console.ReadLine();
                    if (a == s) // 정답이면 루프 종료
                        break;
                    Console.WriteLine("틀렸습니다.");
                    miss++;
                    if (miss == 2)
                        Console.WriteLine("힌트: 처음 세 문자는 {0}입니다.", s.Substring(0, 3));
                }
                if (miss >= 3)
                    Console.WriteLine("정답은 {s}입니다.\n");
                else
                    Console.WriteLine("정답입니다!!\n");
                s = r.ReadLine(); // 다음 문제의 정답 문자열 읽어 들이기
                n++;
            }
            Console.WriteLine("문제는 이상입니다.");
            r.Close();
        }
    }
}