using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//스테이지를 관리하는 컨트롤러
//스테이지 시작과 종료 시점에 스테이지의 시작과 마감을 처리하는 기능
//스테이지 내에서 획득하는 포인트를 관리하는 시스템
public class StageController : MonoBehaviour
{
    #region Field
    //스테이지에서 쌓은 포인트를 저장할 변수
    public int StagePoint = 0;
    //포인트 표시용 텍스트
    public Text PointText;
    #endregion

    #region Singleton
    //스테이지 컨트롤러의 인스턴스를 저장하는 static 변수임
    public static StageController instance;
    //다른 코드  내에서 StageController.instance.AddPoint(10)과 같은 형태로 사용할 수 있게 됨
    //따로 연결해서 쓸 필요가 없어서 편리함

    private void Start()
    {
        instance = this;
        //안내창 값 설정
        DialogDataAlert alert = new DialogDataAlert("START", "슬라임을 잡으세요", delegate ()
        {
            Debug.Log("OK를 눌렀습니다.");
        });

        //매니저에 등록
        DialogManager.Instance.Push(alert);

        //StagePoint = 0;
        //PointText.text = StagePoint.ToString();
    }
    #endregion

    public void AddPoint(int point)
    {
        StagePoint += point;
        PointText.text = StagePoint.ToString();
    }

    public void FinishGanme()
    {
        DialogDataConfirm confirm = new DialogDataConfirm("Restart?", "Please press OK if u want to restart the game.",
        delegate(bool yn)
        {
            if (yn)
            {
                SceneManager.LoadScene("Game");
            }
            else
            {
                Application.Quit();
            }
        });

        DialogManager.Instance.Push(confirm);
        //Application.LoadLevel(Application.loadedLevel); <- 구 버전 코드(현재는 사용 x)
       // SceneManager.LoadScene("Game");
    }
}
