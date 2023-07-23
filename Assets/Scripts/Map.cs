using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Map {
    public bool isActive;
    public Vector2 startPosition;
    public List<GameObject> walls;
    public List<GameObject> floors;
    public List<int> isFloorHaveWall;// -1: wall left, 0: 0 wall, 1: wall right, 2: 2 wall
    public List<GameObject> coins;
    public static float floorDistance = 0.9f;// = wall.scaleY + floor.scaleY
    public static float maxFloorLength = 5f;
    public static float jumpDistance = 0.8f;

    public Map() { }
    public void initValueMap(int wallAmount, int coinAmount, Vector2 startPos)
    {
        walls = new List<GameObject>(wallAmount);
        floors = new List<GameObject>(10);
        isFloorHaveWall = new List<int>(10);
        isActive = true;

        GameObject wall;
        GameObject floor;
        
        for (int i = 0; i < 10; i++)
        {
            isFloorHaveWall.Add(0);
            floor = FloorPool.instance.GetFloor();
            floor.SetActive(true);

            floor.transform.Translate(startPos.x, startPos.y + floorDistance*i, 1);
            floor.transform.localScale.Set(maxFloorLength, 0.1f, 1f);

            floors.Add(floor);
        }

        for (int i = 0; i < wallAmount; i++)
        {
            wall = WallPool.instance.GetWall();
            wall.SetActive(true);
            walls.Add(wall);
        }
        startPosition = startPos;
    }

    public void initValueMap(int wallAmount, int floorAmount, int coinAmount, Vector2 startPos)
    {
        walls = new List<GameObject>(wallAmount);
        floors = new List<GameObject>(floorAmount);
        isFloorHaveWall = new List<int>(floorAmount);
        isActive = true;

        GameObject wall;
        GameObject floor;
        for (int i = 0; i < wallAmount; i++)
        {
            wall = WallPool.instance.GetWall();
            wall.SetActive(true);
            walls.Add(wall);
        }
        for (int i = 0; i < floorAmount; i++)
        {
            isFloorHaveWall.Add(0);
            floor = FloorPool.instance.GetFloor();
            floor.transform.Translate(startPos.x, startPos.y + floorDistance*i, 1);
            floor.SetActive(true);
            floors.Add(floor);
        }
        //for (int i = 0; i < coinAmount; i++)
        //{
        //    coin = CoinPool.instance.GetCoin();
        //    coin.SetActive(true);
        //    coins.Add(coin);
        //}

        startPosition = startPos;
    }

    public Vector2 getNextStartPosition()
    {
        return new Vector2(startPosition.x, startPosition.y + 9f);
    }

    public float getFloorPosY(int n_th_floor)
    {
        return startPosition.y + ((n_th_floor - 1) * 0.9f);
    }

    public int randomInt(List<int> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public void clear()
    {
        if (floors.Count != 0)
        {
            isActive = false;

            foreach (GameObject floor in floors)
            {
                FloorPool.instance.ReturnFloor(floor);
            }

            foreach (GameObject wall in walls)
            {
                WallPool.instance.ReturnWall(wall);
            }
            foreach (GameObject coin in coins)
            {
                CoinPool.instance.ReturnCoin(coin);
            }
            coins.Clear();
            walls.Clear();
            floors.Clear();
        }
    }
}
