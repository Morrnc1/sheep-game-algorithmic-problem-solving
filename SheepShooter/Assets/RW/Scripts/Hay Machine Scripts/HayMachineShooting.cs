using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachineShooting : MonoBehaviour
{

    public GameObject hayBalePrefab;
    public Transform haySpawnPoint;
    public float shootCooldown = 0.5f;
    private float shootTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                shootTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && shootTimer <= 0f)
        {
            Shooting();
            shootTimer = shootCooldown;
        }

        void Shooting()
        {
            GameObject.Instantiate(hayBalePrefab, haySpawnPoint.position + new Vector3(0, 2, 0), Quaternion.identity); // can add a vectore as long as you state new

        }
    }
}
