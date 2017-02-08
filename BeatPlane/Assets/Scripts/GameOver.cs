using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public static GameOver _instance;
    public Text nowScoreText; //显示现在的分数
    public Text highScoreText; //显示最高分

	// Use this for initialization
	void Start () {
        _instance = this;
        this.gameObject.SetActive(false);
        nowScoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
	}

    public void showScore(int nowScore)
    {
        int historyScore = PlayerPrefs.GetInt("historyHighScore", 0);
        if (nowScore > historyScore)
        {
            PlayerPrefs.SetInt("historyHighScore", nowScore);
        }
        highScoreText.text = historyScore + "";
        this.nowScoreText.text = nowScore + "";
        this.gameObject.SetActive(true);
        nowScoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        GameManager._instance.scoreText.gameObject.SetActive(false);
        bombManager._instance.boomIcon.gameObject.SetActive(false);
        bombManager._instance.boomNumber.gameObject.SetActive(false);
        GameStateButton._instance.gameObject.SetActive(false);

        MusicManager._instance.StopBGM();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
