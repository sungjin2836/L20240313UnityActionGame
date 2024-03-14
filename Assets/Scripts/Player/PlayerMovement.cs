using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Animator에 대한 요구(반드시 필요)
//없을 경우 자동 추가
//Animator를 에디터에서 컴포넌트 제거할 수 없다.
//만약에 Animator 컴포넌트가 없다면 게임 실행조차 되지 않는다.
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{

    //게임 오브젝트 내에 연결되어 있는 Animator 컴포넌트를 가져와서 사용
    protected Animator avatar;
    protected PlayerAttack playerAttack; // 20240314 플레이어 공격 기능 추가
    float h;
    float v;

    //애니메이션 진행된 시간 체크용 변수
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
    /// 방향 컨트롤러에서 컨트롤러의 변경이 일어날 경우 호출할 함수
    /// </summary>
    /// <param name="stickPos">스틱의 좌표</param>

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
                    //해당 벡터 방향을 바라보는 회전 상태를 반환하는 코드
                }
            }
        }
    }

    #region EventTriger
    public void OnAttackDown()
    {
        attacking = true;
        avatar.SetBool("Combo", true);
        StartCoroutine(StartAttack());//코루틴을 작동시키는 코드
        //코루틴은 update가 아닌 영영에서 반복적으로 코드가 실행되어야 할 때 사용하면 효과좋음
        //Update에서 무분별하게 돌리는 코드를 코루틴으로 전환하면, 자워 관리에 효과적이다.
        //코루틴은 일정 시간 멈추고 뒤에 움직이는 작업, 특정 조건을 부여해 코드를 실행하는 작업에 용이
        //코루틴은 IEnumeric 형태의 함수를 시작합니다.
        //해당 함수 내부에섯 반드시 yield return문이 존재해야 합니다.

        //지연 함수로는 Invoke도 있지만, 이건 말 그대로 그 시간만큼 지연 후 함수 실행이라 코루틴과는 약간 다름
        //코루틴은 반복 루틴에서 탈출하고 다시 그 시점으로 돌아오는 것이 가능함

        //StartCoroutine("StartAttack");
    }

    public void OnAttackUp()
    {
        avatar.SetBool("Combo", false);
        attacking = false;
    }

    //yield문은 다음 요소를 제공하는 키워드임
    IEnumerator StartAttack()
    {
        if(Time.time - lastAttackTime > 1.0f)
        {
            lastAttackTime = Time.time;
            while( attacking )
            {
                avatar.SetTrigger("AttackStart");
                playerAttack.NormalAttack(); // 20240314 플레이어공격으로부터 일반 공격 호출
                yield return new WaitForSeconds(1.0f);
            }
        }
        
    }

    /// <summary>
    /// 버튼 1번 스킬
    /// </summary>
    public void OnSkillDown()
    {
        if(Time.time - lastSkillTime > 1.0f)
        {
            avatar.SetBool("Skill", true);
            lastSkillTime = Time.time;
            playerAttack.SkillAttack(); // 20240314 플레이어공격으로부터 스킬 공격 호출
        }
    }

    public void OnSkillUp()
    {
        avatar.SetBool("Skill", false);
    }

    /// <summary>
    /// 버튼 2번 스킬
    /// </summary>
    public void OnDashDown()
    {
        if (Time.time - lastSkillTime > 1.0f)
        {
            
            lastSkillTime = Time.time;
            dashing = true;
            avatar.SetTrigger("Dash");
            playerAttack.DashAttack(); // 20240314 플레이어공격으로부터 대쉬 공격 호출
        }
    }

    public void OnDashUp()
    {
        dashing = false;
    }


    #endregion


}


