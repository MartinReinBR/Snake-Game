using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


namespace SnakeGameNS
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI highscoreText;

        private void Start()
        {
            highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore");
        }

        public void OnStartButton()
        {
            SceneManager.LoadScene(1);
        }

        public void OnQuitButton()
        {
            Application.Quit();
            Debug.Log("Quit");
        }


    }
}