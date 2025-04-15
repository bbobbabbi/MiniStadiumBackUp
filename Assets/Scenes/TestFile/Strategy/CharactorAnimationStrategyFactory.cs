using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAnimationStrategyFactory : MonoBehaviour
{
    public  IWeaponAnimationStrategy CreateStrategy(Weapon weapon)
    {
        switch (weapon.WeaponType)
        {
            case WeaponType.Sword:
                return new SwordAnimationStrategy();
            case WeaponType.Gun:
                return new GunAnimationStrategy();
        }
        return null;
    }
}
