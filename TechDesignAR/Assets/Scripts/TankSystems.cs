using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSystems : MonoBehaviour
{
    [Header("Firing Systems")]
    [SerializeField] GameObject projectile;
    [SerializeField] Transform barrelEnd;
    [SerializeField] float fireTimer = 2;
    [SerializeField] float currentTimer = 2;
    [SerializeField] float fireSpeed = 100;

    [Header("Move Systems")]
    [SerializeField] float moveSpeed = 1;

    [Header("Distance Systems")]
    [SerializeField] float distanceToTarget;
    Transform target;

    private MainGameScreenSystems mainGameScreenSystems;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mainGameScreenSystems = GameObject.FindGameObjectWithTag("MainGameScreen").GetComponent<MainGameScreenSystems>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainGameScreenSystems.timer > 0)
        {
            AttackSystems();
        }

        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < 3)
        {
            moveSpeed = 0;
        }

        else
        {
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    void AttackSystems()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer < 0)
        {
            GameObject tankShell = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);
            tankShell.transform.SetParent(GameObject.FindGameObjectWithTag("Parent").transform);
            tankShell.GetComponent<Rigidbody>().AddForce(barrelEnd.forward * fireSpeed);
            fireTimer = currentTimer;
        }
    }
}
