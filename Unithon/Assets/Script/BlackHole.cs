using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour 
{
    public float velocity = 0.001f;
	
	// Update is called once per frame
	void Update () 
    {
        if (GameManger.Instance.gameOver) return;
        transform.Translate(0, velocity * Time.fixedDeltaTime * 0.05f, 0);
        //velocity = (GameManger.Instance.player.transform.localPosition.y - transform.localPosition.y) * 0.1f > 300
        //    ? (GameManger.Instance.player.transform.localPosition.y - transform.localPosition.y) * 0.1f : 3;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Coll" + col.tag);
        if (col.tag == "Player")
        {
            if (col.GetComponent<Player>().iscontrol) return;
            GameManger.Instance.GameOver();
        }
    }
}
