using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float time;
    void Update()
    {
        time += Time.deltaTime;
        if(time > 5f)
        {
            time = 0;
            Destroy(gameObject);
        }
    }
}
