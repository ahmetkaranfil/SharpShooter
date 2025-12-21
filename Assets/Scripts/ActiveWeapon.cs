using UnityEngine;
using StarterAssets;
using System;
using Cinemachine;
using TMPro;

public class ActiveWeapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SilahSO startingSilahSO;
    [SerializeField] private CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] private Camera weaponCamera;
    [SerializeField] private GameObject zoomVignette;
    [SerializeField] private TMP_Text ammoText;

    private SilahSO currentSilahSO;
    private Silah currentWeapon;

    private Animator animator;
    private StarterAssetsInputs starterAssetsInputs;
    private FirstPersonController firstPersonController;

    private const string Shoot_String = "Shoot";

    private float timeSinceLastShot = 0f;
    private float defaultFOV;
    private float defaultRotationSpeed;

    private int currentAmmo;

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

        if (currentAmmo > currentSilahSO.MagazineSize)
        {
            currentAmmo = currentSilahSO.MagazineSize;
        }

        ammoText.text = currentAmmo.ToString("D2");
    }

    public void SwitchWeapon(SilahSO silahSO)
    {
        Debug.Log("Oyuncunun elindeki silah: " + silahSO.name);

        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Silah newSilah = Instantiate(
            silahSO.silahPrefab,
            transform
        ).GetComponent<Silah>();

        currentWeapon = newSilah;
        currentSilahSO = silahSO;

        AdjustAmmo(currentSilahSO.MagazineSize);
    }

    void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (!starterAssetsInputs.shoot)
            return;

        if (timeSinceLastShot >= currentSilahSO.FireRate && currentAmmo > 0)
        {
            currentWeapon.Shoot(currentSilahSO);
            animator.Play(Shoot_String, 0, 0f);

            timeSinceLastShot = 0f;
            AdjustAmmo(-1);
        }

        if (!currentSilahSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    void HandleZoom()
    {
        if (!currentSilahSO.CanZoom)
            return;

        if (starterAssetsInputs.zoom)
        {
            Debug.Log("Zoom Yapildi.");

            playerFollowCamera.m_Lens.FieldOfView = currentSilahSO.ZoomAmount;
            weaponCamera.fieldOfView = currentSilahSO.ZoomAmount;

            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(
                currentSilahSO.ZoomRotationSpeed
            );
        }
        else
        {
            Debug.Log("Zoom Yapilamadi.");

            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            weaponCamera.fieldOfView = defaultFOV;

            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }
    }
}
