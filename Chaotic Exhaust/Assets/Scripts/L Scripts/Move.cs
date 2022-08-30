using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : Entity
{
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

    public bool IsStuned
    {
        get
        {
            return _isStuned;
        }
    }

    public void MoveMe(float verAxis, float horAxis)
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
        if (_footSensor.isGrownded && CanMove)
        {
            _inputVector *= _runSpeedMultiplier;
        }
    }

    public void FixedMove()
    {
        if (_inputVector.magnitude > 0)
        {
            _rb.MovePosition(_rb.position + (transform.right * _inputVector.x + transform.forward * _inputVector.z) * _walkSpeed * Time.fixedDeltaTime);
        }
    }

    public void Jump()
    {
        if (_footSensor.isGrownded && CanMove)
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
                _rb.AddForce((transform.right * horAxis).normalized * _dashForce, ForceMode.Impulse);

            if (horAxis == 0 && verAxis != 0)
                _rb.AddForce((transform.forward * verAxis).normalized * _dashForce, ForceMode.Impulse);

            if (horAxis == 0 && verAxis == 0)
                _rb.AddForce((transform.forward * 1).normalized * _dashForce, ForceMode.Impulse);

            _canDash = false;
        }

        yield return new WaitForSeconds(2f);
        _canDash = true;
    }




    //------------------------------------------------------------------------------------Pa que no rompa la bola-------------------------------------------------------------------------------------------------------
    public override void Damage(float value)
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Heal(float value)
    {
        throw new System.NotImplementedException();
    }

    public override void ShootDamage(float value)
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(float value)
    {
        throw new System.NotImplementedException();
    }

    public override void TurnOff()
    {
        throw new System.NotImplementedException();
    }
}
