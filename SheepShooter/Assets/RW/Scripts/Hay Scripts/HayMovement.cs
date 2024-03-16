using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMovement : MonoBehaviour
{
     public Vector3 MovementSpeed = new Vector3(0f, 0f, 10f);
     
    void Start()
    {
        
    }


    private void Update()
    {
        transform.Translate(MovementSpeed * Time.deltaTime);
    }
}
