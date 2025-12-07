using UnityEngine;

[CreateAssetMenu(fileName = "SilahSO", menuName = "ScriptableObjects/SilahSO")] 

public class SilahSO : ScriptableObject
{
    public int Damage = 1;
    public float FireRate = 0.5f;
    public GameObject HitVFXPrefab;
}
