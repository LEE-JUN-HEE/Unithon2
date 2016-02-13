using UnityEngine;
using System.Collections;

public class MenuPanelScript : MonoBehaviour
{
    public UIPanel menuPanel;
    public UISprite UIsprite;
    public Texture menuBackground01;
    public Texture menuBackground02;
    int imageSwitchNum=1;

    // Use this for initialization
    void Start ()
    {
        UIsprite = GetComponent<UISprite>();
        menuPanel = GetComponent<UIPanel>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(imageSwitchNum == 1)
        {
            //Debug.Log(UIsprite);
            //UIsprite.spriteName = "menuBackground01";
            imageSwitchNum = 2;
        }
        else
        {
            UIsprite.spriteName = "menuBackground02";
            imageSwitchNum = 1;
        }



	}
}
