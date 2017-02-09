using UnityEngine;
using System.Collections;
using Engine;

public class MoveTouch : MonoBehaviour {
	private bool isMouseDown = false;
	private Vector3 lastMousePosition;
	private Vector3 ScreenArea; //存储屏幕区域向量
	private float screenXMin, screenXMax; //定义屏幕X轴最小，最大值
	private float screenYMin, screenYMax; //定义屏幕y轴最小，最大值


	// Use this for initialization
	void Start () {
		ScreenArea = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
		//把屏幕坐标转换成世界坐标 类型是向量
		screenXMin = -ScreenArea.x; //根据分辨率计算出屏幕X轴上的最小值（最左边），此时是世界坐标
		screenXMax = ScreenArea.x;  //屏幕X轴上的最大值（最右边）
		screenYMin = -ScreenArea.y; //屏幕Y轴上的最小值（最下边）
		screenYMax = ScreenArea.y;  //屏幕Y轴上的最大值（最上边）
	}

	void FixedUpdate()
	{
		if (Input.GetMouseButtonUp (0)) {
			isMouseDown = false;
		}
		if (isMouseDown) { //把鼠标所在的位置（屏幕）转换成世界坐标，移动时所产生的偏移与飞机所在位置叠加，使飞机移动
			Vector3 offset = Camera.main.ScreenToWorldPoint (Input.mousePosition) - lastMousePosition;
			m__scene__move__c2s proto = new m__scene__move__c2s ();
			proto.x = (short)(offset.x * 10000);
			proto.y = (short)(offset.y * 10000);
			NetMgr.Instance.send (proto);

			transform.position = transform.position + offset;
			checkPosition (); //检查有没有飞出屏幕
		}

		if (Input.GetMouseButtonDown (0)) {
			isMouseDown = true;
		}
		lastMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);//实时把鼠标的位置从屏幕坐标转换成世界坐标并赋值给lastposition

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

}
