using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");

    }

    // Update is called once per frame
    void Update()
    {
        control();
    }
    void control()
    {
        if (Input.GetKey("a"))
        {
            player.GetComponent<Animator>().Play("walk");
        }
        if (Input.GetKey("s"))
        {
            player.GetComponent<Animator>().Play("walk");
        }
        if (Input.GetKey("d"))
        {
            player.GetComponent<Animator>().Play("walk");
        }
    }
}
