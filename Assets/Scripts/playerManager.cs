using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Unity.Netcode;


public class playerManager : NetworkBehaviour
{
    [SerializeField] private playerMovement character;
    [SerializeField] private float maxHealth;
    [SerializeField] private Vector2 respawnPoint;

    private float health;

    void Start()
    {
        if (!IsOwner)
        {
            enabled = false;
        }

        health = maxHealth;
    }

    //damage player and return true if damage causes death
    [Rpc(SendTo.Owner)]
    public void DamageRpc(float damage)
    {
        print("you just got DAMAGED");
        health -= damage;

        if (health <= 0)
        {
            character.TeleportRpc(respawnPoint);
            health = maxHealth;
            //tell everyone you died
        }
        else
        {
            //do whatever is needed (or do nothing and remove the else loop idk we'll see)
        }
    }
}
