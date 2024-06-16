using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScolling : MonoBehaviour
{
    public float scrollSpeed;
    private Material material;
    private Vector2 offset = Vector2.zero;
	private void Awake()
	{
		material = GetComponent<Renderer>().material;
	}
	// Start is called before the first frame update
	void Start()
    {
        offset = material.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += scrollSpeed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);

	}
}
