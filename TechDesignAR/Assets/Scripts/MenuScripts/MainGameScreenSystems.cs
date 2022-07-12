using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScreenSystems : MonoBehaviour
{
    [Header("Canvas Systems")]
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] GameObject gameOverCanvas;

    [Header("Score Systems")]
    [SerializeField] Text scoreText;
    public int score = 0;

    [Header("Timer Systems")]
    [SerializeField] Text timerText;
    public float timer = 60;

    // Update is called once per frame
    void Update()
    {
       if (timer > 0)
       {
            scoreText.text = "SCORE: " + $@"{score}";
            timerText.text = "TIME: " + $@"{timer -= Time.deltaTime:F0}";
       }
       
       else
       {
            gameOverCanvas.SetActive(true);
            timer = 0;
       }
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseMenuCanvas.SetActive(true);
    }
}
