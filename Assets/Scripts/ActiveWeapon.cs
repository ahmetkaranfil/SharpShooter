using UnityEngine;
using StarterAssets;
using System;
using Cinemachine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] SilahSO silahSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;

    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Silah currentWeapon;

    const string Shoot_String = "Shoot";

    float timeSinceLastShot = 0f;
    float defaultFOV;
    float defaultRotationSpeed;
    
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
            zoomVignette.SetActive(true);
            playerFollowCamera.m_Lens.FieldOfView = silahSO.ZoomAmount;
            firstPersonController.ChangeRotationSpeed(silahSO.ZoomRotationSpeed);
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
