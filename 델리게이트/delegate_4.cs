using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

//C# delegate 필드와 delegate 속성
//using System.Windows.Forms; 오류 시
//프로젝트창 - 종속성 우클 - 프로젝트 참조 추가 - 찾아보기
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.Windows.Forms.dll 수동으로 추가
namespace 델리게이트
{
    internal class MyArea : Form
    {
        public MyArea()
        {
            // 이 부분은 당분간 무시 (무명메서드 참조)
            // 예제를 테스트하기 위한 용도임.
            this.MouseClick += delegate { MyAreaClicked(); };
        }

        public delegate void ClickDelegate(object sender);

        // Delegate 필드
        public ClickDelegate MyClick;

        // 필드 대신 Delegate 속성으로도 가능
        //public ClickDelegate Click { get; set; }

        //...
        //...

        // 예제를 단순화 하기 위해
        // MyArea가 클릭되면 아래 함수가 호출된다고 가정
        private void MyAreaClicked()
        {
            if (MyClick != null)
            {
                MyClick(this);
            }
        }
    }

    internal class delegate_4
    {
        private static MyArea area;

        private static void Main(string[] args)
        {
            area = new MyArea();
            area.MyClick = Area_Click;
            area.ShowDialog();
        }

        private static void Area_Click(object sender)
        {
            area.Text = "MyArea 클릭!";
        }
    }
}