using System.Linq;
using UnityEngine;
using Unity.Netcode;
using System;

public class weaponObject : NetworkBehaviour
{
    private float AngleRad;
    private float AngleDeg;

    void Start()
    {
        if (!IsOwner)
        {
            enabled = false;
        }
    }

    public void PointAt(Vector2 lookPoint)
    {
        AngleRad = Mathf.Atan2(lookPoint.y - transform.position.y, lookPoint.x - transform.position.x);
        AngleDeg = (180 / Mathf.PI) * AngleRad;

        if (AngleDeg > 90 | AngleDeg < -90)
        {
            transform.rotation = Quaternion.Euler(180, 0, -AngleDeg);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }
        
    }

    public void SetSkin()
    {
        //future logic for weapon skins
    }
}
