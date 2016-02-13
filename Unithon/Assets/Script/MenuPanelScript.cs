using UnityEngine;
using System.Collections;

public class MenuPanelScript : MonoBehaviour
{
	public UIAtlas left;
	public UIAtlas right;
	public UIAtlas body;
	public UIAtlas menuBackground01;
	public UIAtlas menuBackground02;

    public UIPanel menuPanel;
    public UISprite UIsprite;
	int imageSwitchNum=1;

    // Use this for initialization
    void Start ()
    {
        UIsprite = GetComponent<UISprite>();
        menuPanel = GetComponent<UIPanel>();
		//menuBackground01 = GetComponent<UIAtlas>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(imageSwitchNum == 1)
		{
			//if (menuBackground01.enabled == true)
			//	Debug.Log ("01");
			//menuBackground01.enabled = true;
			//if (menuBackground01.enabled == true)
			//	Debug.Log ("01-1");
			//Debug.Log(UIsprite);
            //UIsprite.spriteName = "menuBackground01";
            imageSwitchNum = 2;
        }
        else
        {
			//menuBackground01.enabled = false;
            //UIsprite.spriteName = "menuBackground02";
            imageSwitchNum = 1;
        }



	}
}
