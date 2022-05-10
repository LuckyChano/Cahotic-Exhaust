using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove
{
    private FootSensor _footSensor;
    private Transform _transform;
    private Rigidbody _rb;
        
    public bool isMoving;
    public bool canMove;
    
    private float _walkSpeed;
    private float _runSpeedMultiplier;
    private float _jumpForce;
    private float _dashForce;
    
    private Vector3 _inputVector;
    
    private bool _canDash = true;

    public PlayerMove(Transform transform, Rigidbody rb, float walkSpeed, float runSpeedMultiplier, float jumpForce, float dashForce)
    {
        _transform = transform;
        _rb = rb;
        _walkSpeed = walkSpeed;
        _runSpeedMultiplier = runSpeedMultiplier;
        _jumpForce = jumpForce;
        _dashForce = dashForce;

        canMove = true;
        isMoving = false;
    }

    public void Move(float verAxis, float horAxis)
    {
        _inputVector.x = horAxis;
        _inputVector.z = verAxis;
        _inputVector.y = 0;

        if (_inputVector.magnitude > 1)
        {
            _inputVector.Normalize();
        }

        if (verAxis != 0 || horAxis != 0)
        {
            isMoving = true;
        }
        else isMoving = false;
    }

    public void Run()
    {
        _inputVector *= _runSpeedMultiplier;
    }

    public void FixedMove()
    {
        if (_inputVector.magnitude > 0)
        {
            _rb.MovePosition(_rb.position + (_transform.right * _inputVector.x + _transform.forward * _inputVector.z) * _walkSpeed * Time.deltaTime);
        }
    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public IEnumerator Dash(float verAxis, float horAxis)
    {

        if (horAxis != 0 && verAxis == 0)
            _rb.AddForce((_transform.right * horAxis).normalized * _dashForce, ForceMode.Impulse);
        if (horAxis == 0 && verAxis != 0)
            _rb.AddForce((_transform.forward * verAxis).normalized * _dashForce, ForceMode.Impulse);
        if (horAxis == 0 && verAxis == 0)
            _rb.AddForce((_transform.forward * 1).normalized * _dashForce, ForceMode.Impulse);
        _canDash = false;

        yield return new WaitForSeconds(2f);
        _canDash = true;
    }
}
