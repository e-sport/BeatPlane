using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed = 10; //子弹的速度，也可以在编辑器中指定
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime); //子弹往上运动
        if (this.transform.position.y > 4.4)
        {
            Destroy(this.gameObject); // 如果子弹位置大于4.4(屏幕上边沿), 则销毁子弹
        }
	}

    void OnTriggerEnter2D(Collider2D other) //每次碰撞自动调用此方法
    {
        if (other.gameObject.tag == "Enemy") //如果打中的是敌机
        {
            other.gameObject.SendMessage("Behit"); //则调用敌机身上的Behit方法
            Destroy(this.gameObject); //如果碰撞到了则销毁此物体
        }
    }
}
