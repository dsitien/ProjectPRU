using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public Vector2 direction = new Vector2(0, 1);
    public float speed;
    public Vector2 velocity;
    public float timeDestroy;

    void Start()
    {
        if (timeDestroy == 0 )
        {
            timeDestroy = 100;
        }
        Destroy(gameObject, timeDestroy);
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos -= velocity * Time.fixedDeltaTime;


        transform.position = pos;

    }
    //Destroy if go out camera
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
