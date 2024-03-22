using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//���������� �����ϴ� ��Ʈ�ѷ�
//�������� ���۰� ���� ������ ���������� ���۰� ������ ó���ϴ� ���
//�������� ������ ȹ���ϴ� ����Ʈ�� �����ϴ� �ý���
public class StageController : MonoBehaviour
{
    #region Field
    //������������ ���� ����Ʈ�� ������ ����
    public int StagePoint = 0;
    //����Ʈ ǥ�ÿ� �ؽ�Ʈ
    public Text PointText;
    #endregion

    #region Singleton
    //�������� ��Ʈ�ѷ��� �ν��Ͻ��� �����ϴ� static ������
    public static StageController instance;
    //�ٸ� �ڵ�  ������ StageController.instance.AddPoint(10)�� ���� ���·� ����� �� �ְ� ��
    //���� �����ؼ� �� �ʿ䰡 ��� ����

    private void Start()
    {
        instance = this;
        //�ȳ�â �� ����
        DialogDataAlert alert = new DialogDataAlert("START", "�������� ��������", delegate ()
        {
            Debug.Log("OK�� �������ϴ�.");
        });

        //�Ŵ����� ���
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
        //Application.LoadLevel(Application.loadedLevel); <- �� ���� �ڵ�(����� ��� x)
       // SceneManager.LoadScene("Game");
    }
}
