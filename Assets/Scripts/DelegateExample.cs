using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Delegate?
// C/C++�� �Լ� �����Ϳ� ����� ����

//��������Ʈ�� �Լ� Ÿ�Կ� ���� ���Ǹ� �����ϰ�
//�Ű������� ���� ���踦 ������ ���
//���� Ÿ��, ���� �Ű������� ���� �޼ҵ带
//�ҷ��� ����� �� �ִ� C# �����̴�. (�븮��)

public class DelegateExample : MonoBehaviour
{
    //1. delegate�� ������
    delegate void DelegateTester();

    //2. delegate�� ������ ���¿� ������ �Լ��� ������
    void DelegateTest01()
    {
        Debug.Log("�븮�� �׽�Ʈ 1");
    }

    void DelegateTest02()
    {
        Debug.Log("�븮�� �׽�Ʈ 2");
    }


    void Start()
    {
        //��������Ʈ ����
        //��������Ʈ�� ������ = new ��������Ʈ��(�Լ���);
        DelegateTester delegateTester = new DelegateTester(DelegateTest01);
        //DelegateTester delegateTester1 = new DelegateTester(DelegateTest02);
        //��������Ʈ ȣ��

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
