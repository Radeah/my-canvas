using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Background : MonoBehaviour
{
    public GameObject city;
    public GameObject skatePark;
    public GameObject train;

    public int street; 

    public void Switch(int switch_to) 
    {
        street = switch_to;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        city.SetActive(false);
        skatePark.SetActive(false);
        train.SetActive(false);

        if (street == 1)
        {
            city.SetActive(true);
        }

        if (street == 2)
        {
            skatePark.SetActive(true);
        }

        if (street == 3)
        {
           train.SetActive(true);
           train.SetActive(true);
        }





    }
}
