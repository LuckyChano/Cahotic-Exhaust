using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionLampara : MonoBehaviour
{
    [SerializeField]
    int _speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.down, _speed * Time.fixedDeltaTime);
    }
}
