using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public GameObject bulletPrefab;
    #region 
    public float speed;
    public float Vx;
    private Rigidbody2D Rigidbody2D;
    private BoxCollider2D BoxCollider2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int lives = 1;

    private float lastshoot;
    [SerializeField] stompHelp stompcheck;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

   /*
    void alive()
    {
        if (Player == null) return;

        Vector3 direction = Player.transform.position - transform.position;

        if (direction.x >= 0.0f)
        {
            //Vx = 1;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }

        else if (direction.x <= 0.0f)
        {
            // Vx = -1;
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

    }
*/

     void Update()
    {

       // alive();
        move();
        ISlock();

        if (stompcheck.IsStomp)
        {
            gameObject.SetActive(false);
        };

    }


    void ISlock()
    {

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (distance < 1 && Time.time > lastshoot + 1)
        {
            //shoot();
            lastshoot = Time.time;
        }


    }
    void move()
    {


        Debug.DrawLine(transform.position, new Vector2(transform.position.x + 0.2f * Mathf.Sign(Vx), transform.position.y));


        //RaycastHit2D hit2 = Physics2D.Linecast(transform.position, new Vector2(transform.position.x + -0.2f, transform.position.y));
       
        var test = 1 << LayerMask.NameToLayer("ground");
       // test = ~test;
        bool hit2 = Physics2D.Linecast(transform.position, new Vector2(transform.position.x + 0.2f * Mathf.Sign(Vx), transform.position.y),test);

        //RaycaststHit2D[] test = Physics2D.LinecastAll(transform.position, new Vector2(transform.position.x + 0.2f * Mathf.Sign(Vx), transform.position.y));



        if (hit2) 
        {
            

            Flip();
          
        }





    }

        void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.layer==LayerMask.NameToLayer("killplay")){

            
               gameObject.SetActive(false); 
              
        }

       
    }

    void Flip()
    {

        if (Vx > 0)
        {
           transform.localScale = new Vector3(-1.0f, 1.1f, 1.0f);
             Vx = -1;
        }
        else
        {
            
            transform.localScale = new Vector3(1.0f, 1.1f, 1.0f);
            Vx = 1;
        }

    }


    public void hit()
    {
        lives = lives - 1;
        if (lives <= 0)
        {
            Destroy(gameObject);

        }
    }

    public void shoot()
    {

        Vector3 direction;

        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;


        GameObject Bullet = Instantiate(bulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        Bullet.GetComponent<BalletScript>().setDireccion(direction);


    }

    void FixedUpdate()
    {

        Rigidbody2D.velocity = new Vector2(Vx, Rigidbody2D.velocity.y);

    }

}
