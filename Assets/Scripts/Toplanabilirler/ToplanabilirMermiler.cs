using UnityEngine;

public class ToplanabilirMermiler : Toplanabilirler
{
    [SerializeField] int mermiSayisi = 100;
    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmo(mermiSayisi);
    }
}
