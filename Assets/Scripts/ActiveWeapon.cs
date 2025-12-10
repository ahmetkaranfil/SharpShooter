using UnityEngine;
using StarterAssets;
using System;

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
        HandleShoot();
        HandleZoom();
    }

    public void SwitchWeapon(SilahSO silahSO)
    {
        Debug.Log("Oyuncu şunu elde etti: " + silahSO.name);

        if(currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Silah newSilah = Instantiate(silahSO.silahPrefab, transform).GetComponent<Silah>();
        currentWeapon = newSilah;
        this.silahSO = silahSO;
    }

    void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;
        
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

    void HandleZoom()
    {
        if(!silahSO.CanZoom) return;
        if(starterAssetsInputs.zoom)
        {
            Debug.Log("Zooming in");
        }
        else
        {
            Debug.Log("Not zooming in");
        }
    }
}   
