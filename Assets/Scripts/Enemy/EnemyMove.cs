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
        //���忡�� Player�±׸� ���� ������Ʈ�� ������ �� ������Ʈ�� �������� ������ ����
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //�������� ������ �ִ� NavMeshAgent ���� ����
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
