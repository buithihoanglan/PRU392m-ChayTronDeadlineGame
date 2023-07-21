using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPool : MonoBehaviour
{
    public int poolSize = 16;
    List<Map> maplist = new List<Map>();

    public static MapPool instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Map map0 = new Map0();
        map0.isActive = false;
        maplist.Add(map0);

        for (int i = 1; i < poolSize; i++)
        {
            Map map = new Map();
            map.isActive = false;
            maplist.Add(map);
        }
    }

    public Map GetMap()
    {
        for (int i = 1; i < maplist.Count; i++)
        {
            if (!maplist[i].isActive)
            {
                return maplist[i];
            }
        }
        return null;
    }

    public Map0 GetMap0()
    {
        return (Map0)maplist[0];
    }

    public void ReturnMap(Map map)
    {
        map.clear();
    }
}
