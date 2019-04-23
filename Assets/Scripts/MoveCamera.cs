using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public float moveSpeed;

    void Update()
    {
        transform.position += Vector3.right * moveSpeed;
    }
}
