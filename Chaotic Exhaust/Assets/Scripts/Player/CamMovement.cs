using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform playerBody;

    private Player _player;
    
    public FootSensor footSensor;
    
    public float mouseSens = 100f;
        
    private float _xRotation = 0f;

    private float _YmovSens = 0.08f;
    private float _YRange = 0.15f;
    private float _YlocalPos;

    private float _ellapsedTime;

    private void Start()
    {
        _YlocalPos = transform.localPosition.y;

        _player = GetComponentInParent<Player>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    protected private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            
        if (_player.IsMoving && footSensor.isGrownded)
        {
            CamSineWave(_YRange, _YmovSens, _YlocalPos);
        }
    }

    public void CamSineWave(float amp, float b, float k)
    {
        if(_ellapsedTime >= 1000)
        {
            _ellapsedTime = 0;
        }
        float YPos = amp * Mathf.Sin((_ellapsedTime - 1) / b) + k;
        _ellapsedTime += Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x, YPos, transform.localPosition.z);
    }
}
