using UnityEngine;
using StarterAssets;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] SilahSO silahSO;

    Animator animator;
    StarterAssetsInputs starterAssetsInputs; 
    Silah currentWeapon;

    const string Shoot_String = "Shoot";

    float timeSinceLastShot = 0f;
    
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentWeapon = GetComponentInChildren<Silah>();
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        HandleShoot();
    }

    public void SwitchWeapon(SilahSO silahSO)
    {
        Debug.Log("Oyuncu şunu elde etti: " + silahSO.name);
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        if (timeSinceLastShot >= silahSO.FireRate)
        {
            currentWeapon.Shoot(silahSO);
            animator.Play(Shoot_String, 0, 0f);
            timeSinceLastShot = 0f;
        }

        if(!silahSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }

    }
}
