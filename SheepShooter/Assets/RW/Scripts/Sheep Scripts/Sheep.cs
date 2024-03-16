using UnityEngine;
using UnityEngine.Events;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    public float destroyY = -5f;

    public UnityEvent OnHitByHay = new UnityEvent();
    public UnityEvent OnDropped = new UnityEvent();

    private void Awake()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(Vector3.back * runSpeed * Time.deltaTime);

        if (transform.position.y < destroyY)
        {
            Debug.Log("Hit ground");
            Drop();
        }
    }

    private void HitByHay()
    {
        OnHitByHay.Invoke();
        Destroy(gameObject);
    }

    private void Drop()
    {
        OnDropped.Invoke();
        Destroy(gameObject, dropDestroyDelay);
        Debug.Log("Is this going bye");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Does it get this far");
        if (other.CompareTag("Hay"))
        {
            Debug.Log("Comparing the tag working");
            Destroy(other.gameObject);
            HitByHay();
        }
    }
}
