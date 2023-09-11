using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Project_Invasion
{
    public class Score : MonoBehaviour
    {
        private int _totalPoints;
        private TMP_Text _scoreText;

        private void Start()
        {
            _scoreText = GetComponent<TMP_Text>();
            _scoreText.text = "Start!";
        }
        
        public void AddScore(int pointsToIncrease)
        {
            _totalPoints += pointsToIncrease;
            _scoreText.text = _totalPoints.ToString();
        }
    }
}


