using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotatorSystems : MonoBehaviour
{
    [Header("Camera Rotation System")]
    [SerializeField] float rotateSpeed = 10;
    [SerializeField] KeyCode rotateLeftKey;
    [SerializeField] KeyCode rotateRightKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(rotateLeftKey))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(rotateRightKey))
        {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }
    }
}
