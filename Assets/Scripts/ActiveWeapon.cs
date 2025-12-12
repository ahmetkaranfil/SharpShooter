using UnityEngine;
using StarterAssets;
using System;
using Cinemachine;
using TMPro;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] SilahSO startingSilahSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;
    [SerializeField] TMP_Text ammoText;

    SilahSO currentSilahSO;
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Silah currentWeapon;

    const string Shoot_String = "Shoot";

    float timeSinceLastShot = 0f;
    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmo;
    
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        SwitchWeapon(startingSilahSO);
        AdjustAmmo(currentSilahSO.MagazineSize);
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;

        if(currentAmmo > currentSilahSO.MagazineSize)
        {
            currentAmmo = currentSilahSO.MagazineSize;
        }

        ammoText.text = currentAmmo.ToString("D2");
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
        this.currentSilahSO = silahSO;

        AdjustAmmo(currentSilahSO.MagazineSize);
    }

    void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;
        
        if (!starterAssetsInputs.shoot) return;

        if (timeSinceLastShot >= currentSilahSO.FireRate && currentAmmo > 0)
        {
            currentWeapon.Shoot(currentSilahSO);
            animator.Play(Shoot_String, 0, 0f);
            timeSinceLastShot = 0f;
            AdjustAmmo(-1);
        }

        if(!currentSilahSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    void HandleZoom()
    {
        if(!currentSilahSO.CanZoom) return;
        if(starterAssetsInputs.zoom)
        {
            Debug.Log("Zooming in");
            zoomVignette.SetActive(true);
            playerFollowCamera.m_Lens.FieldOfView = currentSilahSO.ZoomAmount;
            firstPersonController.ChangeRotationSpeed(currentSilahSO.ZoomRotationSpeed);
        }
        else
        {
            Debug.Log("Not zooming in");
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
            zoomVignette.SetActive(false);
        }
    }
}   
