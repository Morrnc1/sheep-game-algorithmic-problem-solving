using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachineMovement : MonoBehaviour
{
    public float hayMachineMovement; 
    public float hayMachineBoundarys = 22;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0 && transform.position.x > -hayMachineBoundarys + 2)
        {
            transform.Translate(Vector3.right * -hayMachineMovement * Time.deltaTime);

        }
        else if (horizontalInput > 0 && transform.position.x < hayMachineBoundarys + 1)
        {
            transform.Translate(Vector3.right * hayMachineMovement * Time.deltaTime);
        }
    }
}
