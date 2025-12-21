using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Düşman : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;
    GameManager gameManager;

    const string PLAYER_STRING = "Oyuncu";

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        if(!player) return;
        agent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_STRING))
        {
            DüşmanSağlığı düşmanSağlığı = GetComponent<DüşmanSağlığı>();
            gameManager.UpdateEnemiesLeft(-1);
            düşmanSağlığı.SelfDestruct();
        }
    }
}
