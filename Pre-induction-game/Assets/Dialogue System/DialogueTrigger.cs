using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public static DialogueTrigger instance;

    public void TriggerDialogue()
    {
        Debug.Log("heyy");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);


    }
    void Start()
    {
        instance = this;
    }
    
}
