using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : MonoBehaviour
{
    [Header("Tongue Systems")]
    [SerializeField] LineRenderer tongueLine;
    [SerializeField] Transform tongueTip;
    [SerializeField] Transform tongueMouth;
    public bool isTongueReady = true;
    public bool hasHitTarget = false;

    public Transform target;

    private MainGameScreenSystems mainGameScreenSystems;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        tongueTip.gameObject.SetActive(false);
        mainGameScreenSystems = GameObject.FindGameObjectWithTag("MainGameScreen").GetComponent<MainGameScreenSystems>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRot;
        tongueLine.SetPosition(0, tongueTip.position);
        tongueLine.SetPosition(1, tongueMouth.position);

        if (Input.GetMouseButtonDown(0) && isTongueReady && !hasHitTarget)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Building") || hit.collider.CompareTag("Enemy")))
            {
                newRot = new Vector3(hit.point.x, 0.2f, hit.point.z);
                transform.LookAt(newRot);

                Transform targetArea = Instantiate(target, newRot, Quaternion.identity);
                targetArea.transform.SetParent(GameObject.FindGameObjectWithTag("Parent").transform);
                tongueTip.gameObject.SetActive(true);
                tongueTip.gameObject.GetComponent<TongueSystems>().enabled = true;
                isTongueReady = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            mainGameScreenSystems.score -= 25;
            Destroy(collision.gameObject);
        }
    }
}
