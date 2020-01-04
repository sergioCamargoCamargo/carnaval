using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara_Follow : MonoBehaviour
{
    public GameObject follow;
    public Vector2 minCamera, maxCamera;
    public float smoothTime;

    private Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x,
            follow.transform.position.x, ref vel.x, smoothTime);
        float posy = Mathf.SmoothDamp(transform.position.y,
            follow.transform.position.y, ref vel.y, smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(posx, minCamera.x, maxCamera.x),
            Mathf.Clamp(posy, minCamera.y, maxCamera.y),
            transform.position.z);
    }
}
