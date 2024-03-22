using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject[] enemy;
    public float spawnTime = 3;
    public Transform[] spawnPoints;
    
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        //value = "함수이름", 딜레이시간, 반복시간
        //해당 함수를 딜레이 시간 이후에 호출하고, 반복 시간을 주기로 해당 함수를 반복적으로 호출함
        //즉 Invoke event 함수를 딜레이 시간이랑 반복시간을 통해서 계속 실행시켜주는 함수
    }

    void Spawn()
    {
        int enemyCount =  Random.Range(0,enemy.Length);
        if (playerHealth.currentHealth <= 0) return;


        int spawnPoolIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy[enemyCount], spawnPoints[spawnPoolIndex].position, spawnPoints[spawnPoolIndex].rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
