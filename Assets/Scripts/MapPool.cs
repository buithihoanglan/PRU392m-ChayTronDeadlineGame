using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPool : MonoBehaviour
{
    public int poolSize = 15;
    List<Map> maplist = new List<Map>();

    public static MapPool instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        for (int i = 0; i < poolSize; i++)
        {
            Map map = new Map();
            map.isActive = false;
            maplist.Add(map);
        }
    }

    public Map GetMap()
    {
        for (int i = 0; i < maplist.Count; i++)
        {
            if (!maplist[i].isActive)
            {
                return maplist[i];
            }
        }
        return null;
    }

    public void ReturnMap(Map map)
    {
        map.clear();
    }
}
