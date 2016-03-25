using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //Logic
    public UISprite sp_Player;
    public Vector2 Direction;
    public Rigidbody2D rigid;
    public GameManger.Color color;
    Vector2 firstPos;
    Vector2 lastPos;

    bool ispull = false;
    public bool ismove = false;
    public bool iscontrol = false;

    //UI
    public UIWidget Arrow;
    public GameObject Line1;
    public GameObject Line2;
    public GameObject Fire;

    void Start()
    {
        SetColor();
    }

    void SetColor()
    {
        System.Random r = new System.Random();
        color = (GameManger.Color)r.Next(0, 4);
        switch (color)
        {
            case GameManger.Color.Blue:
                sp_Player.color = new Color(4f / 255f, 175f / 255f, 1f, 1f);
                break;
            case GameManger.Color.Red:
                sp_Player.color = Color.red;
                break;
            case GameManger.Color.White:
                sp_Player.color = Color.white;
                break;
            case GameManger.Color.Yellow:
                sp_Player.color = new Color(240f / 255f, 1f, 4f / 255f, 1f);
                break;
        }
    }

    void LateUpdate()
    {
        if (iscontrol && ismove && transform.localPosition.y > lastPos.y)
        {
            ismove = (rigid.velocity.magnitude != 0);
            if (rigid.velocity.magnitude <= 0.6f)
                Fire.SetActive(false);

            //화면 밖에 나갔는지 판단
            Vector2 viewport = GameManger.Instance.follow.GetComponent<Camera>().WorldToViewportPoint(transform.position);
            if (viewport.x < 0)
            {
                rigid.velocity = new Vector2(Mathf.Abs(rigid.velocity.x), rigid.velocity.y);
            }
            else if (viewport.x > 1)
            {
                rigid.velocity = new Vector2(-Mathf.Abs(rigid.velocity.x), rigid.velocity.y);
            }

            if (!ismove)
            {
                CheckAfterStop();
            }
            if (GameManger.Instance.follow.thiscamera.WorldToViewportPoint(transform.position).y > 1)
            {
                GameManger.Instance.follow.Damp();
            }
        }
    }

    void OnPress(bool ispress)
    {
        if (GameManger.Instance.follow.isdamp) return;
        if (ismove) return;

        if (ispress)
        {
            ispull = true;
            iscontrol = true;
            firstPos = transform.localPosition;

            //Arrow.gameObject.SetActive(true);
            Line1.SetActive(true);
            Line2.SetActive(true);
        }
        else
        {
            ispull = false;
            GetComponent<AudioSource>().Play();
            lastPos = transform.localPosition;

            if (lastPos.y >= firstPos.y) return;

            ismove = true;
#if UNITY_EDITOR
            GetComponent<Rigidbody2D>().AddForce(firstPos * 0.5f - lastPos * 0.5f);
#endif
#if UNITY_ANDROID
            GetComponent<Rigidbody2D>().AddForce(firstPos * 0.3f - lastPos * 0.3f);
#endif

            //Arrow.gameObject.SetActive(false);
            //Arrow.transform.rotation = Quaternion.identity;
            Fire.SetActive(true);
            Fire.transform.TransformDirection((firstPos - lastPos).x, (firstPos - lastPos).y, 0);
            Line1.SetActive(false);
            Line2.SetActive(false);
        }
    }

    void OnClick()
    {
        if (ismove) return;
        ismove = false;
        iscontrol = false;
        Line1.SetActive(false);
        Line2.SetActive(false);
    }

    void OnDrag(Vector2 delta)
    {
        if (!ispull) return;

        transform.localPosition = (Vector2)transform.localPosition + delta;
        if (transform.localPosition.y > firstPos.y)
            transform.localPosition = firstPos;
        lastPos = transform.localPosition;

        Direction = (firstPos - lastPos).normalized;
    }

    void CheckAfterStop()
    {
        Fire.transform.rotation = Quaternion.identity;
        

        //발판 위에 있는지 판단
        if (!GameManger.Instance.CheckPlayerOnBlock())
        {
            GameManger.Instance.GameOver();
            return;
        }
        //발판과 색깔이 겹치는지 판단

        //맵 루프 여부 판단
        GameManger.Instance.CheckMapLoop(transform.localPosition.y);

        //배경 루프 여부 판단
        GameManger.Instance.CheckBGLoop(transform.localPosition.y);

        //UI 옮김
        Line1.transform.localPosition = new Vector2(transform.localPosition.x - 320, 0);
        Line2.transform.localPosition = new Vector2(transform.localPosition.x + 320, 0);
        Arrow.transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);

        //스코어 적립
        if (GameManger.Instance.CheckColor())
        {
            GameManger.Instance.score += (long)(transform.localPosition.y - firstPos.y);
        }
        GameManger.Instance.score += (long)(transform.localPosition.y - firstPos.y);
        GameManger.Instance.UpdateUI();

        GameManger.Instance.follow.Damp();
        iscontrol = false;
        SetColor();
    }
}
