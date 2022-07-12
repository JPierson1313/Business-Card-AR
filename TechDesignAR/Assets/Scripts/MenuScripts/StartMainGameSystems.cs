using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMainGameSystems : MonoBehaviour
{
    [Header("Main Game Objects")]
    [SerializeField] PlayerSystems playerSystems;
    [SerializeField] GameObject tankSpawner;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerSystems.enabled = true;
            tankSpawner.SetActive(true);
            Destroy(gameObject);
        }
    }
}
