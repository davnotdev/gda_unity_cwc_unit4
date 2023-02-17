using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private GameObject focal_point;
    private Rigidbody player_rb;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
        focal_point = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        player_rb.AddForce(focal_point.transform.forward * speed * forward);
    }
}
