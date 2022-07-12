using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenSystems : MonoBehaviour
{
    [Header("Scene Name")]
    [SerializeField] string sceneName;

    [Header("Score Systems")]
    [SerializeField] Text scoreText;
    [SerializeField] int score = 0;
    [SerializeField] Text hiScoreText;
    [SerializeField] int hiScore = 0;
    private string hiScoreKey = "HiScore";

    private MainGameScreenSystems mainGameScreenSystems;
    private GameObject mainGameScreen;

    // Start is called before the first frame update
    void Start()
    {
        mainGameScreenSystems = GameObject.FindGameObjectWithTag("MainGameScreen").GetComponent<MainGameScreenSystems>();
        mainGameScreen = GameObject.FindGameObjectWithTag("MainGameScreen");

        score = mainGameScreenSystems.score;
        scoreText.text = "SCORE\n" + $@"{score}";
        hiScore = PlayerPrefs.GetInt(hiScoreKey, 0);
        Destroy(mainGameScreen);
        
        if (score > hiScore)
        {
            hiScore = score;
            hiScoreText.text = "HI-SCORE\n" + $@"{hiScore} " + "NEW!";
            PlayerPrefs.SetInt(hiScoreKey, score);
            PlayerPrefs.Save();
        }

        else
        {
            hiScoreText.text = "HI-SCORE\n" + $@"{hiScore}";
        }
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void VisitWebsiteButton()
    {
        Application.OpenURL("https://www.jarrettpierson.com/");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
