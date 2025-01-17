using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmpMovement : MonoBehaviour
{
    /*input for enemy speed, deadZone = enemy deleted when achieve deadzone horizontally*/
    public float moveSpeed = 10;
    public float deadZone = 25;
    void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
    if (transform.position.x > deadZone)
    {
        Debug.Log("Pipe Deleted");
        Destroy(gameObject);
    }
    }

}
