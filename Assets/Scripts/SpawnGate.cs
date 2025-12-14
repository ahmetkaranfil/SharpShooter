using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject düşmanPrefab;
    [SerializeField] float spawnTime = 3f;
    [SerializeField] Transform spawnPoint;

    OyuncuSağlığı oyuncuSağlığı;

    void Start()
    {
        oyuncuSağlığı = FindFirstObjectByType<OyuncuSağlığı>();
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (oyuncuSağlığı)
        {
            Instantiate(düşmanPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}