using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputContoller : PlayerCharacterContoller
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnAttack(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}
