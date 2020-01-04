using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float maxSpeed = 1f;
    public float speed = 1f;

    private Rigidbody2D rgb2d;

    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();   
    }

    void FixedUpdate()
    {
        rgb2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rgb2d.velocity.x, -maxSpeed, maxSpeed);
        rgb2d.velocity = new Vector2(limitedSpeed, rgb2d.velocity.y);

        if (rgb2d.velocity.x > -0.01f && rgb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rgb2d.velocity = new Vector2(speed, rgb2d.velocity.y);
        }

        if (speed < 0) transform.localScale = new Vector3(1f, 1f, 1f);
        if (speed > 0) transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            float yOffset = 0.6f;
            if (transform.position.y + yOffset < other.transform.position.y) {
                other.SendMessage("EnemyJump");
                Destroy(gameObject);
            } else
            {
                other.SendMessage("EnemyKnockBack", transform.position.x);
            }
        }
    }
}
