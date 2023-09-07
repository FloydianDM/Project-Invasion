using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Invasion
{
    public class Score : MonoBehaviour
    {
        private int _totalPoints;

        public void AddScore(int pointsToIncrease)
        {
            _totalPoints += pointsToIncrease;
        }
    }
}


