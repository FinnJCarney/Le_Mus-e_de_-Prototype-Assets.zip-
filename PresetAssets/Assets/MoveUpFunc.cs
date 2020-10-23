using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpFunc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.up * 0.005f;
    }
}
