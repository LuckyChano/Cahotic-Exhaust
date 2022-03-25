using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour, IWalkable
{
    protected float speed = 5f;

    protected float jumpHeight = 300f;

    protected Vector3 position;

    protected float verAxis;

    protected float horAxis;

    protected Rigidbody _rb;

    public float raydistance = 0f;

    public LayerMask layerMask;

    //[HideInInspector]
    public bool _isMoving, _isJumping, _canMove;


    private void Start()
    {
        _canMove = true;
        _rb = GetComponent<Rigidbody>();
        _isMoving = false;
    }

    public void Move()
    {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 10;
            }
            else speed = 5f;
            position = transform.position;

            position += (speed * verAxis * Time.deltaTime) * transform.forward;

            if (horAxis != 0)
            {
                position += (speed * horAxis * Time.deltaTime) * transform.right;
            }

            _rb.MovePosition(position);


            if (verAxis != 0 || horAxis != 0)
            {
                _isMoving = true;
            }
            else _isMoving = false;
    }
    public void Jump()
    {
        _rb.AddForce(Vector3.up * jumpHeight);
    }

    void JumpRay()
    {
        
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), raydistance, layerMask))
        {          
            _isJumping = false;
        }
        else
        {
            _isJumping = true;
        }
    }

    private void Update()
    {
        JumpRay();
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
            {
                Jump();
            }
    }
    virtual protected void FixedUpdate()
    {
        verAxis = Input.GetAxis("Vertical");
        horAxis = Input.GetAxis("Horizontal");
        Move();
    }
}
