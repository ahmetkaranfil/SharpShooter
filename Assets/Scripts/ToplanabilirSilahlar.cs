using UnityEngine;

public class ToplanabilirSilahlar : MonoBehaviour
{
    [SerializeField] SilahSO silahSO;

    const string PLAYER_STRING = "Player";

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_STRING))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            activeWeapon.SwitchWeapon(silahSO);
            Destroy(this.gameObject);
        }
    }
}
