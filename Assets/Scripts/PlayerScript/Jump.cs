using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float forceAmount = 11f;
    Rigidbody2D player;
    bool isGrounded = true;
    bool direction;//true=right,left=false
    Vector2 a = new Vector2(5f, 0);
    [SerializeField]
    private AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        player.AddForce(new Vector2(5f, 0), ForceMode2D.Impulse);
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        player.rotation = 0f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
            if (isGrounded)
            {
                if (direction)
                {
                    player.velocity = a;
                }
                else
                {
                    player.velocity = -a;
                }
                player.AddForce(new Vector2(0, forceAmount), ForceMode2D.Impulse);
            }
                
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (direction)
            {
                player.AddForce(new Vector2(-5f, 0), ForceMode2D.Impulse);
                player.transform.Rotate(0, 180, 0);
                direction = false;
            }
            else
            {
                player.AddForce(new Vector2(5f, 0), ForceMode2D.Impulse);
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
