using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {  get; private set; }

    private Animator animator;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //player hurt
            animator.SetBool("Hurt", true);
            animator.SetBool("Idle", false);
        }

        if (currentHealth <= 0)
        {
            //player dead
            SceneManager.LoadScene("GameOver");
        }
    }
}
