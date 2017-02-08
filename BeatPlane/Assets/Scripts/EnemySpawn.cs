using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    public GameObject smallEnemy; //小飞机
    public float smallEnemyRate = 0.5f; //小飞机生成速率
    public GameObject middleEnemy; //中飞机
    public float middleEnemyRate = 3; //中飞机生成速率
    public GameObject bigEnemy; //大飞机
    public float bigEnemyRate = 10; //大飞机生成速率
    public GameObject powerUp; //加大威力
    public float powerUpRate = 20; //奖励物品的频率
    public GameObject boom; //全屏炸弹
    public float boomRate = 30; //出现的频率

	// Use this for initialization
	void Start () {
//        InvokeRepeating("createSmallEnemy", 1, smallEnemyRate); //重复生成小飞机
//        InvokeRepeating("createMiddleEnemy", 1, middleEnemyRate); //重复生成中飞机
//        InvokeRepeating("createBigEnemy", 1, bigEnemyRate); //重复生成大飞机
//        InvokeRepeating("createPowerUp", 10, powerUpRate); //重复调用生成奖励物品
//        InvokeRepeating("createBoom", 18, boomRate); //重复调用生成全屏炸弹
	}

    void createSmallEnemy()
    {
        createEnemy(-2.2f, 2.2f, smallEnemy);
    }

    void createMiddleEnemy()
    {
        createEnemy(-2.1f, 2.1f, middleEnemy);
    }

    void createBigEnemy()
    {
        createEnemy(-1.6f, 1.6f, bigEnemy);
    }

    void createPowerUp()
    {
        createEnemy(-2.1f, 2.1f, powerUp);
    }

    void createBoom()
    {
        createEnemy(-2.1f, 2.1f, boom);
    }

    void createEnemy(float xMin, float xMax, GameObject plane)
    {
        float x = Random.Range(xMin, xMax); //飞机可以生成的边界范围
        GameObject.Instantiate(plane, new Vector3(x, transform.position.y, 0), Quaternion.identity); //x轴随机生成飞机
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
