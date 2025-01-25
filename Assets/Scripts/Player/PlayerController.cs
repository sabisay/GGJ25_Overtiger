using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MoveSpeed;

    public float FlyingSpeed;

    private Vector2 move_pos;

    private float flybool;

    public InputActionReference move;
    public InputActionReference fly;
    

    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move_pos = move.action.ReadValue<Vector2>();
        flybool = fly.action.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX += move_pos.x * MoveSpeed;

        if (flybool == 0)
        {
            // Debug.Log("uçuyorsun melih");
            rb.linearVelocityY += FlyingSpeed / 10;
        }
    }
}