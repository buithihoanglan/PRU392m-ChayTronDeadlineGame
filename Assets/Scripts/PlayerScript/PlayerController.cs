using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position.y - transform.position.y > 7f)
        {
            //hien len pop up la game over

            //bam ok tro ve man hinh home

        }
    }
}
