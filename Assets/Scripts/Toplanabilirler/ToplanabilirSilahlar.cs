using UnityEngine;

public class ToplanabilirSilahlar : Toplanabilirler
{
    [SerializeField] SilahSO silahSO;

    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(silahSO);
    }
}
