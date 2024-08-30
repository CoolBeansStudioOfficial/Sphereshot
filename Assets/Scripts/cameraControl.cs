using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;

    public GameObject target;
    private Vector3 offset;

    void Start()
    {
        offset.x = offsetX;
        offset.y = offsetY;
        offset.z = transform.position.z;
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = target.transform.position + offset;
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
