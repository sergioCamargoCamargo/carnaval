using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float speed = 2f;
    public float MaxSpeed = 5f;
    public bool jump;
    public float jumpPower = 7f;

    private Rigidbody2D rgb2d;
    private Animator anim;
    private SpriteRenderer spr;
    private bool movement = false;
    private bool airJump;
    private bool doubleJump;
    private GameObject barraDeVida;

    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        barraDeVida = GameObject.Find("Barra_vida");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Walking", Mathf.Abs(rgb2d.velocity.x));
        anim.SetBool("Jump", jump);

        /*if (jump)
        {
            doubleJump = true;
        }*/

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!jump)
            {
                airJump = true;
                doubleJump = true;
            } else if (doubleJump)
            {
                airJump = true;
                doubleJump = false;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rgb2d.velocity;
        fixedVelocity.x *= 0.9f;

        if (jump)
        {
            rgb2d.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");
        float limitSpeed = Mathf.Clamp(rgb2d.velocity.x, -MaxSpeed, MaxSpeed);

        //if (!movement) h = 0;

        rgb2d.AddForce(Vector2.right * (speed * 10) * h);
        rgb2d.velocity = new Vector2(limitSpeed, rgb2d.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        } else if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }

        if (airJump) {
            rgb2d.velocity = new Vector2(rgb2d.velocity.x, 0);
            rgb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            airJump = false;
        }

        Debug.Log(rgb2d.velocity.x);
    }

    void OnBecameInvisible()
    {
        transform.position = new Vector3(-5,-3,0);
    }

    public void EnemyJump() {
        airJump = true;
    }

    public void EnemyKnockBack(float EnemyPosX) {
        barraDeVida.SendMessage("TakeDamage", 15);

        airJump = true;

        float side = Mathf.Sign(EnemyPosX - transform.position.x);
        rgb2d.AddForce(Vector2.left * side *jumpPower, ForceMode2D.Impulse);

        movement = false;
        Invoke("EnableMovement", 0.7f);

        Color color = new Color(255/255f, 106/255f, 0f);
        spr.color = color;
    }

    void EnableMovement() {
        movement = true;
        spr.color = Color.white;
    }
}
