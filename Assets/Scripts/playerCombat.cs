using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using Unity.Netcode;
using static UnityEngine.GraphicsBuffer;

public class playerCombat : NetworkBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private weaponObject weaponObj;
    [SerializeField] private GameObject sparks;

    private Vector2 mouseWorldPos;
    private Vector2 selfPos;
    private Vector2 offsetPos;
    private RaycastHit2D shot;
    private bool canShoot = true;

    void Start()
    {
        if (!IsOwner)
        {
            enabled = false;
        }
    }

    void Update()
    {
        //get position of mouse
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //point weapon object
        weaponObj.PointAt(mouseWorldPos);
        weaponObj.transform.position = transform.position;

        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            //OVERCOMPLICATED
            //get position of self
            selfPos = transform.position;
            //get difference between the two
            offsetPos = mouseWorldPos - selfPos;
            //slightly offset ray origin from self toward mouse (as not to hit self), then fire ray toward mouse
            shot = Physics2D.Raycast(offsetPos.normalized + selfPos, offsetPos);

            if (shot)
            {
                //Instantiate(sparks, shot.point, Quaternion.LookRotation(shot.normal));
                Instantiate(sparks, shot.point, Quaternion.identity);

                if (shot.collider.gameObject.tag == "Player")
                {
                    shot.collider.gameObject.GetComponentInParent<playerManager>().DamageRpc(weapon.damage);
                }
            }
            
            canShoot = false;
            Invoke("ShotDelay", weapon.delay);
        }
    }

    private void ShotDelay()
    {
        canShoot = true;
    }
}
