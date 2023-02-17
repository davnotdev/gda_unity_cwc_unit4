using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotation_speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotation_speed * horizontal_input * Time.deltaTime);
    }
}
