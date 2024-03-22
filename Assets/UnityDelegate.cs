using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//유니티에서 사용할 수 있는 대리자 유형
//1. Action : 유니티에서 반환 값이 따로 없는 void 형태의 대리자
//2. Func : 유니티에서 반환 값이 있는 형태의 대리자
//3. UnityEvent : 인스펙터에서 이벤트를 노출시켜, 할당할 수 있게 해주는 도구
//4. event : 
//5. delegate

public class UnityDelegate : MonoBehaviour
{
    public UnityEvent onDead;

    public void Awake()
    {
        onDead.AddListener(Dead); //스크립트를 통해 onDead에 이벤트 함수 등록
        //몬스터 안에 오브젝트가 있을때 사용하여 나오게 사용할 수 있음
    }

    Action testAction01;
    void Method01()
    {
    }
    void Method02()
    {
    }
    void Method03()
    {
    }
    int Method04()
    {
        return 1;
    }

    Action<int> testAction02; // 액션의 <>안에 넣는 값은 delegate로 호출할 함수의 매개변수이다

   void Method05(int a)
    {
    }

    Func<int> testFunc01;
    Func<bool> testFunc02;
    Func<int, int, int> testFunc03; //마지막에 적어놓은 타입 int는 return 타입
    //그 앞의 값들은 전부 매개변수 취급한다.       Func<매개변수, 매개변수, return타입>

    bool Method06()
    {
        return true;
    }

    bool Method07()
    {
        return false;
    }

    int Method08(int a, int b)
    {
        return a + b;
    }

    void Dead()
    {

    }
    void Start()
    {
        testAction01 += Method01;
        testAction01 += Method02;
        testAction01 += Method03;
        //testAction01 += Method04; 오류 
        testAction01();

        //testAction02 += Method04;
        testAction02 += Method05; // 액션<>안에 int를 넣어서 
        testAction02(2);
        testAction02?.Invoke(10); //대리자의 Invoke 기능 실행
        //아래의 코드는 ?를 통해 NULL 체크를 진행할 수 있어 NullReferenceException에 대한 상황을 피할 수 있음
        //null값 체크 가능

        testFunc02 += Method06;
        testFunc02 += Method07;

        if (testFunc02?.Invoke() == true)
        {        }

        if (testFunc02())
        {
        }

        testFunc03 += Method08;
        Debug.Log(testFunc03?.Invoke(10,5));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
