using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreenSystems : MonoBehaviour
{
    [Header("Activate Objects")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject buildingSpawner;
    [SerializeField] GameObject mainGameScreenCanvas;

    public void StartGameButton()
    {
        player.SetActive(true);
        buildingSpawner.SetActive(true);
        mainGameScreenCanvas.SetActive(true);
        Destroy(gameObject);
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
