using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace 람다식
{
    internal class Program
    {
        private delegate int Calculate(int a, int b); //익명 메소드

        private delegate string Concatenate(String[] args); //문자열을 결합시키는 대리자

        private static void Main(string[] args)
        {
            Calculate calc = (a, b) => a + b; // 두개의 int 형식 매개변수 a,b를 받아 이 둘을 더해 반환하는 익명 메소드를 람다식으로 만들었다.
            Console.WriteLine($"{3}+{4} :{calc(3, 4)}");

            //문 형식의 람다식
            Concatenate concat = (arr) => // 매개변수로 array, 매개변수가 없는 경우는 ()
            {
                string result = "";
                foreach (string s in arr)
                    result += s;

                return result;
            };
            Console.WriteLine(concat(args));

            //Func 대리자 - 결과를 반환하는 메소드 참조
            //Action 대리자 - 결과를 반환하지 않는 메소드 참조
            //미리 만들어 놓은 대리자 사용

            Func<int> Functest = () => 10;  // 입력 매개변수는 없고 10 반환
            Console.WriteLine(Functest()); // 10 출력

            Action act1 = () => Console.WriteLine("Action()"); //입력 매개변수가 없음.
            act1();

            int result = 0;
            Action<int> act2 = (x) => result = x * x; // 한개의 매개변수
            act2(3);
            Console.WriteLine($"result : {result}"); //9

            Action<double, double> act3 = (x, y) => // 두개의 매개변수
            {
                double pi = x / y;
                Console.WriteLine($"Action<T1, T2>({x},{y}) : {pi}"); // Action<T1, T2>(22,7) : 3.14285714285714
            };
            act3(22.0, 7.0);

            //식 트리. 트리 자료 구조
            //식을 트리로 표현한 자료구조
            //부모 노트 (연산자)가 단 두개의 자식 노트 (피연산자)만 갖는 이진 트리
            //트리의 잎 노드부터 계산해서 루트까지 올라가면 전체 식의 결과

            // C#의 코드에서 직접 식 트리를 조립 및 컴파일해서 사용할 수 있는 기능 제공
            //프로그램 실행 중에 동적으로 무명 함수를 만들어 사용
            //System.Linq.Expressions 의 Expression 클래스와 파생 클래스

            // 1*2+(x-y)를 표현
            Expression const1 = Expression.Constant(1);
            Expression const2 = Expression.Constant(2);

            Expression leftExp = Expression.Multiply(const1, const2); // 1*2;

            Expression param1 = Expression.Parameter(typeof(int)); // x을 위한 변수
            Expression param2 = Expression.Parameter(typeof(int)); // y를 위한 변수

            Expression rightExp = Expression.Subtract(param1, param2); // x-y

            Expression exp = Expression.Add(leftExp, rightExp); // 연산되는 부분

            //람다식 클래스의 파생 클래스인 Expression<T> 델리게이트를 사용
            Expression<Func<int, int, int>> expression = Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(
                exp, new ParameterExpression[]{
                    (ParameterExpression)param1, (ParameterExpression)param2});

            Func<int, int, int> func = expression.Compile();

            //x= 7, y = 8
            Console.WriteLine($"1*2+({7}-{8})={func(7, 8)}");

            //식으로 이루어지는 멤버
            //멥버의 본문을 식(Expression)만으로 구현
            //Expression-Bodied Member : 식 본문 멤버
            //멤버 => 식;

            FriendList obj = new FriendList();
            obj.Add("Eemy");
            obj.Add("Meeny");
            obj.Add("Miny");
            obj.Remove("Eeny");
            obj.PrintAll();

            Console.WriteLine($"{obj.Capacity}");
            obj.Capacity = 10;
            Console.WriteLine($"{obj.Capacity}");

            Console.WriteLine($"{obj[0]}");
            obj[0] = "Moe";
            obj.PrintAll();

            //출력결과
            /*
             * FriendList()
             * Meeny
             * Miny
             * 4
             * 10
             * Meeny
             * Moe
             * Miny
             * ~FriendList()
             */
        }

        private class FriendList
        {
            private List<string> list = new List<string>();

            public void Add(string name) => list.Add(name);

            public void Remove(string name) => list.Remove(name);

            public void PrintAll()
            {
                foreach (var s in list)
                    Console.WriteLine(s);
            }

            public FriendList() => Console.WriteLine("FriendList()"); //성성자

            ~FriendList() => Console.WriteLine("~FriendList()"); //종료자

            //public int Capacity => list.Capacity; // 읽기 전용

            public int Capacity // 속성
            {
                get => list.Capacity;
                set => list.Capacity = value;
            }

            //public string this[int index] => list[index]; // 읽기 전용
            public string this[int index]
            {
                get => list[index];
                set => list[index] = value;
            }
        }
    }
}