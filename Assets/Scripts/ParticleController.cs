using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ParticleController : MonoBehaviour
{
    [Header("Movement Particle")]
    [SerializeField] ParticleSystem movementParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;
    [SerializeField] Rigidbody2D playerRb;


    float counter;

    [SerializeField] public Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private void Start()
    {
        
    }

    void Update()
    {
        
        counter += Time.deltaTime;

        if (Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity  && IsOnGround())
        {           
                if (counter > dustFormationPeriod)
                {
                    movementParticle.Play();
                    counter = 0;
                }
        }
    }

    

    bool IsOnGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

}
