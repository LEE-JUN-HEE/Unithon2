using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public bool ison = false;

    void OnClick()
    {
        Debug.Log(gameObject);
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
