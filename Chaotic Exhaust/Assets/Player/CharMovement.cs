using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour, IWalkable
{
    protected Rigidbody rb;

    public FootSensor footSensor;
    
    protected float walkSpeed = 5f;

    protected float runSpeedMultiplier = 2f;

    protected float jumpSpeed = 6f;

    protected float dashSpeed = 10f;

    protected float verAxis;

    protected float horAxis;

    private string _runButton = "Run";
    private string _jumpButton = "Jump";
    private string _dashButton = "Dash";

    //flags
    //[HideInInspector]
    public bool isMoving, canMove;
    private bool _canDash = true;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        canMove = true;
        isMoving = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown(_jumpButton) && footSensor.isGrownded)
        {
            Jump();

            //ver como implementar si queremos el daño por caida
            /*var airTimer = 0f;
            airTimer += Time.deltaTime;

            if(airTimer < 1.5f)
            {
                //hacer daño;
            }*/
        }
    }

    virtual protected void FixedUpdate()
    {
        verAxis = Input.GetAxisRaw("Vertical");
        horAxis = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown(_dashButton) && _canDash)
        {
            StartCoroutine(Dash());
        }
        
        Move();
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }

    public void Move()
    {
        Vector3 inputVector;
        inputVector.x = horAxis;
        inputVector.z = verAxis;
        inputVector.y = 0;

        if (Input.GetButton(_runButton))
        {
            inputVector *= runSpeedMultiplier;
        }

        rb.MovePosition(rb.position + (transform.right * inputVector.x + transform.forward * inputVector.z) * walkSpeed * Time.deltaTime);

        if (verAxis != 0 || horAxis != 0)
        {
            isMoving = true;
        }
        else isMoving = false;
    }

    IEnumerator Dash()
    {
        if(horAxis != 0 && verAxis == 0)
            rb.AddForce((transform.right * horAxis) * dashSpeed, ForceMode.Impulse);
        if(verAxis != 0 && horAxis == 0)
            rb.AddForce((transform.forward * verAxis) * dashSpeed, ForceMode.Impulse);
        _canDash = false;

        yield return new WaitForSeconds(2f);
        _canDash = true;
    }
}
