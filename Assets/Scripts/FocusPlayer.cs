using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FocusPlayer : MonoBehaviour
{
    Vector3 camPos;
    Vector3 playerPos;
    public GameObject player;
    float minDistance = 2.5f;
    bool toLeft;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        camPos = transform.position;
        playerPos = player.transform.position;
        if (camPos.y - playerPos.y <= minDistance)
        {
            transform.Translate(0,minDistance-(camPos.y - playerPos.y),0);
        }

        if (MapGenerator.mapType == 3)//map 3
        {
            //camera focusX character
            transform.position = new Vector3(player.transform.position.x,transform.position.y,transform.position.z);
        }
        else//cac map khac
        {
            transform.position = new Vector3(MapGenerator.posXForCam, transform.position.y, transform.position.z);
        }
    }
}
