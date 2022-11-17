using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForceReceiver : ForceReceiver
{
    public void AddJumpForce(float jumpForce)
    {
        _verticalVelocity+=jumpForce;
    }
}
