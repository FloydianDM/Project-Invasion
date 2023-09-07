using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Invasion
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject enemyDeathEffect;
        [SerializeField] private Transform parentForSpawned;
        [SerializeField] private int enemyHitScore = 5;

        private Score _score;

        private void Start()
        {
            _score = FindObjectOfType<Score>();
        }
        
        private void OnParticleCollision(GameObject other)
        {
            ProcessHit();
            ProcessKill();
        }
        
        private void ProcessHit()
        {
            _score.AddScore(enemyHitScore);
        }

        private void ProcessKill()
        {
            GameObject vfx = Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
            vfx.transform.parent = parentForSpawned;
            Destroy(gameObject);
        }
    }
}
