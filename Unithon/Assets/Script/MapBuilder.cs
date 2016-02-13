using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapBuilder : MonoBehaviour
{
    public UIGrid grid;
    public List<Block> blocklist = new List<Block>();

    public void SetData(int percent)
    {
        Debug.Log(percent);
        System.Random r = new System.Random();
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            blocklist.Add(grid.transform.GetChild(i).GetComponent<Block>());
            int hi = r.Next(0, 100);
            if (hi < percent)
            {
                grid.transform.GetChild(i).gameObject.SetActive(true);
                grid.transform.GetChild(i).GetComponent<Block>().SetColor(r.Next(0,4));
            }
            else
            {
                grid.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
