using UnityEngine;
using System.Collections;

public class heroAnimation : MonoBehaviour {
    public int framOfPerSecond = 10; //每秒几帧（帧率）
    public Sprite[] sprite; //存放精灵图片
    SpriteRenderer sp; // 存放精灵组件
    public float timer; //计时器
    
    public float doubleGunTime = 10f; //双枪存在的时间
    private float resetWeaponTime; //复位时间
    private int weapon = 1; //当前武器种类
    public Shoot gun_Center, gun_Left, gun_Right;
    public Animator anim;

    // Use this for initialization
    void Start () {
        sp = GetComponent<SpriteRenderer>(); // 获取精灵组件
        anim = GetComponent<Animator>();
        
        resetWeaponTime = doubleGunTime; //把复位时间设置为双枪存在的时间
        doubleGunTime = 0; //双枪存在时间为0
        gun_Center.openFire(); //调用Shoot中的OpenFire开火
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime; //计时器累加
        int m = (int)(timer / (1.0f / framOfPerSecond)); //时间除以每帧所需时间，算出帧数
        int sprit = m % 2; //总帧数和2取余，结果总是0,1
        sp.sprite = sprite[sprit]; //从精灵数组里取出精灵图片

        doubleGunTime -= Time.deltaTime; //双枪存在时间每帧递减
        if (doubleGunTime > 0)
        {
            if (weapon == 1)
            {
                changeToDoubleWeapon(); //改变当前武器，上双枪
            }
        }
        else
        {
            if (weapon == 2)
            {
                changeToBaseWeapon(); //取消双枪
            }
        }
    }

    void changeToDoubleWeapon()
    {
        weapon = 2;
        gun_Left.openFire();
        gun_Right.openFire();
    }

    void changeToBaseWeapon()
    {
        weapon = 1;
        gun_Left.stopFire();
        gun_Right.stopFire();
    }

    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Award")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy.planeType == EnemyType.support)
            {
                doubleGunTime = resetWeaponTime; //设置双枪时间
                Destroy(other.gameObject);
            }
            if (enemy.planeType == EnemyType.boom)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.tag == "Enemy")
        {
            StartCoroutine(Delay_Destory());
        }

    }

    IEnumerator Delay_Destory()
    {
        anim.SetBool("Dead", true);
        MusicManager._instance.PlaySound("sound/game_over");
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);

        GameOver._instance.showScore(GameManager._instance.score);
    }
}
