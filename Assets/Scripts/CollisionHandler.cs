using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Project_Invasion
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private ParticleSystem crashEffects;
        
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            crashEffects.Play();
            StartCoroutine(_gameManager.ReloadLevel());
        }
    }
}

