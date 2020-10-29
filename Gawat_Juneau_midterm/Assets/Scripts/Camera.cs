using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float cameraSmoothing = 0.03f;
    public Vector2 minPos;
    public Vector2 maxPos;

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(target.position.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, cameraSmoothing);
        }
    }
}
