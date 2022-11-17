using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] GameObject _weaponLogic;
    public void EnableWeapon()
    {
        _weaponLogic.SetActive(true);
    }
    public void DisableWeapon()
    {
        _weaponLogic.SetActive(false);
    }
    
}
