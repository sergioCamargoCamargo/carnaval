using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Jump : MonoBehaviour
{
    private player_controller player;
    private Rigidbody2D rgb2d;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<player_controller>();
        rgb2d = GetComponentInParent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "platafroma") {
            rgb2d.velocity = new Vector3(0f,0f,0f);
            player.transform.parent = other.transform;
            player.jump = false;
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") player.jump = false;
        if (other.gameObject.tag == "platafroma") {
            player.transform.parent = other.transform;
            player.jump = false;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") player.jump = true;
        if (other.gameObject.tag == "platafroma") {
            player.transform.parent = null;
            player.jump = true;
        }
    }
}
