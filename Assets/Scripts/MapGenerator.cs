using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    Vector2 startPos = new Vector2(0, 1.5f);
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos.Set(startPos.x, startPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(pos.y == startPos.y)
        {
            pos.Set(startPos.x, startPos.y + 9f);
            MapPool.instance.GetMap0().initValueMap(14,11,0,startPos);
        }
        else
        {
            //pos.Set(startPos.x, startPos.y);
        }
    }
}
