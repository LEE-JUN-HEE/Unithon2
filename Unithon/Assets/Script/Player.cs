using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Vector2 Direction;
    public Rigidbody2D rigid;
    Vector2 firstPos;
    Vector2 lastPos;

    bool ispull = false;
    public bool ismove = false;
    bool iscontrol = false;


    void LateUpdate()
    {
        if (iscontrol && ismove && transform.localPosition.y > lastPos.y)
        {
            ismove = (rigid.velocity.magnitude != 0);
            if (!ismove)
            {
                CheckAfterStop();
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
        }
        else
        {
            ispull = false;
            lastPos = transform.localPosition;

            if (lastPos.y >= firstPos.y) return;

            ismove = true;
            GetComponent<Rigidbody2D>().AddForce(firstPos - lastPos);
        }
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
        //화면 밖에 나갔는지 판단
        Vector2 viewport = GameManger.Instance.follow.GetComponent<Camera>().WorldToViewportPoint(transform.position);
        if (viewport.x < 0 || viewport.x > 1)
        {
            GameManger.Instance.GameOver();
            return;
        }

        Debug.Log(GameManger.Instance.CheckPlayerOnBlock());
        //발판 위에 있는지 판단
        if (!GameManger.Instance.CheckPlayerOnBlock())
        {
            GameManger.Instance.GameOver();
            return;
        }

        //스코어 적립
        GameManger.Instance.score += transform.localPosition.y - firstPos.y;
        GameManger.Instance.UpdateUI();

        GameManger.Instance.follow.Damp();
    }


    void OnClick()
    {
        Debug.Log(gameObject);
    }
}
