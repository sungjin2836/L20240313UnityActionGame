using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        //시작 체력
        public int startingHealth = 100;
        //현재 체력
        public int currentHealth;
        //체력 UI와 연결
        public Slider healthSlider;
        //데미지 받았을 때 화면 색 변경
        public Image damaeImage;
        //플레이어 데미지 받았을 때 재생할 오디오
        public AudioClip deathClip;

        //애니메이터에 전달
        Animator anim;
        //효과음 틀기 위한 컴포넌트
        AudioSource playerAudio;
        //플레이어 움직임 관리
        PlayerMovement playerMovement;
        //플레이어가 죽었는지에 대한 판단(플래그)
        bool isDead;

        //오브젝트 시작 시 호출되는 Awake, Start 전에 실행됨
        private void Awake()
        {
            anim = GetComponent<Animator>();
            playerAudio = GetComponent<AudioSource>();
            playerMovement = GetComponent<PlayerMovement>();
            currentHealth = startingHealth;
            healthSlider.value = currentHealth;
        }
        /// <summary>
        /// 플레이어가 공격을 받았을 때 호출되는 함수임
        /// </summary>
        /// <param name="amount">데미지 수치</param>
        public void TakeDamage(int amount)
        {
            currentHealth -= amount;

            healthSlider.value = currentHealth;

            if (currentHealth <= 0 && !isDead)
            {
                Death();
            }
            else
            {
                anim.SetTrigger("Damage");
            }
        }

        void Death()
        {
            isDead = true;
            anim.SetTrigger("Die");
            playerMovement.enabled = false;
        }

        void Update()
        {

        }

        


    }
}