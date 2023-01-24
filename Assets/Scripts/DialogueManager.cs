using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class DialogueManager : MonoBehaviour
{
    public Text NPCName;
    public Text DialogueText;
    public GameObject dialoguePanel;
    public bool coversation = false;

    public Queue<string> sentences;
    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)

    {
        coversation = true;

        dialoguePanel.SetActive(true);

        Debug.Log("Starting coverssation with " + dialogue.name);

        NPCName.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();


    }  
     public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue(); 
         
            return;
        }

        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;
    }

    void EndDialogue()
    {
        coversation = false;

        dialoguePanel.SetActive(false);

        Debug.Log("End of conversation");
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            //    dialoguePanel.SetActive(true);
            DisplayNextSentence();
        }
    }

}
