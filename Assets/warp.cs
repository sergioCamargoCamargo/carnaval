using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    public GameObject target;

    bool Start = false;
    bool IsFadeIn = false;
    bool alpha = 0;
    bool fadeTime = 1f;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Assert.IsNotNull(target);

        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player")
        {
            col.GetComponent<Animator>().enabled = 
        }
    }
}
