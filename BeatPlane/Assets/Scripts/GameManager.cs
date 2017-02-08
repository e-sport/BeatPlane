using UnityEngine;
using System.Collections;
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
//		gameObject.AddComponent<GlobalTimer>();
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
}
