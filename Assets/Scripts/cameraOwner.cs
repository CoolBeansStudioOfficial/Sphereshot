using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class cameraOwner : NetworkBehaviour
{
    [SerializeField] private GameObject owner;
    void Start()
    {
        if (IsOwner)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraControl>().SetTarget(owner);
        }
    }
}
