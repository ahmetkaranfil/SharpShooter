using UnityEngine;

public class ToplanabilirMermiler : Toplanabilirler
{
    [SerializeField] int mermiSayisi = 90;
    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmo(mermiSayisi);
    }
}
