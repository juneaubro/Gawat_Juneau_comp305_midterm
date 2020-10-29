using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowMoveSpeed = 0.01f;
    public bool moved = false;
    private Vector3 targetPos;

    public Vector2 minPos;
    public Vector2 maxPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position.y < (maxPos.y-0.05f) && moved == false)
        {
            Vector3 targetPos = new Vector3(transform.position.x,maxPos.y,transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, arrowMoveSpeed);

        } else
        {
            moved = true;
        }

        if (transform.position.y > (minPos.y+0.05f) && moved == true)
        {
            Vector3 targetPos = new Vector3(transform.position.x, minPos.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, arrowMoveSpeed);
        }
        else
        {
            moved = false;
        }

    }
}
