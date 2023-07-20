using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPool : MonoBehaviour
{
    public GameObject floorPrefab;
    public int poolSize = 50;
    List<GameObject> floors = new List<GameObject>();

    public static FloorPool instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject floor = Instantiate(floorPrefab);
            floor.SetActive(false);
            floors.Add(floor);
        }
    }

    public GameObject GetFloor()
    {
        for (int i = 0; i < floors.Count; i++)
        {
            if (!floors[i].activeInHierarchy)
            {
                return floors[i];
            }
        }
        return null;
    }

    public void ReturnFloor(GameObject floor)
    {
        floor.SetActive(false);
    }
}
