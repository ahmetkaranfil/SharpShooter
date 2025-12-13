using UnityEngine;

public class DüşmanSağlığı : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;
    [SerializeField] GameObject RobotExplosionVFX;

    int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Instantiate(RobotExplosionVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
