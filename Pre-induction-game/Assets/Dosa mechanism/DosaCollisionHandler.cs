using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DosaCollisionHandler : MonoBehaviour
{
    private DosaThrower dosaThrower;

    public void Initialize(DosaThrower thrower)
    {
        dosaThrower = thrower;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            // Destroy the dosa when it touches the ground.
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            // Check if dosaThrower is not null before calling the method.
            if (dosaThrower != null)
            {
                // If the dosa touches the player, increment a counter and destroy the dosa.
                dosaThrower.PlayerTouchedDosa();
            }

            // Destroy the dosa.
            Destroy(gameObject);
        }
    }
}
