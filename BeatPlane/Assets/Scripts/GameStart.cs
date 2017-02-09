using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Engine;

public class GameStart : MonoBehaviour {

	public Button btn;
	public InputField input;

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (this);
		btn.onClick.AddListener(delegate() {
			this.OnClick(); 
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		NetMgr.Instance.connect ("127.0.0.1", 8000);
		gameObject.AddComponent<GlobalTimer>();
		m__role__login__c2s proto = new m__role__login__c2s();
		proto.name = input.text;
		NetMgr.addCMD (ProtoMap.m__role__login__s2c, LoginS2C);
		NetMgr.Instance.send (proto);
	}

	public void LoginS2C(ProtoBase proto)
	{
		Debug.Log ("logn s2c ");
		SceneManager.LoadScene ("battle");
	}

}
