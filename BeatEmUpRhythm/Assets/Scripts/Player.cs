using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    private float speed = 1.5f;
    private PlayerInput playerInput;
    private InputAction moveAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        //Debug.Log(moveAction.ReadValue<Vector2>());
    }

    private void Update()
    {
        //Debug.Log(moveAction.ReadValue<Vector2>());
        transform.Translate(new Vector3(moveAction.ReadValue<Vector2>().x, moveAction.ReadValue<Vector2>().y, 0) * speed * Time.deltaTime);
    }
}
