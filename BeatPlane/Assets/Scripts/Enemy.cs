using UnityEngine;
using System.Collections;

public enum EnemyType //飞机枚举类型
{
    smallEnemy, //小
    middleEnemy, //中
    bigEnemy, //大
    support,
    boom
}

public class Enemy : MonoBehaviour {
    public int life; //敌机生命
    public int score;
    public float speed; //敌机速度
    public EnemyType planeType = EnemyType.smallEnemy; //默认小飞机
    Animator anim; //存放动画组件
    private bool isHit = false; //是否被击中，初始状态否

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>(); //获取动画组件
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime); //敌机以speed 速度向下移动
        if (transform.position.y <= -5.4) //如果超出了屏幕最低边（5.4是以最大飞机消失在屏幕算的）
        {
            Destroy(this.gameObject); //销毁物体
        }
        checkLife();  //每帧检查生命
    }

    void checkLife()
    {
        if (life <= 0)  //如果生命小于0
        {
            StartCoroutine(Delay_Destory());
        }
    }

    void Behit() //被击中时候从子弹发过来的消息调用方法
    {
        this.life--; //生命值减1
        if (life >= 0)
        {
            this.isHit = true; //被击中 状态
            StartCoroutine(Delay_Hited());
        }
    }

    IEnumerator Delay_Destory()
    {
        //延迟0.25s后销毁飞机
        anim.SetBool("Dead", true);
        switch (planeType)
        {
            case EnemyType.smallEnemy:
                MusicManager._instance.PlaySound("sound/enemy0_down");
                yield return new WaitForSeconds(0.25f);
                break;
            case EnemyType.middleEnemy:
                MusicManager._instance.PlaySound("sound/enemy1_down");
                yield return new WaitForSeconds(0.25f);
                break;
            case EnemyType.bigEnemy:
                MusicManager._instance.PlaySound("sound/enemy2_down");
                yield return new WaitForSeconds(0.5f);
                break;
        }
        GameManager._instance.addScore(score);
        Destroy(this.gameObject);
    }

    IEnumerator Delay_Hited()
    {
        anim.SetBool("Hited", isHit);
        yield return new WaitForSeconds(0.2f);
        this.isHit = false;
        anim.SetBool("Hited", isHit);
    }
}
