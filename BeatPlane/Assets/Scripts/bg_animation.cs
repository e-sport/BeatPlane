using UnityEngine;
using System.Collections;

public class bg_animation : MonoBehaviour {

    public static float speed = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
        if (this.transform.position.y < -8.52)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 8.52f*2, transform.position.z);
        }
	}
}
