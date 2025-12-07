using UnityEngine;

public class Silah : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;

    public void Shoot(SilahSO silahSO)
    {
        RaycastHit hit;
        muzzleFlash.Play();

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
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
