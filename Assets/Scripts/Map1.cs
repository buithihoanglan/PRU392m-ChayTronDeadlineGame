using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Map1 : Map
{
    //10 floor
    public new void initValueMap(int wallAmount, int coinAmount, Vector2 startPos)
    {
        base.initValueMap(wallAmount, coinAmount, startPos);
        //chon ra cac floor ko co wall va co wall
        chooseFloorHaveNoWall(wallAmount-2);//tru di 2 wall cua tang 10th
        //set wall cho cac floor con lai
        generateWall();
    }

    public void generateWall()
    {
        int a = 0;
        float wallLeftPosX = startPosition.x - maxFloorLength / 2 + 0.05f;
        float wallRightPosX = wallLeftPosX + maxFloorLength - 0.1f;
        for (int i = 0; i < isFloorHaveWall.Count; i++)
        {
            switch (isFloorHaveWall[i])
            {
                case -1:
                    walls[a].transform.Translate(wallLeftPosX, getFloorPosY(i+1) + floorDistance / 2, 1);
                    a++;
                    break;
                case 2:
                    walls[a].transform.Translate(wallLeftPosX, getFloorPosY(i + 1) + floorDistance / 2, 1);
                    a++;
                    walls[a].transform.Translate(wallRightPosX, getFloorPosY(i + 1) + floorDistance / 2, 1);
                    a++;
                    break;
                case 1:
                    walls[a].transform.Translate(wallRightPosX, getFloorPosY(i+1) + floorDistance / 2, 1);
                    a++;
                    break;
            }
        }
    }

    public void chooseFloorHaveNoWall(int wallAmount)
    {
        //9-wallAmount = no wall amount
        switch (9-wallAmount)
        {
            case 2:
                Debug.Log(2);
                map2NoWall();
                break;
            case 3:
                Debug.Log(3);
                map3NoWall();
                break;
            case 4:
                Debug.Log(4);
                map4NoWall();
                break;
            case 5:
                Debug.Log(5);
                map5NoWall();
                break;
        }
    }

    public void map2NoWall()
    {
        int firstNoWall = Random.Range(1,10);
        int secondNoWall;
        if(firstNoWall >= 8)
        {
            secondNoWall= Random.Range(1,firstNoWall);
        }
        else
        {
            secondNoWall= Random.Range(firstNoWall+1, 10);
        }

        int a = randomInt(new List<int> { -1, 1 });
        for(int i = 0; i < 9; i++)
        {
            if(i!=firstNoWall-1)
            {
                if (i != secondNoWall - 1)
                {
                    isFloorHaveWall[i] = a;
                    a = -a;
                }
            }
        }
        isFloorHaveWall[9] = 2;
    }

    public void map3NoWall()
    {
        List<int> floorHaveWall = new List<int>() {0,0,0};
        floorHaveWall.Insert(Random.Range(1, 3), 1);

        for(int i = 0; i <5; i++)
        {
            floorHaveWall.Insert(Random.Range(0, floorHaveWall.Count), 1);
        }

        int a = randomInt(new List<int> { -1, 1 });
        for (int i = 0; i < floorHaveWall.Count; i++)
        {
            if(floorHaveWall[i] == 1)
            {
                floorHaveWall[i] = a;
                a = -a;
            }
        }

        floorHaveWall.Add(2);
        isFloorHaveWall = floorHaveWall;
    }

    public void map4NoWall()
    {
        List<int> floorHaveWall = new List<int>() { 0, 0, 0,0 };
        floorHaveWall.Insert(2, 1);

        for (int i = 0; i < 4; i++)
        {
            floorHaveWall.Insert(Random.Range(0, floorHaveWall.Count), 1);
        }

        int a = randomInt(new List<int> { -1, 1 });
        for (int i = 0; i < floorHaveWall.Count; i++)
        {
            if (floorHaveWall[i] == 1)
            {
                floorHaveWall[i] = a;
                a = -a;
            }
        }

        floorHaveWall.Add(2);
        isFloorHaveWall = floorHaveWall;
    }

    public void map5NoWall()
    {
        List<int> floorHaveWall = new List<int>() { 0, 0, 0, 0, 0 };
        switch (Random.Range(1, 4))
        {
            case 1:
                floorHaveWall.Insert(3, 1);
                floorHaveWall.Insert(1, 1);
                break;
            case 2:
                floorHaveWall.Insert(4, 1);
                floorHaveWall.Insert(2, 1);
                break;
            case 3:
                floorHaveWall.Insert(3, 1);
                floorHaveWall.Insert(2, 1);
                break;
        }

        for (int i = 0; i < 2; i++)
        {
            floorHaveWall.Insert(Random.Range(0, floorHaveWall.Count), 1);
        }

        int a = randomInt(new List<int> { -1, 1 });
        for (int i = 0; i < floorHaveWall.Count; i++)
        {
            if (floorHaveWall[i] == 1)
            {
                floorHaveWall[i] = a;
                a = -a;
            }
        }

        floorHaveWall.Add(2);
        isFloorHaveWall = floorHaveWall;
    }
}
