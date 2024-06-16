using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletScript2 : MonoBehaviour
{



    //nếu không để private thì nó vẫn không không hiện nhưng được cái là có thể gọi được 
    public int timeOfDeath = 3;


    public bool enemyBullet = false;
    //tránh trường hợp dính đạn của bản thân mà chết


    private GameObject player;
    private Rigidbody2D rb;
    public float force =5;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x)*Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0,0,rot);

        Destroy(gameObject, timeOfDeath);
        //Xóa đối tượng game hủy sau 3 giây

        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {



    }






}
