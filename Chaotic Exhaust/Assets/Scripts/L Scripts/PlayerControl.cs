using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl
{
    private PlayerMove _playerMove;

    private float _verAxis;
    private float _horAxis;
    private string _runButton = "Run";
    private string _jumpButton = "Jump";
    //private string _dashButton = "Dash";

    public PlayerControl(PlayerMove playerMove)
    {
        _playerMove = playerMove;
    }

    public void ArtificialUpdate()
    {
        _verAxis = Input.GetAxisRaw("Vertical");
        _horAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown(_jumpButton))
        {
            _playerMove.Jump();
        }

        //if (Input.GetButtonDown(_dashButton))
        //{
        //    _playerMove.Dash(_verAxis, _horAxis);
        //}
        
        _playerMove.Move(_verAxis, _horAxis);

        if (Input.GetButton(_runButton))
        {
            _playerMove.Run();
        }

    }

    public void ArtificialFixedUpdate()
    {
        _playerMove.FixedMove();
    }
}
