using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]


public class BalletScript : MonoBehaviour



{
    #region 
    public float speed;
    private Vector2 Direction;
    private Rigidbody2D Rigidbody2D;
    private CapsuleCollider2D capsuleCollider2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    /*void Update()
    {
        
    }
    */

    public void setDireccion(Vector2 direction)
    {

        Direction = direction;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        PlayerController player = collision.collider.GetComponent<PlayerController>();

        EnemyController enemy = collision.collider.GetComponent<EnemyController>();

        headshoter enemy2= collision.collider.GetComponent<headshoter>();

        if (player != null)
        {
            player.hit();

        }
        else if (enemy != null)
        {
            enemy.hit();
       }else if (enemy2 != null)
        {
            enemy2.hit();
        }

       DestroyBullet();

    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * speed;

    }

    public void DestroyBullet()
    {

        Destroy(gameObject);

    }
}
