using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPool : MonoBehaviour
{
    public GameObject wallPrefab;
    public int poolSize = 70;
    List<GameObject> walls = new List<GameObject>();

    public static WallPool instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject wall = Instantiate(wallPrefab);
            wall.SetActive(false);
            walls.Add(wall);
        }
    }

    public GameObject GetWall()
    {
        for (int i = 0; i < walls.Count; i++)
        {
            if (!walls[i].activeInHierarchy)
            {
                return walls[i];
            }
        }
        return null;
    }

    public void ReturnWall(GameObject wall)
    {
        wall.SetActive(false);
    }
}
