using UnityEngine;

public class OyuncuSağlığı : MonoBehaviour
{
    [SerializeField] int startingHealth = 5;

    int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(amount + " hasar alındı");

        if(currentHealth <= 0)
        {    
            Destroy(this.gameObject);
        }
    }
}
