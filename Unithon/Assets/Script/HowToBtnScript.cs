using UnityEngine;
using System.Collections;

public class HowToBtnScript : MonoBehaviour {

    UISprite _sprite;
    public GameObject storyBtn;
    public GameObject manualBtn;

	// Use this for initialization
	void Start () {
        //_sprite = GetComponent<UISprite>();
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnClick_storyBtn()
    {
        Debug.Log("story버튼 클릭");
        //_sprite.color = new Color(Random.value, Random.value, Random.value);
        
    }

    public void OnClick_manualBtn()
    {
        Debug.Log("manual버튼 클릭");
        //_sprite.color = new Color(Random.value, Random.value, Random.value);

    }
}
