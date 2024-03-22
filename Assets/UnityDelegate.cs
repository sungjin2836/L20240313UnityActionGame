using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//����Ƽ���� ����� �� �ִ� �븮�� ����
//1. Action : ����Ƽ���� ��ȯ ���� ���� ���� void ������ �븮��
//2. Func : ����Ƽ���� ��ȯ ���� �ִ� ������ �븮��
//3. UnityEvent : �ν����Ϳ��� �̺�Ʈ�� �������, �Ҵ��� �� �ְ� ���ִ� ����
//4. event : 
//5. delegate

public class UnityDelegate : MonoBehaviour
{
    public UnityEvent onDead;

    public void Awake()
    {
        onDead.AddListener(Dead); //��ũ��Ʈ�� ���� onDead�� �̺�Ʈ �Լ� ���
        //���� �ȿ� ������Ʈ�� ������ ����Ͽ� ������ ����� �� ����
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

    Action<int> testAction02; // �׼��� <>�ȿ� �ִ� ���� delegate�� ȣ���� �Լ��� �Ű������̴�

   void Method05(int a)
    {
    }

    Func<int> testFunc01;
    Func<bool> testFunc02;
    Func<int, int, int> testFunc03; //�������� ������� Ÿ�� int�� return Ÿ��
    //�� ���� ������ ���� �Ű����� ����Ѵ�.       Func<�Ű�����, �Ű�����, returnŸ��>

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
        //testAction01 += Method04; ���� 
        testAction01();

        //testAction02 += Method04;
        testAction02 += Method05; // �׼�<>�ȿ� int�� �־ 
        testAction02(2);
        testAction02?.Invoke(10); //�븮���� Invoke ��� ����
        //�Ʒ��� �ڵ�� ?�� ���� NULL üũ�� ������ �� �־� NullReferenceException�� ���� ��Ȳ�� ���� �� ����
        //null�� üũ ����

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
