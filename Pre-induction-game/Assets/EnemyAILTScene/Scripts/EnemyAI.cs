using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    // private CapsuleCollider2D cc;
    public int health = 100;
    public bool aggro;
    private Animator anim;
    //public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        // cc = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(behaviour());
    }

    private IEnumerator behaviour(){
        anim.SetBool("isAggro",false);
        int time = Random.Range(2,5);
        yield return new WaitForSeconds(time);
        anim.SetBool("isAggro",true);
        time = Random.Range(5,10);
        yield return new WaitForSeconds(time);
        StartCoroutine(behaviour());
    }

    void FixedUpdate(){
        aggro = anim.GetBool("isAggro");
        //healthText.text = health.ToString();
        if(health <= 0){
            anim.SetBool("isDefeated",true);
            Destroy(gameObject, 4f);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.tag == "PlayerAttack" && health > 0){
            health -= 10;
        }
    }
}
