using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator self;
    private Animator prof;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Animator>();
        prof = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(prof != null){
            if(prof.GetBool("isDefeated")){
                self.SetBool("isDefeated", true);
            }
        }
    }
}
