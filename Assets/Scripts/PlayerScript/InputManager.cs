using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction tapAction;
    public Rigidbody2D player;
    Vector2 a = new Vector2(3f, 0);

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        tapAction = playerInput.actions.FindAction("TouchAction");
    }

    private void Start()
    {
        player.AddForce(new Vector2(3f, 0), ForceMode2D.Impulse);
    }

    private void OnEnable()
    {
        tapAction.performed += touchPressed;//perform: la khi action chinh thuc dc perform 
    }

    private void OnDisable()
    {
        tapAction.performed -= touchPressed;
    }

    private void touchPressed(InputAction.CallbackContext context)
    {
        jump();
    }

    public void jump()
    {
        player.rotation = 0f;
        if (Jump.isGrounded)
        {
            if (Jump.direction)
            {
                player.velocity = a;
            }
            else
            {
                player.velocity = -a;
            }
            player.AddForce(new Vector2(0, Jump.forceAmount), ForceMode2D.Impulse);
        }
    }
}
