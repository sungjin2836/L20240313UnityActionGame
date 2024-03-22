using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{

    public GameObject button;
    public Image image;

    public void StartFadeIn()
    {
        StartCoroutine("Fade");
    }


    public void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(StartFadeIn);
        //��ư ������Ʈ�� �� Ŭ�� �̺�Ʈ ������ ����
    }

    IEnumerator Fade()
    {
        float startAlpha = 0;
        while(startAlpha < 1.0f)
        {
            startAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0,0,0,startAlpha);
        }
            SceneManager.LoadScene("Game");

    }
}
