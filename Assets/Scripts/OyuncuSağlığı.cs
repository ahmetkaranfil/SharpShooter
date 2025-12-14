using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
public class OyuncuSağlığı : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;

    int currentHealth;
    int gameOverVirtualCameraPriority = 20;

    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldBar();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        AdjustShieldBar();

        Debug.Log(amount + " hasar alındı");

        if(currentHealth <= 0)
        {    
            weaponCamera.parent = null;
            deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
            Destroy(this.gameObject);
        }
    }

    void AdjustShieldBar()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}
