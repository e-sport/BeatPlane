using UnityEngine;
using System.Collections;

public class heroAnimation : MonoBehaviour {
    public int framOfPerSecond = 10; //每秒几帧（帧率）
    public Sprite[] sprite; //存放精灵图片
    SpriteRenderer sp; // 存放精灵组件
    public float timer; //计时器
    private bool isMouseDown = false;
    private Vector3 lastMousePosition;
    public float doubleGunTime = 10f; //双枪存在的时间
    private float resetWeaponTime; //复位时间
    private int weapon = 1; //当前武器种类
    public Shoot gun_Center, gun_Left, gun_Right;
    public Animator anim;

    private Vector3 ScreenArea; //存储屏幕区域向量
    private float screenXMin, screenXMax; //定义屏幕X轴最小，最大值
    private float screenYMin, screenYMax; //定义屏幕y轴最小，最大值

    // Use this for initialization
    void Start () {
        sp = GetComponent<SpriteRenderer>(); // 获取精灵组件
        anim = GetComponent<Animator>();
        ScreenArea = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
        //把屏幕坐标转换成世界坐标 类型是向量
        screenXMin = -ScreenArea.x; //根据分辨率计算出屏幕X轴上的最小值（最左边），此时是世界坐标
        screenXMax = ScreenArea.x;  //屏幕X轴上的最大值（最右边）
        screenYMin = -ScreenArea.y; //屏幕Y轴上的最小值（最下边）
        screenYMax = ScreenArea.y;  //屏幕Y轴上的最大值（最上边）
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

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }
        if (isMouseDown) //把鼠标所在的位置（屏幕）转换成世界坐标，移动时所产生的偏移与飞机所在位置叠加，使飞机移动
        {
            Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
            transform.position = transform.position + offset;
            checkPosition(); //检查有没有飞出屏幕
        }

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }
        lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//实时把鼠标的位置从屏幕坐标转换成世界坐标并赋值给lastposition

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

    void checkPosition()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        x = x < screenXMin ? screenXMin : x; //如果往左移动超出屏幕，则把坐标屏幕值赋给x
        x = x > screenXMax ? screenXMax : x; //x最右
        y = y < screenYMin ? screenYMin : y; //y最下
        y = y > screenYMax ? screenYMax : y; //y最上
        transform.position = new Vector3(x, y, 0); //重新设置位置
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
