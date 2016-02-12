using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManger : MonoBehaviour {
    static public GameManger Instance;

    //Component
    public CameraFollow follow;
    public Player player;

    //Logic
    public float score = 0;
    public bool gameOver = false;
    public List<MapBuilder> maplist = new List<MapBuilder>();

    //UI
    public UILabel lb_score;
    public GameObject GO_Pause;
    public GameObject GO_GameOver;
    public UILabel lb_gameoverScore;

    void Awake()
    {
        Instance = this;
        UpdateUI();
    }

    public void GameOver()
    {
        gameOver = true;
        lb_gameoverScore.text = string.Format("{0:0.0}", score);
        GO_GameOver.SetActive(true);
    }

    public void UpdateUI()
    {
        lb_score.text = string.Format("{0:0.0}",score);
    }

    public void OnClick_Pause()
    {
        Time.timeScale = 0;
        GO_Pause.SetActive(true);
    }

    public void OnClick_PauseClose()
    {
        Time.timeScale = 1;
        GO_Pause.SetActive(false);
    }

    public void OnClick_Exit()
    {

    }

    public bool CheckPlayerOnBlock()
    {
        for (int i = 0; i < maplist.Count; i++)
        {
            for (int j = 0; j < maplist[i].blocklist.Count; j++)
            {
                if (maplist[i].blocklist[j].ison)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
