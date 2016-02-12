using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenuScript : MonoBehaviour {

    public GameObject startBtn;
    public GameObject howtoBtn;
    public GameObject exitBtn;

    UISprite _sprite;

	// Use this for initialization
	void Start ()
    {
        _sprite = GetComponent<UISprite>();
        howtoBtn.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	}

    //start버튼 눌렀을 때
    public void OnClick_start()
    {
        _sprite.color = new Color(Random.value, Random.value, Random.value);
        

        SceneManager.LoadScene("Ingame");
        
    }

    //HowTo버튼 눌렀을 때
    public void OnClick_howto()
    {
        _sprite.color = new Color(Random.value, Random.value, Random.value);
        howtoBtn.SetActive(true);
    }

    //exit버튼 눌렀을 때
    public void OnClick_exit()
    {
        _sprite.color = new Color(Random.value, Random.value, Random.value);
    }

    //마우스 올렸을 때
    void OnHover(bool isOver)
    {
        //스프라이트 확대!
        _sprite.cachedTransform.localScale = (isOver) ? Vector2.one * 1.2f : Vector2.one;
           
    }
          
}
