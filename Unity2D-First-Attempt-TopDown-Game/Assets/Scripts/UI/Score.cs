using System;
using UnityEngine;
using TMPro;


namespace UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text pointText;
        
        private int _points;
    
        public void AddPoints(int addPoints)
        {
            _points += addPoints;
            pointText.text =  _points + "pt";
        }
    }
}
