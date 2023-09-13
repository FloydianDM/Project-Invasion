using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Invasion
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject enemyDeathEffect;
        [SerializeField] private int enemyHitScore = 5;
        [SerializeField] private int enemyHitPoint = 15;

        private Score _score;
        private Rigidbody _enemyRigidBody;
        private Transform _parentForSpawned;

        private void Start()
        {
            _score = FindObjectOfType<Score>();
            _enemyRigidBody = gameObject.AddComponent<Rigidbody>();
            _enemyRigidBody.useGravity = false;
            _parentForSpawned = GameObject.FindGameObjectWithTag("Spawn").transform;
        }
        
        private void OnParticleCollision(GameObject other)
        {
            ProcessHit();
        }
        
        private void ProcessHit()
        {
            GameObject fx = Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
            fx.transform.parent = _parentForSpawned;
            enemyHitPoint -= enemyHitScore;

            if (enemyHitPoint == 0)
            {
                ProcessKill();
            }
        }

        private void ProcessKill()
        {
            GameObject fx = Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
            fx.transform.parent = _parentForSpawned;
            Destroy(gameObject);
            _score.AddScore(enemyHitScore);
        }
    }
}
