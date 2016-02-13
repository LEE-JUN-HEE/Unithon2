using UnityEngine;
using System.Collections;

public class PositionUpdate : MonoBehaviour {
    bool loop = false;
	void Update () 
    {
        if(loop)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);

        loop = !loop;
	}
}
