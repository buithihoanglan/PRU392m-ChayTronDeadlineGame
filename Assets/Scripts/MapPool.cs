using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPool : MonoBehaviour
{
    public int poolSize = 17;
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

        for (int i = 1; i < 5; i++)
        {
            Map map = new Map1();
            map.isActive = false;
            maplist.Add(map);
        }

        for (int i = 5; i < 9; i++)
        {
            Map map = new Map2();
            map.isActive = false;
            maplist.Add(map);
        }

        for (int i = 9; i < 13; i++)
        {
            Map map = new Map3();
            map.isActive = false;
            maplist.Add(map);
        }

        for (int i = 13; i < 17; i++)
        {
            Map map = new Map4();
            map.isActive = false;
            maplist.Add(map);
        }
    }

    public Map GetMap(int mapType)
    {
        for (int i = ((mapType-1)*4+1); i < (mapType*4+1); i++)
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
