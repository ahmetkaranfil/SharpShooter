using UnityEngine;
using StarterAssets;

public class Silah : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damageAmount = 1;
    StarterAssetsInputs starterAssetsInputs; 
    
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        muzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            DüşmanSağlığı enemyHealth = hit.collider.GetComponent<DüşmanSağlığı>();
            if (enemyHealth)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
            starterAssetsInputs.ShootInput(false);
        }
    }
}
