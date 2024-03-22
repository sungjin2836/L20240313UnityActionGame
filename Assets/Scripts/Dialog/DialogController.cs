using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Ϲ� �˾�â�� Ȯ���˾�â�� �����ϴ� DialogControllerAlert, DialogControllerConfirm�� �θ� Ŭ����
public class DialogController : MonoBehaviour
{
    #region Field and Property
    //�˾� â�� Ʈ������
    public Transform window;

    //�˾�â�� ���̴��� ��ȸ�ϴ� ���, ������ �ʰ� �����ϱ� ���� �Ӽ�
    public bool Visible
    {
        get
        {
            return window.gameObject.activeSelf;
            //�ش� ������Ʈ�� Ȱ��ȭ�Ǿ��ִ��� �ƴ����� �Ǵ��ϴ� �б� ���� �� activeSelf
        }

        private set
        {
            window.gameObject.SetActive(value);
            //visible�� ����� ���� Ȱ��ȭ�� ó���ϴ� �ڵ�
            //�ܺο��� ������ �� �����ϴ�.
        }
    }
#endregion

    #region virtual method
    //���� �Լ� : �ڽ� �ʿ��� �������̵� �� ���� ����� ��� �ۼ��Ǵ� Ű����
    public virtual void Awake()
    {

    }

    public virtual void Start()
    {

    }

    public virtual void Build(DialogData data)
    {

    }
    #endregion


    #region Coroutine
    //�˾��� ȭ�鿡 ��Ÿ�� �� ȣ���� �Լ�
    public void Show(Action callback)
    {
        StartCoroutine(OnEnter(callback));
    }

    //�˾��� ȭ�鿡�� ����� �� ȣ���� �Լ�
    public void Close(Action callback)
    {
        StartCoroutine(OnExit(callback)); 
    }

    IEnumerator OnEnter(Action callback)
    {
        Visible = true;
        if(callback != null)
        {
            callback();
        }
        yield break; //�۾� ����
    }

    IEnumerator OnExit(Action callback)
    {
        Visible = false;
        if (callback != null) //�븮�ڸ� ���� �޾ƿ� ����� �����ϴ� �۾�
        {
            callback();
        }
        yield break; // �۾� ����
    }
    #endregion
}
