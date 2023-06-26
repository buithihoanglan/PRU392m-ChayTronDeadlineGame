using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    //bool direction;//true=right,left=false
    //Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<Rigidbody2D>();
        //direction = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Wall")
    //    {
    //        if (direction)
    //        {
    //            player.AddForce(new Vector2(-5f, 0), ForceMode2D.Impulse);
    //            direction = false;
    //        }
    //        else
    //        {
    //            player.AddForce(new Vector2(5f, 0), ForceMode2D.Impulse);
    //            direction = true;
    //        }
    //    }
    //}
}
