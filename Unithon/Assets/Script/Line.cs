using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {

    public Transform target;
    public UIWidget linewidget;

	void Update () 
    {
        transform.LookAt(target);
        linewidget.width = (int)(target.localPosition - transform.localPosition).magnitude;
	}
}
