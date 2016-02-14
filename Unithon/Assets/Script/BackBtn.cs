using UnityEngine;
using System.Collections;

public class BackBtn : MonoBehaviour 
{
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                // 할꺼 하셈
                Application.Quit();
            }
        }
    }

}
