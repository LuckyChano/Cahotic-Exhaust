using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway
{
    private Quaternion _startRotation;
    private GunBehaviour _gun;
    public float recoilAmount = 0.5f;
    public float currentRecoil = 0f;

    public float swayAmount = 8;
    public GunSway(GunBehaviour gun)
    {
        _gun = gun;
        _startRotation = gun.transform.localRotation;
    }

    public void Update()
    {
        Sway();
        currentRecoil -= Time.deltaTime * recoilAmount;
        currentRecoil = Mathf.Clamp(currentRecoil, 0f, 1f);
    }

    public void Sway()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Quaternion xAngle = Quaternion.AngleAxis(mouseX * -1.25f, Vector3.up);
        Quaternion yAngle = Quaternion.AngleAxis(mouseY * -1.25f, Vector3.right);

        Quaternion targetRotation = _startRotation * xAngle * yAngle;

        _gun.transform.localRotation = Quaternion.Lerp(_gun.transform.localRotation, targetRotation, Time.deltaTime * swayAmount);

    }


    public void Recoil()
    {
        var randomDir = Random.Range(1, 2);
        currentRecoil += recoilAmount;
        _gun.transform.Rotate(-currentRecoil * randomDir, randomDir, 0f);
    }
}
