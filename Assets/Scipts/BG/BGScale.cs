using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour
{
    float worldHeight;
	float worldWidth;
	// Start is called before the first frame update
	void Start()
    {
        worldHeight = Camera.main.orthographicSize * 2f;
        //Debug.Log(worldHeight) =10;
        worldWidth = worldHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3 (worldWidth, worldHeight, 0f);
    }

    
}
