using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapBuilder : MonoBehaviour
{
    public UIGrid grid;
    public List<Block> blocklist = new List<Block>();

    public void Start()
    {
        SetData();
    }
    public void SetData()
    {
        System.Random r = new System.Random();
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            blocklist.Add(grid.transform.GetChild(i).GetComponent<Block>());
            int hi = r.Next(0, 2);
            if (hi == 1)
            {
                grid.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                grid.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
