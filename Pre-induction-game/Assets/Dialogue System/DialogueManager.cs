using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Queue<string> sentences;
    public static DialogueManager instance;
    public Image imageToToggle;
    

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        instance = this;
    }
   

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
       

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation.");
        freezer.instance.UnfreezeScene();
        imageToToggle.gameObject.SetActive(false);
        pausemenu.instance.canbepaued = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (sentences.Count >0)
            {
                DisplayNextSentence();
            }
            if (sentences.Count == 0)
            {
                EndDialogue();

            }
        }
        
    }
}
