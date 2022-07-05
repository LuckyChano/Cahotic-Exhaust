using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGun : MonoBehaviour
{
    [SerializeField]
    public int _speed;
    [SerializeField]
    private Transform gunPos;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gunPos.RotateAround(gunPos.position, Vector3.down, _speed * Time.fixedDeltaTime);
    }
}
