using UnityEngine;
using System.Collections;

public class OtomatikSilah : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform tarretHead;
    [SerializeField] GameObject turretBulletPrefab;
    [SerializeField] Transform turretBulletSpawnPoint;
    [SerializeField] Transform playerTargetPoint;

    [Header("Settings")]
    [SerializeField] float fireRate = 2f;
    [SerializeField] int damage = 1;

    private OyuncuSağlığı oyuncu;

    void Start()
    {
        oyuncu = FindFirstObjectByType<OyuncuSağlığı>();
        StartCoroutine(FireTurret());
    }

    void Update()
    {
        tarretHead.LookAt(playerTargetPoint);
    }

    IEnumerator FireTurret()
    {
        while (oyuncu)
        {
            yield return new WaitForSeconds(fireRate); // Adjust fire rate as needed

            OtomatikSilahMermisi otomatikSilahMermisi =
                Instantiate(
                    turretBulletPrefab,
                    turretBulletSpawnPoint.position,
                    Quaternion.identity
                ).GetComponent<OtomatikSilahMermisi>();

            otomatikSilahMermisi.transform.LookAt(playerTargetPoint);
            otomatikSilahMermisi.Init(damage);
        }
    }
}
