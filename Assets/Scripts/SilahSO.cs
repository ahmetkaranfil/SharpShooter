using UnityEngine;

[CreateAssetMenu(fileName = "SilahSO", menuName = "ScriptableObjects/SilahSO")] 

public class SilahSO : ScriptableObject
{
    public int Damage = 1;
    public float fireRate = 0.5f;
}
