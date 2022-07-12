using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTongueSystems : MonoBehaviour
{
    [Header("What Type of Game Object are You?")]
    [SerializeField] bool isAnEnemy;
    [SerializeField] bool isABuilding;

    [Header("Building Systems")]
    [SerializeField] int buildingHealth = 4;
    [SerializeField] GameObject[] destroyBuildings;
    [SerializeField] int changeBuilding = 0;

    [Header("Score Systems")]
    [SerializeField] MainGameScreenSystems mainGameScreenSystems;

    // Start is called before the first frame update
    void Start()
    {
        mainGameScreenSystems = GameObject.FindGameObjectWithTag("MainGameScreen").GetComponent<MainGameScreenSystems>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buildingHealth <= 1)
        {
            mainGameScreenSystems.score += 100;
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("TongueTip") && isAnEnemy)
        {
            mainGameScreenSystems.score += 10;
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("TongueTip") && isABuilding)
        {
            mainGameScreenSystems.score += 50;
            buildingHealth--;
            destroyBuildings[changeBuilding].SetActive(false);
            changeBuilding++;
            destroyBuildings[changeBuilding].SetActive(true);
        }
    }
}
