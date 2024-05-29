using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private PlayerMovement player;
    public int availableShots = 0;
    public TextMeshProUGUI shotText;


    private void Start()
    {
        // Get reference to the PlayerMovement script attached to the player
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Keyboard.current.ctrlKey.wasPressedThisFrame && availableShots > 0) 
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (availableShots > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);

            // Get the bullet's Rigidbody2D component
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

            // If the player is facing left, rotate the bullet 180 degrees
            if (!player.isFacingRight)
            {
                bulletRB.transform.Rotate(0f, 0f, 180f);
            }

            availableShots--; // Decrement shots only after firing

            if (shotText != null) // Update UI text if available
            {
                shotText.text = availableShots.ToString();
            }
        }
        
    }

}