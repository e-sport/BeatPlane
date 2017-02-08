using UnityEngine;
using System.Collections;

public class GameStateButton : MonoBehaviour {

    public Sprite[] sp;
    SpriteRenderer spRender;
    public static GameStateButton _instance;

    void Awake()
    {
        _instance = this;
    }


	// Use this for initialization
	void Start () {
        spRender = GetComponent<SpriteRenderer>();
	}

    void OnMouseUpAsButton()
    {
        if (GameManager._instance.gs == GameState.Running)
        {
            setToPause();
            GameManager._instance.switchGameState();
        }
        else
        {
            setToContinue();
            GameManager._instance.switchGameState();
        }
    }

    public void setToPause()
    {
        spRender.sprite = sp[1];
    }

    public void setToContinue()
    {
        spRender.sprite = sp[0];
    }

}
