using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawnerSystems : MonoBehaviour
{
    [Header("Spawner Systems")]
    public Transform[] spawners;
    public GameObject[] buildings;
    public Transform buildingsParent;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            int index = Random.Range(0, 3);
            if (index == 0 || index == 2)
            {
                int randomBuildingIndex = Random.Range(0, buildings.Length);
                GameObject newBuilding = Instantiate(buildings[randomBuildingIndex], spawners[i].position, spawners[i].rotation);
                newBuilding.transform.SetParent(buildingsParent);
            }
        }
        Destroy(gameObject);
    }
}
