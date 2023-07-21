using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawn : MonoBehaviour
{
    public Transform player;
    public float currentDis = 0;
    public float maxDis = 6.4f;
    public float respawnDis = 12f;
    private void FixedUpdate()
    {
        this.getDistance();
        this.Spawn();
    }

    private void Spawn()
    {
        if(this.currentDis < this.maxDis)
        {
            return;
        }
        Vector3 pos = transform.position;
        pos.y = this.respawnDis;
        transform.position = pos;

        respawnDis += 10;
    }

    protected virtual void getDistance()
    {
        this.currentDis = this.player.position.y - transform.position.y;
    }
}
