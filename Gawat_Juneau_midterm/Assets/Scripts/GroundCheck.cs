using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "map")
        {
            player.GetComponent<PlayerController>().isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "map")
        {
            player.GetComponent<PlayerController>().isGrounded = false;
        }
    }
}
