using UnityEngine;

public class OtomatikSilahMermisi : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] GameObject otomatikSilahMermisiVFX;
    Rigidbody rb;

    int damage;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter(Collider other)
    {
        OyuncuSağlığı oyuncuSağlığı = other.GetComponent<OyuncuSağlığı>();
        oyuncuSağlığı?.TakeDamage(damage);

        Instantiate(otomatikSilahMermisiVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}