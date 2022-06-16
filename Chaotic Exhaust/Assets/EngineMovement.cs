using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineMovement : MonoBehaviour
{
    [SerializeField]
    Transform _top;
    [SerializeField]
    Transform _mid;
    [SerializeField]
    Transform _bottom;
    [SerializeField]
    float _Tspeed, _Mspeed, _Bspeed;
    private Vector3 rotationVector;


    private void Start()
    {
       
    }

    private void FixedUpdate()       
    {
       
        _top.transform.RotateAround(transform.position, Vector3.down, -_Tspeed * Time.fixedDeltaTime);
        _mid.transform.RotateAround(transform.position, Vector3.down, _Mspeed * Time.fixedDeltaTime);
        _bottom.transform.RotateAround(transform.position, Vector3.down, _Bspeed * Time.fixedDeltaTime);

    }
}
