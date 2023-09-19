using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testdialouge : MonoBehaviour
{
    public Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(1f);
        DialogueManager.instance.StartDialogue(dialogue);

    }
}
