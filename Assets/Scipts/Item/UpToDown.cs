using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpToDown : MonoBehaviour
{

    public float moveSpeed = 5;

    float sinCenterX;
    public float amptitude = 2;
 
    public float frequency = 2;
 
    public bool inverted;

    // Start is called before the first frame update
    void Start()
    {
        sinCenterX = transform.position.x;
        Destroy(gameObject,50f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.y -= moveSpeed*Time.fixedDeltaTime;

        float sin = Mathf.Sin(pos.y * frequency) * amptitude;
        if (inverted)
        {
            sin *= -1;
        }
        pos.x = sinCenterX + sin;


        transform.position = pos;
    }




}
