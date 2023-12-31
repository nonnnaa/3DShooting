using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Transform player;
    float time = 0f;
    public bool check = false;
    Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        if (time > 3f)
        {
            Destroy(gameObject);
        }   
        if ((player.position - transform.position).magnitude < 3f)
        {
            pos.x -= 0.1f;
            transform.position = pos;
            if (check == false)
            {
                check = true;
            }
        }
    }
}
