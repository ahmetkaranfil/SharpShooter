using Cinemachine;
using UnityEngine;

public class OyuncuSağlığı : MonoBehaviour
{
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;

    int currentHealth;
    int gameOverVirtualCameraPriority = 20;

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
            weaponCamera.parent = null;
            deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
            Destroy(this.gameObject);
        }
    }
}
