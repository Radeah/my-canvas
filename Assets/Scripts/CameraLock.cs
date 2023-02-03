using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{

    public Transform myself;
    public Transform boundary;
    public Transform player;
    public Vector3 offset;

    public Vector3 boundary_position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x <= boundary.position.x)
        {
            boundary_position = player.position;
            boundary_position.x = boundary.position.x;
        } else
        {
            boundary_position = player.position + offset;
        }
        myself.position = boundary_position;
    }
}
