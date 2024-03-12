using UnityEngine;

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
        myCollider = GetComponent<BoxCollider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void SetTarget(GameObject targetObject)
    {
        this.target = targetObject;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * runSpeed * Time.deltaTime);
        }
    }

    private void HitByHay()
    {
        Destroy(gameObject);
    }

    private void Drop()
    {
        dropped = true;
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay"))
        {
            Destroy(other.gameObject);
            HitByHay();
        }
        else if (other.CompareTag("DropSheep") && !dropped)
        {
            Drop();
        }
    }
}
