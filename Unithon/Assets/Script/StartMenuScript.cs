using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour
{
    public GameObject howto;
    public GameObject startBtn;
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

    // Update is called once per frame
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
        //_sprite.color = new Color(Random.value, Random.value, Random.value);

        if (gameObject.activeInHierarchy)
            isStarted = true;

    }

    //HowTo버튼 눌렀을 때
    public void OnClick_howto()
    {
        //_sprite.color = new Color(Random.value, Random.value, Random.value);
        howto.SetActive(true);
        startBtn.SetActive(false);
        howtoBtn.SetActive(false);
    }
}
