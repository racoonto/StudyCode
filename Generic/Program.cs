using System;
using System.Collections.Generic; // 제네릭 타입의 자료구조들

namespace Generic
{
    internal class Program
    {
        //데이터 요소 타입을 확정하지 않고 타입 자체를 타입 파라미터(Type Parameter)로 받아들이도록 클래스를 정의.
        //사용할 때 클래스명과 함께 구체적인 데이터 타입을 지정한다.
        //.NET Framework에는 많은 제네릭 클래스들이 포함되어 있는데,
        //특히 System.Collections.Generic 네임스페이스에 있는 모든 자료구조 관련 클래스들은 제네릭 타입이다.
        //흔히 사용하는 List<T>, Dictionary<T>, LinkedList<T> 등의 클래스들은 이 네임스페이스 안에 들어 있다.

        // 어떤 요소 타입도 받아들 일 수 있는
        // 스택 클래스를 C# 제네릭을 이용하여 정의
        private class MyStack<T>
        {
            private T[] _elements;
            private int pos = 0;

            public MyStack()
            {
                _elements = new T[100];
            }

            public void Push(T element)
            {
                _elements[++pos] = element;
            }

            public T pop()
            {
                return _elements[pos--];
            }

            // 두 개의 서로 다은 타입을 갖는 스택 객체를 생성
            private MyStack<int> numberStack = new MyStack<int>();

            private MyStack<string> nameStack = new MyStack<string>();
        }

        private static void Main(string[] args)
        {
            //리스트 제네릭 자료구조
            List<string> nameList = new List<string>();
            nameList.Add("홍길동");
            nameList.Add("이태백");

            //딕셔너리 제네릭 자료구조
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic["길동"] = 100;
            dic["태백"] = 90;
        }

        //C# 제네릭 타입을 선언할 때, 타입 파라미터가 Value Type인지 Reference Type인지,
        //또는 어떤 특정 Base 클래스로부터 파생된 타입인지, 어떤 인터페이스를 구현한 타입인지 등등을 지정할 수 있는데,
        // where T : 제약조건 과 같은 식으로 where 뒤에 제약 조건을 붙이면 가능하다.
        private class MyClass1<T> where T : struct
        {
            // T는 Value 타입
        }

        private class MyClass2<T> where T : class
        {
            // T는 Reference 타입
        }

        private class MyClass3<T> where T : new()
        {
            // T는 디폴트 생성자를 가져야 함
        }

        private class MyClass4<T> where T : MyBase
        {
            // T는 MyBase의 파생클래스이어야 함
        }

        private class MyClass5<T> where T : IComparable
        {
            // T는 IComparable 인터페이스를 가져야 함
        }

        private class EmployeeList<T> where T : Employee, IEmployee, IComparable<T>, new()
        {
            // 좀 더 복잡한 제약들
        }

        private class MyClass<T, U> where T : class where U : struct
        {
            // 복수 타입 파라미터 제약
        }
    }
}