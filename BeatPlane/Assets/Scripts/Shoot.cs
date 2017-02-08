using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public GameObject bullet; //获取生成的物体
    public float rate = 0.8f; //频率

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Fire()
    {
        MusicManager._instance.PlaySound("sound/bullet");
        GameObject.Instantiate(bullet, transform.position, Quaternion.identity); //初始化一个上面获得的物体，位置为当前脚本所在物体位置，角度为自身角度
    }

    public void openFire()
    {
        InvokeRepeating("Fire", 1, rate); //1s 之后，每隔rate调用一次Fire
    }

    public void stopFire()
    {
        CancelInvoke("Fire");
    }
}
