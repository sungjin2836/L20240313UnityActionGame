using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionExample : MonoBehaviour
{
    public bool isUse;
    public float cooltime = 10.0f;
    public float cooltime_max = 10.0f;
    public float potion_Heal = 20.0f;

    PlayerHealth playerHealth;
    public void OnPotionDown()
    {
        if(isUse == false)
        {
            Debug.Log("������ ����߽��ϴ�.");
            //playerHealth.currentHealth += potion_Heal;
            StartCoroutine(CoolTimeCheck());

        }

    }


    IEnumerator CoolTimeCheck()
    {
        while(cooltime > 0.0f)
        {
            GetComponent<Image>().color = Color.black;
            isUse = true;
            cooltime -= Time.deltaTime;
            GetComponent<Image>().fillAmount = cooltime / cooltime_max;

            yield return null; //1�ʸ��� null ���� return���� �ʿ� ����

        }
        //GetComponent<Image>().color = Color.red;
        GetComponent<Image>().fillAmount = 1.0f;
        cooltime = cooltime_max;
        isUse = false;
        
    }
}
