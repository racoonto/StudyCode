using System;

namespace 델리게이트
{
    //Delegate는 메서드를 다른 메서드로 전달할 수 있도록 하기 위해 만들어 졌다.
    //델리게이트 정의에서 중요한 것은 입력 파리미터들과 리턴 타입이다.

    internal class Program
    {
        private static void Main(string[] args)
        {
            new Program().Test();
        }

        private delegate int MyDelegate(string s);

        private void Test()
        {
            //델리게이트 객체 생성
            MyDelegate m = new MyDelegate(StringToInt);

            //델리게이트 객체를 메서드로 전달
            Run(m);
        }

        // 델리게이트 대상이 되는 어떤 메서드
        private int StringToInt(string s)
        {
            return int.Parse(s);
        }

        // 델리게이트를 전달 받는 메서드
        private void Run(MyDelegate m)
        {
            // 델리게이트로부터 메서드 실행
            int i = m("123");

            Console.WriteLine(i);
        }
    }
}