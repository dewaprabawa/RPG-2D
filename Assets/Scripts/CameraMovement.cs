using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float smoothing;
   
    public Vector2 maxPosition;
    public Vector2 minPosition;

    void LateUpdate()
    {
        if(transform.position != target.position){
            Vector3 targetPosition = new Vector3(target.position.x,target.position.y,transform.position.z);

            targetPosition.x = Mathf.Clamp(target.position.x, minPosition.x,maxPosition.x);

            targetPosition.y = Mathf.Clamp(target.position.y,minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position,targetPosition,smoothing);
        }
    }
}
