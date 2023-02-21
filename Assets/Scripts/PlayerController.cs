using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject powerup_indicator;

    private GameObject focal_point;
    private Rigidbody player_rb;
    private bool has_powerup = false;
    private float powerup_strength = 10.0f;

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

        powerup_indicator.transform.position = transform.position + new Vector3(0.0f, -0.6f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            has_powerup = true;
            powerup_indicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (has_powerup && other.gameObject.CompareTag("Enemy"))
        {
            var enemy_rb = other.gameObject.GetComponent<Rigidbody>();
            var distance_from_player = other.gameObject.transform.position - transform.position;

            enemy_rb.AddForce(distance_from_player * powerup_strength, ForceMode.Impulse);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        has_powerup = false;
        powerup_indicator.gameObject.SetActive(false);
    }
}
