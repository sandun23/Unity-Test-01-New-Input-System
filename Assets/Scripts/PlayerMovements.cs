using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody sprigidbody;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputAction;

    private void Awake()
    {
        sprigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputAction = new PlayerInputActions();
        playerInputAction.Player.Enable();
        playerInputAction.Player.Jump.performed += Jump;

    }

    private void FixedUpdate()
    {

        Vector2 inputvector2 = playerInputAction.Player.Movements.ReadValue<Vector2>();
        float speed = 3f;
        sprigidbody.AddForce(new Vector3(inputvector2.x, 0, inputvector2.y) * speed, ForceMode.Force);

    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            Debug.Log("jump" + context.phase);
            sprigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);

        }

    }
    public void Movement(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            Debug.Log("move" + context);

        }

    }
}
