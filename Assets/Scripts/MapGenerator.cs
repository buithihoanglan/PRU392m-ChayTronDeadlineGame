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
            pos.Set(startPos.x, startPos.y + 9.8f);//TAI SAO DOI CHO 2 CAU LENH NAY THI SE CO LUC HAM DUOI DUOC CHAY 2 LAN ???????
            MapPool.instance.GetMap0().initValueMap(14, 11, 0, startPos);
            ((Map1)MapPool.instance.GetMap(1)).initValueMap(8, 0, pos);
        }
        else
        {
            //pos.Set(startPos.x, startPos.y);
        }
    }
}
