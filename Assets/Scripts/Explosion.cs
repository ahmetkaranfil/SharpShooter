using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    [SerializeField] int damage = 3; 

    void Start()
    {
        Explode();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hitCollider in hitColliders)
        {
            OyuncuSağlığı oyuncuSağlığı = hitCollider.GetComponent<OyuncuSağlığı>();
            if (oyuncuSağlığı)
            {
                oyuncuSağlığı.TakeDamage(damage);
            }
        }
    }
}
