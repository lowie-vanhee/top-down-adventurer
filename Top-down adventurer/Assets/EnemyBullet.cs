using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 38f;
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
            Destroy(gameObject);

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.GetComponent<CharacterHealthAndStamina>().removeHealth(damage);
        }
    }
}
