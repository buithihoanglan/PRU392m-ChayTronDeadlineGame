using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    Vector2 startPos = new Vector2(0, 1.5f);
    Vector2 pos;
    Vector3 playerPos;
    public GameObject player;
    public static int mapType = 0;
    public static float posXForCam = 0;
    public static float anchorPoint;
    List<Map> activeMaps = new List<Map>();
    List<int> mapTypeList = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        pos.Set(startPos.x, startPos.y);

        mapTypeList.AddRange(new List<int> {0,1,1,3 });
        activeMaps.Add(MapPool.instance.GetMap0()); 
        ((Map0)activeMaps[0]).initValueMap(14, 11, 0, startPos);
        pos.Set(startPos.x, startPos.y + 9.9f);

        activeMaps.Add(MapPool.instance.GetMap(1)); 
        ((Map1)activeMaps[1]).initValueMap(6 + 2, 0, pos);
        pos = activeMaps[1].getNextStartPosition();

        activeMaps.Add(MapPool.instance.GetMap(1));
        ((Map1)activeMaps[2]).initValueMap(Random.Range(4, 8) + 2, 0, pos);
        pos = activeMaps[2].getNextStartPosition();

        activeMaps.Add(MapPool.instance.GetMap(3)); 
        ((Map3)activeMaps[3]).initValueMap(7, 13, 0, pos, false);
        pos = ((Map3)activeMaps[3]).getNextStartPosition();

        anchorPoint = activeMaps[2].startPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        if (playerPos.y >= anchorPoint)
        {
            anchorPoint = activeMaps[3].startPosition.y;
            MapPool.instance.ReturnMap(activeMaps[0]);
            activeMaps.RemoveAt(0);
            mapTypeList.RemoveAt(0);
            mapType = mapTypeList[1];
            posXForCam = activeMaps[1].floors[0].transform.position.x;

            switch (Random.Range(0, 2))//0: map1, 1: map3
            {
                case 0:
                    activeMaps.Add(MapPool.instance.GetMap(1)); mapTypeList.Add(1);
                    ((Map1)activeMaps[3]).initValueMap(Random.Range(4, 8) + 2, 0, pos);
                    pos = activeMaps[3].getNextStartPosition();
                    break;
                case 1:
                    activeMaps.Add(MapPool.instance.GetMap(3)); mapTypeList.Add(3);
                    ((Map3)activeMaps[3]).initValueMap(Random.Range(0, 2) == 0 ? 5 : 7, Random.Range(11, 14), 0, pos, Random.Range(0, 2) == 0 ? true : false);
                    pos = ((Map3)activeMaps[3]).getNextStartPosition();
                    break;
            }
        }
    }
}
