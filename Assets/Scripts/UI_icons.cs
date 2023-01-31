using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_icons : MonoBehaviour
{

    public GameObject icon_bluepaint;
    public GameObject icon_redpaint;
    public GameObject icon_paintcan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        icon_bluepaint.SetActive(false);
        icon_paintcan.SetActive(false);
        icon_redpaint.SetActive(false);
        
        if (Inventory.has_spraycan)
        {
            icon_paintcan.SetActive(true);
        }
        if (Inventory.has_blue_paint)
        {
            icon_bluepaint.SetActive(true);
        }
        if (Inventory.has_red_paint)
        {
            icon_redpaint.SetActive(true);
        }

    }
}
