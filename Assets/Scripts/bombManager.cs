using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bombManager : MonoBehaviour {

    public GameObject boomIcon; //炸弹图标
    public Text boomNumber; //炸弹的数目（显示）
    public int count = 0; //炸弹数量
    public static bombManager _instance; //单例初始化

	// Use this for initialization
	void Start () {
        _instance = this;
        boomIcon.SetActive(false); //刚开始不显示图标
        boomNumber.gameObject.SetActive(false);
    }

    public void addAbomb()
    {
        count++;
        boomIcon.SetActive(true);
        boomNumber.gameObject.SetActive(true);
        boomNumber.text = "X" + count;
    }

    public void useAbomb()
    {
        if (count > 0)
        {
            count--;
            boomNumber.text = "X" + count;
            if (count <= 0)
            {
                boomIcon.SetActive(false);
                boomNumber.gameObject.SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space) && bombManager._instance.count > 0)
        {
            this.useAbomb();
        }
	}
}
