using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerSystems : MonoBehaviour
{
    [Header("Spawner Systems")]
    [SerializeField] Transform[] spawners;
    [SerializeField] GameObject tank;

    [SerializeField] int numberOfSpawners = 2;

    [SerializeField] float spawnTimer = 4;
    [SerializeField] float currentTimer = 4;
    
    private MainGameScreenSystems mainGameScreenSystems;

    // Start is called before the first frame update
    void Start()
    {
        mainGameScreenSystems = GameObject.FindGameObjectWithTag("MainGameScreen").GetComponent<MainGameScreenSystems>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainGameScreenSystems.timer > 0)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                for (int i = 0; i < numberOfSpawners; i++)
                {
                    int index = Random.Range(0, spawners.Length);
                    Vector3 tankInstantiateSpot = new Vector3(spawners[index].position.x + Random.Range(-1f,1f), spawners[index].position.y, spawners[index].position.z + Random.Range(-1f, 1f));
                    
                    GameObject enemy = Instantiate(tank, tankInstantiateSpot, spawners[index].rotation);
                    enemy.transform.SetParent(GameObject.FindGameObjectWithTag("Parent").transform);
                }

                spawnTimer = currentTimer;
            }

            switch (mainGameScreenSystems.timer)
            {
                case float n when n > 50:
                    numberOfSpawners = 1;
                    break;
                case float n when n > 40:
                    numberOfSpawners = 2;
                    break;
                case float n when n > 20:
                    numberOfSpawners = 3;
                    break;
                case float n when n > 10:
                    numberOfSpawners = 4;
                    break;
            }
        }
    }
}
