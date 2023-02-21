using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemy_rb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemy_rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 normalized_move_direction = (player.transform.position - transform.position).normalized;
        enemy_rb.AddForce(normalized_move_direction * speed);

        if (transform.position.y < -10) {
            Destroy(gameObject);
        }
    }
}
