using Cinemachine;
using UnityEngine;

public class Silah : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers;

    CinemachineImpulseSource impulseSource;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shoot(SilahSO silahSO)
    {
        RaycastHit hit;
        muzzleFlash.Play();
        impulseSource.GenerateImpulse();

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore))
        {
            Instantiate(silahSO.HitVFXPrefab, hit.point, Quaternion.identity);
            DüşmanSağlığı enemyHealth = hit.collider.GetComponent<DüşmanSağlığı>();
            if (enemyHealth)
            {
                enemyHealth.TakeDamage(silahSO.Damage);
            }
        }
    }
}
