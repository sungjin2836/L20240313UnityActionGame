using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;



    private void Awake()
    {
        //월드에서 Player태그를 가진 오브젝트를 조사해 그 오브젝트의 프랜스폼 값으로 설정
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //슬라임이 가지고 있는 NavMeshAgent 값에 접근
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(nav.enabled)
        {
            nav.SetDestination(player.position);
        }
    }

    public void SpeedUp()
    {
        if (nav.enabled)
        {
            nav.speed++;
            nav.angularSpeed++;
        }
    }
}
