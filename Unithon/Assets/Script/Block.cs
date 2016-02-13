using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public UISprite sp_Aura = null;
    public UISprite sp_Planet = null;
    public bool ison = false;

    float rotateSpd = 1;
    void Awake()
    {
        sp_Aura = GetComponent<UISprite>();
    }

    void Update()
    {
        transform.Rotate(0, 0, 1 * rotateSpd * Time.deltaTime);
    }

    public void SetColor(int code)
    {
        switch ((GameManger.Color)code)
        {
            case GameManger.Color.Blue:
                sp_Aura.color = new Color(4f/255f, 175f/255f, 1f, 1f);
                break;
            case GameManger.Color.Red:
                sp_Aura.color = Color.red;
                break;
            case GameManger.Color.White:
                sp_Aura.color = Color.white;
                break;
            case GameManger.Color.Yellow:
                sp_Aura.color = new Color(240f/255f, 1f, 4f/255f, 1f);
                break;
        }

        sp_Planet.spriteName = (code % 2 == 1) ? "p_1" : "p_2";
        transform.localScale = Vector3.one * ((float)Random.Range(80, 130) / 100f);
        rotateSpd = Random.Range(50, 300);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
            ison = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
            ison = false;
    }
}
