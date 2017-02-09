using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Engine;

public enum GameState
{
    Running,
    Pause
}

public class GameManager : MonoBehaviour {

    public Text scoreText; //获取显示分数的组件
    public static GameManager _instance;
    public int score;
    public GameState gs = GameState.Running;

	// Use this for initialization
	void Start () {
        _instance = this;
		m__scene__enter__c2s proto = new m__scene__enter__c2s();
		NetMgr.addCMD (ProtoMap.m__scene__roles__s2c, RolesS2C);
		NetMgr.Instance.send (proto);
	}

    public void addScore(int sc)
    {
        this.score += sc;
        scoreText.text = "Score:" + score;
    }

    public void switchGameState()
    {
        if (gs == GameState.Running)
        {
            pauseGame();
        }
        else if(gs == GameState.Pause)
        {
            continueGame();
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        gs = GameState.Pause;
    }

    public void continueGame()
    {
        Time.timeScale = 1;
        gs = GameState.Running;
    }

    // Update is called once per frame
    void Update () {
	    
	}


	public void RolesS2C(ProtoBase proto)
	{
		Debug.Log ("roles s2c ");
		Object original = Resources.Load ("Prefabs/hero");

		m__scene__roles__s2c p = proto as m__scene__roles__s2c;
		for (int i = 0; i < p.roles.Count; i++) 
		{
			Object copyObject = GameObject.Instantiate(original);
			copyObject.name = copyObject.name.Replace("(Clone)", "_" + p.roles[i].name);
		}
	}
}
