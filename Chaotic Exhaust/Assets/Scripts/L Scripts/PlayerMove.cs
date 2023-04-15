using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove
{
    private Transform _transform;
    private Rigidbody _rb;
    private FootSensor _footSensor;
    
    private float _walkSpeed;
    private float _runSpeedMultiplier;
    private float _jumpForce;
    private float _dashForce;
    private Vector3 _inputVector;
    private bool _isMoving;
    private bool _canMove;
    private bool _canDash;
    private bool _isStuned;

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
    }

    public bool CanMove
    {
        get
        {
            return _canMove;
        }
        set
        {
            _canMove = value;
        }
    }

    public bool CanDash
    {
        get
        {
            return _canDash;
        }
        set
        {
            CanDash = value;
        }
    }


    public PlayerMove(Player player, float walkSpeed, float runSpeedMultiplier, float jumpForce, float dashForce)
    {
        _transform = player.transform;
        _rb = player.rb;
        _footSensor = player.footSensor;
        _walkSpeed = walkSpeed;
        _runSpeedMultiplier = runSpeedMultiplier;
        _jumpForce = jumpForce;
        _dashForce = dashForce;

        player.controller.Move = Move;
        player.controller.Jump = Jump;
        player.controller.Run = Run;

        _canMove = true;
        _isMoving = false;
        _canDash = true;
        _isStuned = false;
    }

    public void Move(float verAxis, float horAxis)
    {
        if (verAxis != 0 || horAxis != 0)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }

        if (CanMove)
        {
            _inputVector.x = horAxis;
            _inputVector.z = verAxis;
            _inputVector.y = 0;

            if (_inputVector.magnitude > 1)
            {
                _inputVector.Normalize();
            }

            _isStuned = false;
        }
        else
        {
            _inputVector.x = 0;
            _inputVector.z = 0;
            _inputVector.y = 0;

            _isStuned = true;
        }
    }

    public void Run()
    {
        if (_footSensor.isGrounded && CanMove)
        {
            _inputVector *= _runSpeedMultiplier;
        }
    }

    public void FixedMove()
    {
        if (_inputVector.magnitude > 0)
        {
            _rb.MovePosition(_rb.position + (_transform.right * _inputVector.x + _transform.forward * _inputVector.z) * _walkSpeed * Time.fixedDeltaTime);
        }
    }

    public void Jump()
    {
        if (_footSensor.isGrounded && CanMove)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            AudioManager.instance.Play("PlayerJump");
        }
    }

    //Corregir.
    public IEnumerator Dash(float verAxis, float horAxis)
    {
        if (CanDash)
        {
            if (horAxis != 0 && verAxis == 0)
                _rb.AddForce((_transform.right * horAxis).normalized * _dashForce, ForceMode.Impulse);
        
            if (horAxis == 0 && verAxis != 0)
                _rb.AddForce((_transform.forward * verAxis).normalized * _dashForce, ForceMode.Impulse);
        
            if (horAxis == 0 && verAxis == 0)
                _rb.AddForce((_transform.forward * 1).normalized * _dashForce, ForceMode.Impulse);
         
            _canDash = false;
        }

        yield return new WaitForSeconds(2f);
        _canDash = true;
    }
}
