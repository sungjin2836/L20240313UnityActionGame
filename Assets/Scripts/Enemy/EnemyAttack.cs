﻿using Assets.Scripts.Player;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        public float timeBetweenAttacks = 0.5f;
        public int attackDamage = 0;

        GameObject player;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        bool playerInRange;
        float timer;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
        }

        void Update()
        {
            timer += Time.deltaTime;

            if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                Attack();
            }


        }

        void Attack()
        {
            timer = 0.0f;
            if(playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject == player)
            {
                Debug.Log("공격");
                playerInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject == player)
            {
                playerInRange = false;
            }
        }


    }
}