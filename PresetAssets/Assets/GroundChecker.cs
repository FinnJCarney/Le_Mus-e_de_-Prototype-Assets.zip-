using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    PlayerManager pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponentInParent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag != "Player")
        {
            pm.OnGround();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag != "Player")
        {
            pm.OffGround();
        }
    }
}
