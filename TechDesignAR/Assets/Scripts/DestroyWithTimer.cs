using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithTimer : MonoBehaviour
{
    [Header("Countdown Timer Unitl Destruction")]
    [SerializeField] float countdownTimer = 4;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, countdownTimer);    
    }
}
