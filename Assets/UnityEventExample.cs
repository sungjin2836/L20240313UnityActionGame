using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UnityEventExample : MonoBehaviour
{
    ClickEvent clickEvent;
    string EventMotiontext;
    int count;
    public Text EventText;
    public Transform window;
    //event(�̺�Ʈ) : ��ü���� �۾� ������ �˸��� ���� ������ �޼���
    //�̺�Ʈ�� �ܺ� ������(Subscriber)���� Ư�� ���� �˷��ִ±���� ����

    //Event Handler(�̺�Ʈ �ڵ鷯) : �����ڰ� �̺�Ʈ�� �߻��� ��� � ����� ������ �� �������ִ°�
    //+= �� ���� �̺�Ʈ�� ���� �߰��� �����ϸ�, -=�� ���� �̺�Ʈ�� �����ϴ� �͵� ����
    //�̺�Ʈ �߻� �� �߰��� �ڵ鷯�� ���������� ȣ���


    class ClickEvent
    {
        public event EventHandler Click;

        public void MouseButtonDown()
        {
            if(Click != null)
            {
                Click(this, EventArgs.Empty); //�� ������ ������ ��� �Ķ����.Empty��� ����
                //EventArgs �̺�Ʈ ���� �� �Ķ���ͷ� �����͸� �ް� ���� ��� �ش� Ŭ������ ��ӹ޾� �����
                //EventArgs�� �̺�Ʈ �߻��� ���õ� ������ ������ ����
                //�̺�Ʈ �ڵ鷯�� ����ϴ� �Ķ���� ����
            }
        }
    }
    void Start()
    {
        //int count = 99;
        clickEvent = new ClickEvent();
        EventMotiontext = "�����մϴ�! 100��° ���� �����Դϴ�! \n �̺�Ʈ�� ��÷�Ǽ̽��ϴ�!";
        clickEvent.Click += new EventHandler(Check);

        StartCoroutine(Typing(EventMotiontext));
    }

    private void Check(object sender, EventArgs e)
    {
        //EventText.text = "�����մϴ�! 100��° ���� �����Դϴ�! \n �̺�Ʈ�� ��÷�Ǽ̽��ϴ�!";
        EventMotiontext = "�����մϴ�! 100��° ���� �����Դϴ�! \n �̺�Ʈ�� ��÷�Ǽ̽��ϴ�!";
        StartCoroutine(Typing(EventMotiontext));
    }
    public void OnCkickEvent()
    {
        count++;
        if(count == 100)
        {
            Debug.Log("100����");
            clickEvent.MouseButtonDown();
            window.gameObject.SetActive(true);
        }

    }
    void Update()
    {
    }

    IEnumerator Typing(string EventMotiontext)
    {
        EventText.text = null;

        for (int i = 0; i < EventMotiontext.Length; i++)
        {
            EventText.text += EventMotiontext[i];
            //�ӵ�
            yield return new WaitForSeconds(0.05f);
        }
    }

}
