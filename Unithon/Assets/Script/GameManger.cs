using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManger : MonoBehaviour
{
    static public GameManger Instance;

    public enum Color
    {
        Red,
        Blue,
        White,
        Yellow,
    }

    //Component
    public CameraFollow follow;
    public Player player;

    //Logic
    public float score = 0;
    public bool gameOver = false;
    public float mapoffset = 0;
    public float meteoOffset = 0;
    public int meteoCnt;
    public int maploopcnt = 0;
    public int blockper = 0;
    public Block curOnBlock = null;
    public List<MapBuilder> maplist = new List<MapBuilder>();

    //UI
    public List<UITexture> BGlist = new List<UITexture>();
    public float BGoffset = 0;
    public int BGloopcnt = 0;
    public UILabel lb_score;
    public GameObject GO_Pause;
    public GameObject GO_PauseBtn;
    public GameObject GO_GameOver;
    public GameObject GO_GameOverBtn;
    public UILabel lb_gameoverScore;

    void Awake()
    {
        Instance = this;
        UpdateUI();
        maplist.ForEach(x => x.SetData(blockper));
    }

    public void GameOver()
    {
        player.GetComponent<Collider2D>().enabled = false;
        gameOver = true;
        lb_gameoverScore.text = string.Format("{0:0.0}", score);
        GO_GameOver.SetActive(true);
    }

    public bool CheckPlayerOnBlock()
    {
        for (int i = 0; i < maplist.Count; i++)
        {
            for (int j = 0; j < maplist[i].blocklist.Count; j++)
            {
                if (maplist[i].blocklist[j].ison)
                {
                    curOnBlock = maplist[i].blocklist[j];
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckColor()
    {
        if (curOnBlock == null) 
            return false;

        return player.color == curOnBlock.color;
    }

    public void CheckMapLoop(float localy)
    {
        if ((int)(localy / mapoffset) > maploopcnt)
        {
            int loop = (int)(localy / mapoffset) - maploopcnt;

            for (int i = 0; i < loop; i++)
            {
                maplist[maploopcnt % maplist.Count].transform.localPosition
                       += new Vector3(0, mapoffset * maplist.Count, 0);
                int percent = blockper - (maploopcnt / 2) <= 15 ? 15 : blockper - (maploopcnt / 2);

                maplist[maploopcnt % maplist.Count].SetData(percent);
                maploopcnt++;
            }
        }
    }

    public void CheckMeteo(float localy)
    {
        if ((int)(localy / meteoOffset) > meteoCnt)
        {

            meteoCnt++;
        }
    }

    public void CheckBGLoop(float localy)
    {
        if ((int)(localy / BGoffset) > BGloopcnt)
        {
            BGlist[BGloopcnt % BGlist.Count].transform.localPosition
                   += new Vector3(0, BGoffset * BGlist.Count, 0);
            BGloopcnt++;
        }
    }

    public void UpdateUI()
    {
        lb_score.text = string.Format("{0:0.0}", score);
        if (CheckColor())
        {
            lb_score.GetComponent<UIPlayTween>().Play(true);
        }
    }

    public void OnClick_Pause()
    {
        Time.timeScale = 0;
        GO_Pause.SetActive(true);

        GO_PauseBtn.SetActive(false);
        GO_PauseBtn.SetActive(true);
    }

    public void OnClick_PauseClose()
    {
        Time.timeScale = 1;
        GO_Pause.SetActive(false);
    }

    public void OnClick_Exit()
    {
        Application.LoadLevel("Start");
    }
}
