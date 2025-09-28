using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }
    public void SetDirection(Vector2 direction)
    {
        direction = direction;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
