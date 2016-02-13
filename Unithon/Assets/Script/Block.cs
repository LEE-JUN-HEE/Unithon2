using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public UISprite sp_Aura = null;
    public bool ison = false;

    void Awake()
    {
        sp_Aura = GetComponent<UISprite>();
    }

    public void SetColor(int code)
    {
        switch ((GameManger.Color)code)
        {
            case GameManger.Color.Blue:
                sp_Aura.color = Color.blue;
                break;
            case GameManger.Color.Red:
                sp_Aura.color = Color.red;
                break;
            case GameManger.Color.White:
                sp_Aura.color = Color.white;
                break;
            case GameManger.Color.Yellow:
                sp_Aura.color = Color.yellow;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hi");
        if (col.tag == "Player")
            ison = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("bye");
        if (col.tag == "Player")
            ison = false;
    }
}
