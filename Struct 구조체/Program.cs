using System;

namespace Struct_구조체
{
    internal class Program
    {
        //Struct 여러 자료형을 묶어 하나로 사용.
        //C#에서는 struct를 사용하면 Value Type을 만들고, class를 사용하면 Reference Type을 만든다.
        //C# .NET의 기본 데이타형들은 struct로 정의되어 있다.
        //C#의 구조체는 클래스와 같이 메서드, 프로퍼티 등 거의 비슷한 구조를 가지고 있지만, 상속은 할 수 없다.
        //하지만 C# 구조체가 상속(inheritance)은 할 수는 없어도, 클래스와 마찬가지로 인터페이스(interface)를 구현할 수는 있다.

        private struct MyPoint
        {
            public int X;
            public int Y;

            public MyPoint(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return string.Format("({0},{1})", X, Y);
            }
        }

        private static void Main(string[] args)
        {
            MyPoint pt = new MyPoint(10, 12);
            Console.WriteLine(pt.ToString());
        }
    }
}