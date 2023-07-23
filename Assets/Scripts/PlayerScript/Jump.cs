using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public static float forceAmount = 11f;
    Rigidbody2D player;
    public static bool isGrounded = true;
    public static bool direction;//true=right,left=false
    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        direction = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (direction)
            {
                player.AddForce(new Vector2(-3f, 0), ForceMode2D.Impulse);
                player.transform.Rotate(0, 180, 0);
                direction = false;
            }
            else
            {
                player.AddForce(new Vector2(3f, 0), ForceMode2D.Impulse);
                player.transform.Rotate(0, 180, 0);
                direction = true;
            }
        }else if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
