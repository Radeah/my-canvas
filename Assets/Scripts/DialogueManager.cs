using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class DialogueManager : MonoBehaviour
{
    public Text NPCName;
    public Text DialogueText;
    public GameObject dialoguePanel;
    public GameObject[] multiChoices;
    public bool coversation = false;

    public Dialogue multiChoice0Option1;
    public Dialogue multiChoice0Option2;
    public Dialogue multiChoice1Option1;
    public Dialogue multiChoice1Option2;


    public Queue<string> sentences;

    public string item_to_give;

    void Start() {
        sentences = new Queue<string>();

        Debug.Log(multiChoices[0]);
    }

    public void StartDialogue (Dialogue dialogue, string chosen_item)
    {
        if (chosen_item != "na")
        {
            item_to_give = chosen_item;
        }

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

        if (sentence.Contains("MULTICHOICE0"))
        {
            sentences.Clear();
            dialoguePanel.SetActive(false);
            multiChoices[0].SetActive(true);
        }
        if (sentence.Contains("MULTICHOICE1"))
        {
            sentences.Clear();
            dialoguePanel.SetActive(false);
            multiChoices[1].SetActive(true);
        }
        else
        {
            DialogueText.text = sentence; 
        }
        
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
            DisplayNextSentence();
        }
    }

    public void MultiChoice0Option1()
    {
        multiChoices[1].SetActive(false);
        if (item_to_give == "paint") { Inventory.has_blue_paint = true; }
        StartDialogue(multiChoice0Option1, "na");
    }

    public void MultiChoice0Option2()
    {
        multiChoices[1].SetActive(false);
        if (item_to_give == "paint") { Inventory.has_red_paint = true; }
        StartDialogue(multiChoice0Option2, "na");
    }

    public void MultiChoice1Option1()
    {
        multiChoices[0].SetActive(false);
        if (item_to_give == "spraycan") { Inventory.has_spraycan = true; }
        StartDialogue(multiChoice1Option1, "na");
    }

    public void MultiChoice1Option2()
    {
        multiChoices[0].SetActive(false);
        StartDialogue(multiChoice1Option2, "na");
    }

}
