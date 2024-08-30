using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/New Weapon")]
public class Weapon : ScriptableObject
{
    public string description;
    public float damage;
    public float delay;
    public float ammo;
    public float falloff;

    public string GetDescription()
    {
        return description;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetDelay()
    {
        return delay;
    }

    public float GetAmmo()
    {
        return ammo;
    }

    public float GetFalloff()
    { 
        return falloff; 
    }
}
