using UnityEngine;

public class Movimientojhon : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal, rb.linearVelocity.y);
    }
}

