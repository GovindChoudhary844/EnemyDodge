using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int minSpeed;
    [SerializeField] private int maxSpeed;

    [SerializeField] private int damage;
    [SerializeField] private GameObject ExplosionParticle;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.instance.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
        }

        if (collision.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
        }
    }
}
