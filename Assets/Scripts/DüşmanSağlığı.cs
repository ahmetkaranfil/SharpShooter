using UnityEngine;

public class DüşmanSağlığı : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;
    [SerializeField] GameObject RobotExplosionVFX;

    int currentHealth;

    GameManager gameManager;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.UpdateEnemiesLeft(1);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            gameManager.UpdateEnemiesLeft(-1);
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(RobotExplosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
