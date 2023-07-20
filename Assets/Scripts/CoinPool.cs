using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    public GameObject coinPrefab;
    public int poolSize = 20;
    List<GameObject> coins = new List<GameObject>();

    public static CoinPool instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(false);
            coins.Add(coin);
        }
    }

    public GameObject GetCoin()
    {
        for (int i = 0; i < coins.Count; i++)
        {
            if (!coins[i].activeInHierarchy)
            {
                return coins[i];
            }
        }
        return null;
    }

    public void ReturnCoin(GameObject coin)
    {
        coin.SetActive(false);
    }
}
