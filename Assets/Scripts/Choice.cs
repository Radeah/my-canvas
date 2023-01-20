using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public int ChoiceMade;

    public void ChoiceOption1() {
        TextBox.GetComponent<Text>().text "Here you go";
        ChoiceMade = 1;
    }

    public void ChoiceOption()
    {
        TextBox.GetComponent<Text>().text "Here you gogbuiuoubhuij0ji]]jip";
        ChoiceMade = 2;

    }

    void Update() 
        if (ChoiceMade) >= 1 
        {
        
        
        }

    
}
