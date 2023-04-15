using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl
{
    private Player _player;

    private float _verAxis;
    private float _horAxis;
    private string _runButton = "Run";
    private string _jumpButton = "Jump";
    //private string _dashButton = "Dash";

    public System.Action<float, float> Move;
    public System.Action Run;
    public System.Action Jump;
    public System.Action Throw;
    public System.Action Pause;

    public PlayerControl(Player player)
    {
        _player = player;
    }

    public void ArtificialUpdate()
    {
        _verAxis = Input.GetAxisRaw("Vertical");
        _horAxis = Input.GetAxisRaw("Horizontal");

        Move?.Invoke(_verAxis, _horAxis);


        //if (Input.GetButtonDown(_dashButton))
        //{
        //    _playerMove.Dash(_verAxis, _horAxis);
        //}



        if (Input.GetButtonDown(_jumpButton))
        {
            Jump?.Invoke();
        }
        if (Input.GetButton(_runButton))
        {
            Run?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Throw?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause?.Invoke();
        }
    }

    public void ArtificialFixedUpdate()
    {
        _player.movement.FixedMove();
    }
}
