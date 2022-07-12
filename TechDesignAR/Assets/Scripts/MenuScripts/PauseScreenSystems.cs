using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenSystems : MonoBehaviour
{
    public void ResumeButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void VisitWebsiteButton()
    {
        Application.OpenURL("https://www.jarrettpierson.com/");
    }

    public void QuitButton()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
