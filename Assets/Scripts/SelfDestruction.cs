using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Project_Invasion
{
    public class SelfDestruction : MonoBehaviour
    {
        private readonly float _timeToDestroy = 2.5f;
        private void Start()
        {
            Destroy(gameObject, _timeToDestroy);
        }
    }
}

