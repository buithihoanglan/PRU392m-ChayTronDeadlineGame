using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map3 : Map
{
    int wallIndex;
    int floorIndex;
    List<float> startXList;
    List<int> tangHaveFloor;
    //wall amount: 2 or 4 + 3 => so lan xuat hien cua type 3 trong map 3 va 3 wall cho tang 9(1) va 10(2) => wall amount >=5
    //floor amount - 10 => so wall cho type 2 trong map 3
    public void initValueMap(int wallAmount, int floorAmount, int coinAmount, Vector2 startPos, bool toLeft)
    {
        base.initValueMap(wallAmount,floorAmount, coinAmount, startPos);

        int type3 = (wallAmount - 3) == 2 ? 1 : 2;//so luong type3
        List<int> floorHaveWall = new List<int>();
        tangHaveFloor = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        floorHaveWall.Add(Random.Range(1, 8));
        isFloorHaveWall[floorHaveWall[0]-1] = 1;
        isFloorHaveWall[floorHaveWall[0]] = 1;
        if (type3 == 2)
        {
            if (floorHaveWall[0] >=5)
            {
                floorHaveWall.Add(Random.Range(1, 4));
            }
            else
            {
                floorHaveWall.Add(Random.Range(floorHaveWall[0] + 2, 7));
            }
            isFloorHaveWall[floorHaveWall[1]-1] = 1;
            if (wallAmount - 3 == 4)
            {
                isFloorHaveWall[floorHaveWall[1]] = 1;
            }
        }

        //so luong type 2 = floor amount -10
        List<int> listType2 = new List<int>();//luu tru nhung tang dc them floor (1 ptu = +1 floor cho tang do. VD: 2 => +1 floor cho tang thu 2)
        List<int> floorHaveType2 = new List<int>();//luu tru nhung tang dung de random floor co type 2
        int a;
        for (int i = 0; i < 8; i++)
        {
            if (isFloorHaveWall[i] != 1)
            {
                floorHaveType2.Add(i+1);
            }
        }
        for(int i = 0; i < floorAmount - 10; i++)
        {
            a = randomInt(floorHaveType2);
            listType2.Add(a);
            tangHaveFloor[a-1] += 1;
        }

        //sinh map
        wallIndex = 0;
        floorIndex = 10;
        startXList = new List<float>();
        startXList.Add(startPos.x + (toLeft ? (0.1f - maxFloorLength/2) : (maxFloorLength/2 - 0.1f)));

        for (int i=1;i<9; i++)
        {
            if (isFloorHaveWall[i-1] == 1)
            {
                startXList.Add(startXList[i-1] + (toLeft? -2f : 2f));
                i++;
                startXList.Add(startXList[i-1] + (toLeft ? (-2f - jumpDistance) : (2f + jumpDistance)));
            }
            else if (tangHaveFloor[i-1] != 1)
            {
                startXList.Add(startXList[i - 1] + ((toLeft ? (-2f - jumpDistance) : (2f + jumpDistance)) * tangHaveFloor[i-1]) );
            }
            else
            {
                startXList.Add(startXList[i - 1] + (toLeft ? (-2f - jumpDistance) : (2f + jumpDistance)));
            }
        }

        for (int i = 0; i < tangHaveFloor.Count; i++)
        {
            if(tangHaveFloor[i] > 1)
            {
                generateType2(startXList[i], toLeft, i+1, tangHaveFloor[i]);
            }
            //generate type2
        }

        for (int i = 0; i < 8; i++)
        {
            if (isFloorHaveWall[i] == 1)
            {
                //generate type3
                generateType3(startXList[i], toLeft, i+1);i++;
            }
            else if (tangHaveFloor[i] == 1)
            {
                //generate type bth
                generateNormal(startXList[i], toLeft, i+1);
            }
        }

        //generate tang 9,10
        floors[8].transform.Translate(startXList[8] + (toLeft ? -maxFloorLength/2 : maxFloorLength/2) - startPosition.x, 0, 1);
        floors[8].transform.localScale = new Vector3(maxFloorLength, 0.1f, 1f);
        walls[wallIndex].transform.Translate(startXList[8] + (toLeft ? (0.05f - maxFloorLength) : (maxFloorLength - 0.05f)), getFloorPosY(9) + 0.45f, 1);
        wallIndex++;

        floors[9].transform.Translate(startXList[8] + (toLeft ? -maxFloorLength / 2 : maxFloorLength / 2) - startPosition.x, 0, 1);
        floors[9].transform.localScale = new Vector3(maxFloorLength, 0.1f, 1f);
        walls[wallIndex].transform.Translate(startXList[8] + (toLeft ? (0.05f - maxFloorLength) : (maxFloorLength - 0.05f)), getFloorPosY(10) + 0.45f, 1);
        wallIndex++;
        walls[wallIndex].transform.Translate(startXList[8] + (toLeft ? -0.05f  : 0.05f), getFloorPosY(10) + 0.45f, 1);
        wallIndex++;
    }

    public void generateType3(float startX, bool toLeft, int n_th_floor)
    {
        floors[n_th_floor-1].transform.Translate(startX + (toLeft ? -2f : 2f) - startPosition.x, 0, 1);
        floors[n_th_floor].transform.Translate(startX + (toLeft ? -3f : 3f) - startPosition.x, 0, 1);
        floors[n_th_floor].transform.localScale = new Vector3(2f, 0.1f, 1f);
        floors[n_th_floor - 1].transform.localScale = new Vector3(4f, 0.1f, 1f);

        walls[wallIndex].transform.Translate(startX + (toLeft ? (-0.05f-3.9f) : (0.05f+3.9f)),getFloorPosY(n_th_floor) + 0.45f,1);
        wallIndex++;
        walls[wallIndex].transform.Translate(startX + (toLeft ? (-0.05f - 2f) : (2f + 0.05f)), getFloorPosY(n_th_floor+1) + 0.45f, 1);
        wallIndex++;

    }

    public void generateType2(float startX, bool toLeft, int n_th_floor, int amount)
    {
        floors[n_th_floor - 1].transform.Translate(startX + (toLeft? -1f : 1f) - startPosition.x, 0, 1);
        for(int i = 1; i < amount; i++)
        {
            floors[floorIndex].transform.Translate(startX + (toLeft ? -1f : 1f) + (toLeft ? (-2f - jumpDistance) : (2f + jumpDistance)) *i - startPosition.x, -(floorIndex + 1 - n_th_floor) * floorDistance, 1);
            floors[floorIndex].transform.localScale = new Vector3(2f, 0.1f, 1f);
            floorIndex++;
        }
        floors[n_th_floor - 1].transform.localScale = new Vector3(2f, 0.1f, 1f);
    }

    public void generateNormal(float startX, bool toLeft, int n_th_floor)
    {
        floors[n_th_floor-1].transform.Translate(startX + (toLeft ? -1f : 1f) - startPosition.x, 0, 1);
        floors[n_th_floor - 1].transform.localScale = new Vector3(2f, 0.1f, 1f);
    }

    public new Vector2 getNextStartPosition()
    {
        return new Vector2(floors[9].transform.position.x, startPosition.y + 9f);
    }
}
