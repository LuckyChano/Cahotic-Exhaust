using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{

    public float mouseSens = 100f;

    public Transform playerBody;

    private CharMovement _player;

    public FootSensor footSensor;

    float YmovSens = 0.08f
        , YRange = 0.15f
        , YlocalPos;

    float xRotation = 0f;

    float ellapsedTime;


    private void Start()
    {
        YlocalPos = transform.localPosition.y;

        _player = GetComponentInParent<CharMovement>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    protected private void Update()
    {
        if(_player.canMove)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

            playerBody.Rotate(Vector3.up * mouseX);

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            
            if (_player.isMoving && !footSensor.isGrownded)
            {
                CamSineWave(YRange, YmovSens, YlocalPos);
            }
        }
    }

    public void CamSineWave(float amp, float b, float k)
    {
        if(ellapsedTime >= 1000)
        {
            ellapsedTime = 0;
        }
        float YPos = amp * Mathf.Sin((ellapsedTime - 1) / b) + k;
        ellapsedTime += Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x, YPos, transform.localPosition.z);

    }
}
