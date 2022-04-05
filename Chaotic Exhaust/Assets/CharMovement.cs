using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour, IWalkable
{
    protected Rigidbody rb;
    
    protected float speed = 5f;

    protected float jumpHeight = 300f;

    protected Vector3 position;

    protected float verAxis;

    protected float horAxis;

    public float raydistance = 0f;

    public LayerMask layerMask;

    //flags
    //[HideInInspector]
    public bool isMoving, isJumping, canMove;
    bool _canDash = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        canMove = true;
        isMoving = false;
    }

    private void Update()
    {
        HeightRay();
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
    }

    virtual protected void FixedUpdate()
    {
        verAxis = Input.GetAxisRaw("Vertical");
        horAxis = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftControl) && _canDash)
        {
            StartCoroutine(Dash(horAxis, verAxis));
        }
        Move();
    }

    void HeightRay()
    {

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), raydistance, layerMask))
        {
            isJumping = false;
        }
        else
        {
            /*var airTimer = 0f;
            airTimer += Time.deltaTime;

            if(airTimer < 1.5f)
            {
                //hacer daño;
            }*/
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight);
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

        rb.MovePosition(position);


        if (verAxis != 0 || horAxis != 0)
        {
            isMoving = true;
        }
        else isMoving = false;
    }

    IEnumerator Dash(float hor, float ver)
    {
        int force = 500;
        if(hor != 0 && ver == 0)
            rb.AddForce((transform.right * hor) * force);
        if(ver != 0 && hor == 0)
            rb.AddForce((transform.forward * ver) * force);
        _canDash = false;

        yield return new WaitForSeconds(2f);
        _canDash = true;
    }
}
