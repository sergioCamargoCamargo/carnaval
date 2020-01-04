using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Falling : MonoBehaviour
{
    public float fallDelay = 1f;
    public float respawnDelay = 5f;

    private Rigidbody2D rgb2d;
    private PolygonCollider2D pc2d;
    private BoxCollider2D bc2d;
    private Vector3 start;

    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<PolygonCollider2D>();
        bc2d = GetComponent<BoxCollider2D>();
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    void Fall() {
        rgb2d.isKinematic = false;
        bc2d.isTrigger = true;
        bc2d.enabled = !bc2d.enabled;
        //bc2d.transform.position = new Vector3(0, 0, 15);
    }

    void Respawn() {
        transform.position = start;
        rgb2d.isKinematic = true;
        rgb2d.velocity = Vector3.zero;
        bc2d.isTrigger = false;
    }
}
