using UnityEngine;
using UnityEngine.UIElements;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float dropDestroyDelay;
    private bool dropped;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    public GameObject target; 

    private void Awake()
    {
        myCollider = GetComponent<CapsuleCollider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void SetTarget(GameObject targetObject)
    {
        this.target = targetObject;
    }

   

     private void Update()
    {
        // Move forwards
        transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        // where the sound and feedback goes
        Destroy(gameObject);
    }

    private void Drop()
    {
        dropped = true;
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
        Debug.Log("is this going bye");
    }
    private Vector3 belowGround = new Vector3(-2,0,0);
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("does it get this far");
        if (other.CompareTag("Hay"))
        {
            Debug.Log("compearng the tag working");
            Destroy(other.gameObject);
            HitByHay();
        }
        else if ( == belowGround)
        {
            Debug.Log("hit ground");
            
            Drop();
        }
    }
}
