using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class SkillTarget : MonoBehaviour
    {
        public List<Collider> targetList;

        void Start()
        {
            targetList = new List<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            targetList.Add(other);
        }

        private void OnTriggerExit(Collider other)
        {
            targetList.Remove(other);

        }
    }
}