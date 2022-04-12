using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour
{
    private Quaternion _startRotation;

    public float swayAmount = 8;

    void Start()
    {
        _startRotation = transform.localRotation;
    }

    void Update()
    {
        Sway();
    }

    private void Sway()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Quaternion xAngle = Quaternion.AngleAxis(mouseX * -1.25f, Vector3.up);
        Quaternion yAngle = Quaternion.AngleAxis(mouseY * -1.25f, Vector3.right);

        Quaternion targetRotation = _startRotation * xAngle * yAngle;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * swayAmount);

    }
}
