using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallaxing : MonoBehaviour
{
   GameObject player;
   Renderer rend;

   public float speed = 0.5f;
   float playerStartPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rend = GetComponent<Renderer>();
        playerStartPos = player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = (player.transform.position.x - playerStartPos) * speed;

        rend.material.SetTextureOffset("_MainTex", new Vector2 (offset, 0f));
    }
}
