using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool aggro;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
