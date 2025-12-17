using UnityEngine;
using System.Collections;

public class OtomatikSilah : MonoBehaviour
{
    [SerializeField] Transform tarretHead;
    [SerializeField] GameObject turretBulletPrefab;
    [SerializeField] Transform turretBulletSpawnPoint;
    [SerializeField] Transform playerTargetPoint;
    
    [SerializeField] float fireRate = 2f;

    OyuncuSağlığı oyuncu;

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
            Instantiate(turretBulletPrefab, turretBulletSpawnPoint.position, tarretHead.rotation);
        }
    }
}
