using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour
{
    public GameObject howto;
    public GameObject startBtn;
    public GameObject RankBtn;
    public GameObject howtoBtn;
    public UIPanel _panel;
    UISprite _sprite;

    bool isStarted = false;

    void Start()
    {
        _sprite = GetComponent<UISprite>();
        howto.SetActive(false);
        _panel.alpha = 1f;
    }

    void Update()
    {
        if (isStarted == true)
        {
            //투명도 감소
            _panel.alpha -= 0.01f;

            //적당히 투명해지면 Ingame으로 씬 넘김
            if (_panel.alpha <= 0.05f)
            {
                Application.LoadLevel("Ingame");
                isStarted = false;
            }
        }
    }

    //start버튼 눌렀을 때
    public void OnClick_start()
    {
        if (gameObject.activeInHierarchy)
            isStarted = true;

    }

    //HowTo버튼 눌렀을 때
    public void OnClick_howto()
    {
        howto.SetActive(true);
        startBtn.SetActive(false);
        howtoBtn.SetActive(false);
        RankBtn.SetActive(false);
    }
}
