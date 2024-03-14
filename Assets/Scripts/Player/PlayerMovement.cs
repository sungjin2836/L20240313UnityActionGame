using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Animator�� ���� �䱸(�ݵ�� �ʿ�)
//���� ��� �ڵ� �߰�
//Animator�� �����Ϳ��� ������Ʈ ������ �� ����.
//���࿡ Animator ������Ʈ�� ���ٸ� ���� �������� ���� �ʴ´�.
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{

    //���� ������Ʈ ���� ����Ǿ� �ִ� Animator ������Ʈ�� �����ͼ� ���
    protected Animator avatar;
    protected PlayerAttack playerAttack; // 20240314 �÷��̾� ���� ��� �߰�
    float h;
    float v;

    //�ִϸ��̼� ����� �ð� üũ�� ����
    float lastAttackTime;
    float lastSkillTime;
    float LastDashTime;

    [Header("Animation Condition")]
    public bool attacking = false;
    public bool dashing = false;
    
    void Start()
    {
        avatar = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();

    }
    
    /// <summary>
    /// ���� ��Ʈ�ѷ����� ��Ʈ�ѷ��� ������ �Ͼ ��� ȣ���� �Լ�
    /// </summary>
    /// <param name="stickPos">��ƽ�� ��ǥ</param>

    public void onStickChanged(Vector2 stickPos)
    {
        h = stickPos.x;
        v = stickPos.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (avatar)
        {
            float back = 1.0f;
            if(v < 0.0f)
            {
                back = -1.0f;
            }


            avatar.SetFloat("Speed", (h * h + v * v));
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            if(rigidbody)
            {
                if(h != 0.0f && v != 0.0f)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(h, 0.0f, v));  
                    //�ش� ���� ������ �ٶ󺸴� ȸ�� ���¸� ��ȯ�ϴ� �ڵ�
                }
            }
        }
    }

    #region EventTriger
    public void OnAttackDown()
    {
        attacking = true;
        avatar.SetBool("Combo", true);
        StartCoroutine(StartAttack());//�ڷ�ƾ�� �۵���Ű�� �ڵ�
        //�ڷ�ƾ�� update�� �ƴ� �������� �ݺ������� �ڵ尡 ����Ǿ�� �� �� ����ϸ� ȿ������
        //Update���� ���к��ϰ� ������ �ڵ带 �ڷ�ƾ���� ��ȯ�ϸ�, �ڿ� ������ ȿ�����̴�.
        //�ڷ�ƾ�� ���� �ð� ���߰� �ڿ� �����̴� �۾�, Ư�� ������ �ο��� �ڵ带 �����ϴ� �۾��� ����
        //�ڷ�ƾ�� IEnumeric ������ �Լ��� �����մϴ�.
        //�ش� �Լ� ���ο��� �ݵ�� yield return���� �����ؾ� �մϴ�.

        //���� �Լ��δ� Invoke�� ������, �̰� �� �״�� �� �ð���ŭ ���� �� �Լ� �����̶� �ڷ�ƾ���� �ణ �ٸ�
        //�ڷ�ƾ�� �ݺ� ��ƾ���� Ż���ϰ� �ٽ� �� �������� ���ƿ��� ���� ������

        //StartCoroutine("StartAttack");
    }

    public void OnAttackUp()
    {
        avatar.SetBool("Combo", false);
        attacking = false;
    }

    //yield���� ���� ��Ҹ� �����ϴ� Ű������
    IEnumerator StartAttack()
    {
        if(Time.time - lastAttackTime > 1.0f)
        {
            lastAttackTime = Time.time;
            while( attacking )
            {
                avatar.SetTrigger("AttackStart");
                playerAttack.NormalAttack(); // 20240314 �÷��̾�������κ��� �Ϲ� ���� ȣ��
                yield return new WaitForSeconds(1.0f);
            }
        }
        
    }

    /// <summary>
    /// ��ư 1�� ��ų
    /// </summary>
    public void OnSkillDown()
    {
        if(Time.time - lastSkillTime > 1.0f)
        {
            avatar.SetBool("Skill", true);
            lastSkillTime = Time.time;
            playerAttack.SkillAttack(); // 20240314 �÷��̾�������κ��� ��ų ���� ȣ��
        }
    }

    public void OnSkillUp()
    {
        avatar.SetBool("Skill", false);
    }

    /// <summary>
    /// ��ư 2�� ��ų
    /// </summary>
    public void OnDashDown()
    {
        if (Time.time - lastSkillTime > 1.0f)
        {
            
            lastSkillTime = Time.time;
            dashing = true;
            avatar.SetTrigger("Dash");
            playerAttack.DashAttack(); // 20240314 �÷��̾�������κ��� �뽬 ���� ȣ��
        }
    }

    public void OnDashUp()
    {
        dashing = false;
    }


    #endregion


}


