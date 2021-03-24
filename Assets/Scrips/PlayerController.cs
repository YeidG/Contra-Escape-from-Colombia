using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    #region 
    public GameObject gameOver;
    public GameObject bulletPrefab;
    public float jumpForce;
    public float speed;
    private float Vx;
    private Rigidbody2D Rigidbody2D;
    private CapsuleCollider2D capsuleCollider2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool grounded = false;
    private bool isgrounded;
    private bool isjump;
    private bool isactive;

    private float lastShoot;
    //public int lives = 3;

    #endregion


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }



    // Update is called once per frame
    void Update()
    {

        animat();


        Debug.DrawRay(transform.position, Vector3.down * 0.12f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.12f))
        {
            grounded = true;

        }
        else
        {
            grounded = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            isjump = true;
            Jump();
        }
        else
        {
            isjump = false;
        }

        if (Input.GetKey(KeyCode.F) && Time.time > lastShoot + 0.25f && isactive)

        {
            disparar();
            lastShoot = Time.time;
        }


    }
    private void disparar()
    {
        Vector3 direction;

        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;


        GameObject Bullet = Instantiate(bulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        Bullet.GetComponent<BalletScript>().setDireccion(direction);

    }


    private void Jump()
    {

        Rigidbody2D.AddForce(Vector2.up * jumpForce);



    }

    private void move()
    {

        Vx = Input.GetAxisRaw("Horizontal");
        if (Vx < 0.0f) transform.localScale = new Vector3(-1.0f, 1.1f, 1.0f);
        else if (Vx > 0.0f) transform.localScale = new Vector3(1.0f, 1.1f, 1.0f);
    }

    public void hit()
    {
        gameObject.SetActive(false);


        Manager.Instance.updateLives(-1);
    }

    public void GameOver()
    {

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemies"))
        {
            isactive = false;
            gameObject.SetActive(false);


            Manager.Instance.updateLives(-1);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("killplay"))
        {


            gameObject.SetActive(false);
            Manager.Instance.updateLives(-1);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("PowerUp"))
        {

            isactive = true;

        }
    }

    private void FixedUpdate()
    {
        move();
        Rigidbody2D.velocity = new Vector2(Vx, Rigidbody2D.velocity.y);

    }

    private void animat()
    {

        animator.SetBool("run", Vx != 0.0f);
        animator.SetBool("IsJumping", isjump);
        animator.SetBool("isgrounded", grounded);

        /*   if (Vx < 0.0f){
              spriteRenderer.flipX = true;
          }
          else if (Vx > 0.0f){
              spriteRenderer.flipX = false;
          }
           */
    }

}
