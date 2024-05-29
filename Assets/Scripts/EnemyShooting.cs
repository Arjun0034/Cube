using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyShooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject enemyBulletPrefab;

    [SerializeField] private float damage;

    private void Start()
    {
        InvokeRepeating("Projectile", 2.0f, 2.0f);
    }

    void Update()
    {
        
    }

    void Projectile()
    {
        var newInstans = Instantiate(enemyBulletPrefab, shootingPoint.position, transform.rotation);

        Destroy(newInstans, 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            
        }
    }
}
