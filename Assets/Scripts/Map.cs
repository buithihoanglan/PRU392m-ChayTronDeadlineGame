using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public bool isActive;
    public Vector2 startPosition;
    public List<GameObject> walls;
    public List<GameObject> floors;
    public List<GameObject> coins;
    public static float floorDistance = 0.9f;// = wall.scaleY + floor.scaleY

    public Map() { }
    public void initValueMap(int wallAmount, int coinAmount, Vector2 startPos)
    {
        walls = new List<GameObject>(wallAmount);
        floors = new List<GameObject>(10);
        isActive = true;

        GameObject wall;
        GameObject floor;
        for (int i = 0; i < wallAmount; i++)
        {
            wall = WallPool.instance.GetWall();
            wall.SetActive(true);
            walls.Add(wall);
        }
        for (int i = 0; i < 10; i++)
        {
            floor = WallPool.instance.GetWall();
            floor.SetActive(true);
            floors.Add(floor);
        }

        startPosition = startPos;
    }

    public void initValueMap(int wallAmount, int floorAmount, int coinAmount, Vector2 startPos)
    {
        walls = new List<GameObject>(wallAmount);
        floors = new List<GameObject>(floorAmount);
        isActive = true;

        GameObject wall;
        GameObject floor;
        GameObject coin;
        for (int i = 0; i < wallAmount; i++)
        {
            wall = WallPool.instance.GetWall();
            wall.SetActive(true);
            walls.Add(wall);
        }
        for (int i = 0; i < floorAmount; i++)
        {
            floor = WallPool.instance.GetWall();
            floor.SetActive(true);
            floors.Add(floor);
        }
        for (int i = 0; i < coinAmount; i++)
        {
            coin = CoinPool.instance.GetCoin();
            coin.SetActive(true);
            coins.Add(coin);
        }

        startPosition = startPos;
    }

    public Vector2 getNextStartPosition()
    {
        return new Vector2(startPosition.x, startPosition.y + 9f);
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
