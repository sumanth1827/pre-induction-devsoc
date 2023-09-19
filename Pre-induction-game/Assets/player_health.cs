using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microlight.MicroBar;
using UnityEngine.WSA;

public class player_health : MonoBehaviour
{
    [SerializeField] MicroBar healthbar;
    public float health = 100f;
    public static player_health instance;
    Animator anim;
    [SerializeField] Animator canvasanim;
    // Start is called before the first frame update
    private void Awake()
    {

        healthbar = GetComponentsInChildren<MicroBar>()[1];
        healthbar.Initialize(100f);
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            healthbar.UpdateHealthBar(health, true);
        }
        else if (health <= 0)
        {
            anim.SetBool("death", true);
            playermovement.instance.alive = false;

        }

    }
    public void decreasehealth(float amount)
    {
        health -= amount;

    }
    public void canvasanimation()
    {
        canvasanim.SetBool("gameover", true);
        anim.SetBool("death", false);
    }
}
