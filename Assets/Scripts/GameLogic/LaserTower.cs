using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GameLogic
{
    /// <summary>
    /// 激光塔
    /// </summary>
    public class LaserTower : TowerBase
    {
        [SerializeField] private float attackRange = 10;
        [SerializeField] private float attackRate = 3; // 1.0f / 3 seconds attack interval time


        private float lastAttackTime; //上次攻击的时间


        private void Update()
        {
               
        }


        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            Handles.color = new Color(1, 0, 0, 0.2f);
            Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, 360, attackRange);
#endif
        }
    }
}