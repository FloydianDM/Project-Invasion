using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Invasion
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private GameObject[] lasers;

        private PlayerController _playerController;

        private void Start()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            ProcessFire();
        }

        private void ProcessFire()
        {
            foreach (GameObject laser in lasers)
            {
                laser.SetActive(_playerController.isLaserActive);
            }
        }
    }
}

