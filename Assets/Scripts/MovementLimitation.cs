using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Update()
    {
        // var dist =(transform.position.y - Camera.main.transform.position.y);
    
        // var leftLimitation = Camera.main.ViewportToWorldPoint(Vector3(0,0,dist)).x;
        // var rightLimitation = Camera.main.ViewportToWorldPoint(Vector3(1,0,dist)).x;
    
        // var upLimitation = Camera.main.ViewportToWorldPoint(Vector3(0,0,dist)).z;
        // var downLimitation = Camera.main.ViewportToWorldPoint(Vector3(0,1,dist)).z;

        // transform.position.x = Mathf.Clamp(transform.position.x,rightLimitation,leftLimitation);
        // transform.position.z = Mathf.Clamp(transform.position.z,downLimitation,upLimitation);
    }
}
