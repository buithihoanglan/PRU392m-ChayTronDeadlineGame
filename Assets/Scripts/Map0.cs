using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map0 : Map
{
    //11 floor, 14 wall
    //TAI SAO HAM NAY LAI LUC CHAY 1 LAN LUC CHAY 2 LAN ????????????
    public new void initValueMap(int wallAmount, int floorAmount, int coinAmount, Vector2 startPos)
    {
        base.initValueMap(wallAmount, floorAmount, coinAmount, startPos);
        //chon ra 2 floor co 2 wall(tru wall dau va wall cuoi)
        int a = randomInt(3, 5);
        int b = 7;
        switch (a){
            case 3:
                b=randomInt(5, 8);
                break;
            case 4:
                b = randomInt(6, 9);
                break;
            case 5:
                b = randomInt(new List<int> {2,7,8});
                break;
        }
        float wallLeftPosX = -(startPos.x + maxFloorLength / 2 - 0.05f);
        float wallRightPosX = wallLeftPosX + maxFloorLength - 0.1f;
        //set position cho 8 wall do (2 floor dau cuoi va 2 floor vua chon)
        walls[0].transform.Translate(wallRightPosX, startPos.y + floorDistance/2, 1);//floor 1
        walls[1].transform.Translate(wallLeftPosX, startPos.y + floorDistance / 2, 1);
        isFloorHaveWall[0] = 2;

        walls[2].transform.Translate(wallRightPosX, getFloorPosY(11) + floorDistance / 2, 1);//floor 11
        walls[3].transform.Translate(wallLeftPosX, getFloorPosY(11) + floorDistance / 2, 1);
        isFloorHaveWall[floorAmount-1] = 2;

        walls[4].transform.Translate(wallRightPosX, getFloorPosY(a) + floorDistance / 2, 1);
        walls[5].transform.Translate(wallLeftPosX, getFloorPosY(a) + floorDistance / 2, 1);
        isFloorHaveWall[a-1] = 2;

        walls[6].transform.Translate(wallRightPosX, getFloorPosY(b) + floorDistance / 2, 1);
        walls[7].transform.Translate(wallLeftPosX, getFloorPosY(b) + floorDistance / 2, 1);
        isFloorHaveWall[b-1] = 2;
        //chon ra 1 floor ko co wall => floor b+1
        isFloorHaveWall[b] = 0;
        //set wall cho 2 floor lien ke floor a
        isFloorHaveWall[a - 2] = randomInt(new List<int> {-1,1});
        isFloorHaveWall[a ] = isFloorHaveWall[a - 2];
        walls[8].transform.Translate(isFloorHaveWall[a-2] == 1? wallRightPosX : wallLeftPosX, getFloorPosY(a-1) + floorDistance / 2, 1);
        walls[9].transform.Translate(isFloorHaveWall[a-2] == 1 ? wallRightPosX : wallLeftPosX, getFloorPosY(a+1) + floorDistance / 2, 1);
        //set wall cho cac floor con lai

        int nextUseWallIndexInFloorList = 10;

        for(int i = 1; i < floorAmount+1; i++)
        {
            if(i != 1 && i != 11 && i != b && i != b+1 && i != a && i!= a-1 && i != a+1)
            {
                switch (isFloorHaveWall[i-2])
                {
                    case -1:
                        walls[nextUseWallIndexInFloorList].transform.Translate(wallRightPosX, getFloorPosY(i) + floorDistance / 2, 1);
                        isFloorHaveWall[i-1] = 1;
                        nextUseWallIndexInFloorList++;
                        //Debug.Log(nextUseWallIndexInFloorList);
                        break;
                    case 0:
                    case 2:
                        int wallSide = randomInt(new List<int> { -1, 1 }) == 1 ? 1 : -1;
                        walls[nextUseWallIndexInFloorList].transform.Translate(wallSide == 1 ? wallRightPosX : wallLeftPosX, getFloorPosY(i) + floorDistance / 2, 1);
                        isFloorHaveWall[i - 1] = wallSide;
                        nextUseWallIndexInFloorList++;
                        //Debug.Log(nextUseWallIndexInFloorList);
                        break;
                    case 1:
                        walls[nextUseWallIndexInFloorList].transform.Translate(wallLeftPosX, getFloorPosY(i) + floorDistance / 2, 1);
                        isFloorHaveWall[i-1] = -1;
                        nextUseWallIndexInFloorList++;
                        //Debug.Log(nextUseWallIndexInFloorList);
                        break;
                }
            }
        }
    }
}
