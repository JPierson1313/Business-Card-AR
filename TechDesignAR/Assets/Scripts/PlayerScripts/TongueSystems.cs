using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSystems : MonoBehaviour
{
    [Header("Player Systems Script and Variables")]
    [SerializeField] PlayerSystems playerSystems;
    [SerializeField] Transform mouthTip;
    [SerializeField] float moveSpeed = 50;
    
    Transform currentTarget;

    [Header("Player Systems")]
    [SerializeField] GameObject playerIdlePose;
    [SerializeField] GameObject playerAttackPose;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (currentTarget == null)
        {
            currentTarget = GameObject.FindGameObjectWithTag("Target").transform;
        }

        playerIdlePose.SetActive(false);
        playerAttackPose.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerSystems.isTongueReady && !playerSystems.hasHitTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        }

        else if (!playerSystems.isTongueReady && playerSystems.hasHitTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, mouthTip.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject);
            currentTarget = null;
            playerSystems.hasHitTarget = true;
        }

        else if(other.gameObject.CompareTag("Mouth") && !playerSystems.isTongueReady && playerSystems.hasHitTarget)
        {
            playerSystems.isTongueReady = true;
            playerSystems.hasHitTarget = false;
            gameObject.SetActive(false);
            playerIdlePose.SetActive(true);
            playerAttackPose.SetActive(false);
            GetComponent<TongueSystems>().enabled = false;
        }
    }
}
