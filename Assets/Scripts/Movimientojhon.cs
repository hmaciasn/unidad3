using UnityEngine;

public class Movimientojhon : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float JumpForce;
    public float Speed;
    private Rigidbody2D rb;
    private Animator Anim;
    private float Horizontal;
    private bool Grouded;
    private float LastShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }
        Anim.SetBool("running", Horizontal != 0.0f);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
        {
            Grouded = true;
        }
        else
        {
            Grouded = false;
        }
        if (Input.GetKeyDown(KeyCode.Z) && Grouded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce);
    }
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.2f, Quaternion.identity);
       bullet.GetComponent<BulletScript>().SetDirection(direction);
    }


    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Horizontal, rb.linearVelocity.y);
    }


}
