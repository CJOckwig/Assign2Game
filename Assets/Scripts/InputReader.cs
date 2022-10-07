using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue{get;private set;}
    public event Action JumpEvent;
    Controls _controls;
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            JumpEvent?.Invoke();

        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
    public void OnDestroy() {
        _controls.Player.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        _controls = new ();
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }

}
