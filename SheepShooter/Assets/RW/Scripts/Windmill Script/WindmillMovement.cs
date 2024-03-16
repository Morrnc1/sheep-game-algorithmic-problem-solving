using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillMovement : MonoBehaviour
{
    public float rotationSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0,rotationSpeed * Time.deltaTime,0);
    }
}
