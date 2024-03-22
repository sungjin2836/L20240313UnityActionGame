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
    //event(이벤트) : 개체에게 작업 실행을 알리기 위해 보내는 메세지
    //이벤트는 외부 가입자(Subscriber)에게 특정 일을 알려주는기능을 가짐

    //Event Handler(이벤트 핸들러) : 구독자가 이벤트가 발생할 경우 어떤 명령을 실행할 지 지정해주는것
    //+= 을 통해 이벤트에 대한 추가가 가능하며, -=을 통해 이벤트를 제거하는 것도 가능
    //이벤트 발생 시 추가된 핸들러는 순차적으로 호출됨


    class ClickEvent
    {
        public event EventHandler Click;

        public void MouseButtonDown()
        {
            if(Click != null)
            {
                Click(this, EventArgs.Empty); //더 전달할 정보가 없어서 파라미터.Empty라고 보냄
                //EventArgs 이벤트 받을 때 파라미터로 데이터를 받고 싶을 경우 해당 클래스를 상속받아 사용함
                //EventArgs는 이벤트 발생과 관련된 정보를 가지고 있음
                //이벤트 핸들러가 사용하는 파라미터 값임
            }
        }
    }
    void Start()
    {
        //int count = 99;
        clickEvent = new ClickEvent();
        EventMotiontext = "축하합니다! 100번째 접속 유저입니다! \n 이벤트에 당첨되셨습니다!";
        clickEvent.Click += new EventHandler(Check);

        StartCoroutine(Typing(EventMotiontext));
    }

    private void Check(object sender, EventArgs e)
    {
        //EventText.text = "축하합니다! 100번째 접속 유저입니다! \n 이벤트에 당첨되셨습니다!";
        EventMotiontext = "축하합니다! 100번째 접속 유저입니다! \n 이벤트에 당첨되셨습니다!";
        StartCoroutine(Typing(EventMotiontext));
    }
    public void OnCkickEvent()
    {
        count++;
        if(count == 100)
        {
            Debug.Log("100번쨰");
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
            //속도
            yield return new WaitForSeconds(0.05f);
        }
    }

}
