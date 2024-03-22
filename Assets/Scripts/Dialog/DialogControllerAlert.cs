using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogControllerAlert : DialogController
{
    #region Field & Property
    public Text LabelTitle;
    public Text LabelMessage;

    DialogDataAlert Data
    {
        get;
        set;
    }
    #endregion

    public DialogControllerAlert()
    {
        DialogManager.Instance.Regist(DialogType.Alert, this);
    }


    #region virtual override
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        
    }

    public override void Build(DialogData data)
    {
        base.Build(data);

        //데이터가 없을 때 Build 실행 시 로그를 남김
        if (!(data is DialogDataAlert))
        {
            Debug.LogError("Invalid dialog data!");
            return;
        }

        Data = data as DialogDataAlert;
        LabelTitle.text = Data.Title;
        LabelMessage.text = Data.Message;
    }
    #endregion

    public void OnClickOK()
    {
        // calls child's callback
        //데이터 / 콜백 다 존재하면
        if (Data != null && Data.Callback != null)
        {
            //데이터에 대한 롤백 함수 호출
            Data.Callback();
            //매니저 객체를 통해 팝업을 매니저에서 제거함
        }
            DialogManager.Instance.Pop();
    }
}


