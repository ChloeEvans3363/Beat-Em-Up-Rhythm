using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    private float speed = 1f;
    private PlayerInput playerInput;
    private InputAction moveAction;
    public Animator animator;

    //private enum MovementState {idle, walk}

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    private void Update()
    {
        //MovementState state;

        // Movement
        transform.Translate(new Vector3(moveAction.ReadValue<Vector2>().x, moveAction.ReadValue<Vector2>().y, 0) * speed * Time.deltaTime);

        if (playerInput.actions["Attack"].triggered)
        {
            Debug.Log("Punch!");
        }

        // Animation stuff
        animator.SetFloat("Horizontal", moveAction.ReadValue<Vector2>().x);
        animator.SetFloat("Vertical", moveAction.ReadValue<Vector2>().y);
        animator.SetFloat("Magnitude", moveAction.ReadValue<Vector2>().magnitude);

        if (moveAction.ReadValue<Vector2>().x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveAction.ReadValue<Vector2>().x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
