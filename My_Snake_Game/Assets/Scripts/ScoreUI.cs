using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


namespace SnakeGameNS
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        // Start is called before the first frame update
        void Start()
        {
            SetScoreText(0);
        }

        public void SetScoreText(int points)
        {
            scoreText.text = "Score: " +  points.ToString();
        }

    }
}
