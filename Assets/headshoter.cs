using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headshoter : MonoBehaviour
{
    public GameObject Player;
    public GameObject bulletPrefab;
    public float speed;
    public float Vx;
    private Rigidbody2D Rigidbody2D;
    private BoxCollider2D BoxCollider2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int lives = 1;

    private float lastshoot;

    // Start is called before the first frame update
    void Start()
    {

    }
     void alive()
    {
        if (Player == null) return;

        Vector3 direction = Player.transform.position - transform.position;

        if (direction.x >= 0.0f)
        {
            Vx = 1;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }

        else if (direction.x <= 0.0f)
        {
             Vx = -1;
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        alive();
        ISlock();
    }
    void ISlock()
    {

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (distance < 1 && Time.time > lastshoot + 1)
        {
            shoot();
            lastshoot = Time.time;
        }


    }
    public void shoot()
    {

        Vector3 direction;

        if (transform.localScale.x == 2.0f) direction = Vector2.right;
        else direction = Vector2.left;


        GameObject Bullet = Instantiate(bulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        Bullet.GetComponent<BalletScript>().setDireccion(direction);


    }


    public void hit()
    {
        lives = lives - 2;
        if (lives <= 0)
        {
            Destroy(gameObject);

        }
    }
}
