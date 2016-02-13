using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Transform tr;
    public Camera thiscamera;
	public Transform target;
    public Vector2 initPos;
    public bool isdamp = false;
    float velocity = 0;

	// Use this for initialization
	void Start () {
		tr = this.GetComponent<Transform>(); //카메라의 위치값.
        initPos = target.position;
	}

    public void Damp()
    {
        isdamp = true;
    }
    void FixedUpdate()
    {
        if (!isdamp) return; 

        Mathf.SmoothDamp(tr.position.y, target.position.y, ref velocity, 0.01f);        
        tr.localPosition += new Vector3(0, velocity, 0);

        if (velocity <= 0.5f)
        {
            isdamp = false; 
            tr.position = new Vector3(0, target.position.y, 0);
            initPos = target.position;
            //이게뭐야 ㅡㅡ
            GameManger.Instance.player.gameObject.SetActive(false);
            GameManger.Instance.player.gameObject.SetActive(true);
        }
    }
}
