using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Delegate?
// C/C++의 함수 포인터와 비슷한 개념

//델리게이트로 함수 타입에 대한 정의를 진행하고
//매개변수에 대한 설계를 진행할 경우
//같은 타입, 같은 매개변수를 가진 메소드를
//불러서 사용할 수 있는 C# 도구이다. (대리자)

public class DelegateExample : MonoBehaviour
{
    //1. delegate를 선언함
    delegate void DelegateTester();

    //2. delegate로 선언한 형태와 동일한 함수를 구현함
    void DelegateTest01()
    {
        Debug.Log("대리자 테스트 1");
    }

    void DelegateTest02()
    {
        Debug.Log("대리자 테스트 2");
    }


    void Start()
    {
        //델리게이트 생성
        //델리게이트명 변수명 = new 델리게이트명(함수명);
        DelegateTester delegateTester = new DelegateTester(DelegateTest01);
        //DelegateTester delegateTester1 = new DelegateTester(DelegateTest02);
        //델리게이트 호출

        delegateTester = DelegateTest02;
        delegateTester += DelegateTest01;
        delegateTester();
        delegateTester -= DelegateTest01;
        delegateTester -= DelegateTest02;
        delegateTester();
    }

    void Update()
    {
        
    }
}
