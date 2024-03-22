using System;
using System.Collections;
using UnityEngine;

//알림창에서 사용할 데이터
public class DialogDataAlert : DialogData
{
    public string Title { get; private set; }//set을 private로 선언하면 읽기만 가능
    public string Message { get; private set; }
    //유니티에서 사용할 수 있는 delegate Action
    //유저가 확인 버튼 눌렀을 때 호출되는 콜백 함수를 저장
    //콜백 함수는 송신 
    public Action Callback { get; private set; }    

    //Action callback = null <- 매개변수를 안넣어도 되게 함
    //default 매개변수는 매개ㅑ변수에 값을 초기화해두는 것으로,
    //함수 호출 시에 해당 값을 안넣고 호출하는 경우 설정해둔 초기값으로 자동으로 처리하는 기능

    //base(DialogType.Alert) 부모값을 그대로 가져오는 도구

    public DialogDataAlert(string title, string message, Action callback = null) : base(DialogType.Alert)
        //initiallize 부모의 값을 받아옴
    {
        Title = title;
        Message = message;
        Callback = callback;
    }
}

