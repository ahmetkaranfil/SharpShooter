using UnityEngine;

[CreateAssetMenu(fileName = "SilahSO", menuName = "ScriptableObjects/SilahSO")] 

public class SilahSO : ScriptableObject
{
    public GameObject silahPrefab;
    public int Damage = 1;
    public float FireRate = 0.5f;
    public GameObject HitVFXPrefab;
    public bool IsAutomatic = false;
    public bool CanZoom = false;
}
