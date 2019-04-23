using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;
    public GameObject trailfx;

    public KeyCode shootKey = KeyCode.C;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode leftKey = KeyCode.A;

    void Update()
    {
        if (Input.GetKey(rightKey))
        {
            transform.position += Vector3.right * moveSpeed;
        }

        if (Input.GetKey(leftKey))
        {
            transform.position += Vector3.left * moveSpeed;
        }

        if (Input.GetKey(upKey))
        {
            transform.position += Vector3.up * moveSpeed;
        }

        if (Input.GetKey(downKey))
        {
            transform.position += Vector3.down * moveSpeed;
        }
    }
}
