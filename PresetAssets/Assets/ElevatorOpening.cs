using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpening : MonoBehaviour
{
    public GameObject player;
    
    public int waitLimit;
    Vector3 ogPos;
    public Vector3 endPos;
    bool active;
    void Start()
    {
        waitLimit = GameManager.me.timer + waitLimit;
        ogPos = transform.position;
        player.transform.parent = this.transform;
        active = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            Debug.Log("Active");
            if (GameManager.me.timer > waitLimit)
            {
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, endPos.x, 0.004f), Mathf.Lerp(transform.position.y, endPos.y, 0.004f), Mathf.Lerp(transform.position.z, endPos.z, 0.004f));
                Debug.Log("lerping");
            }

            if (Vector3.Distance(transform.position, endPos) < 0.05f)
            {
                Debug.Log("Arrived");
                player.transform.parent = null;
                player.GetComponent<PlayerManager>().Activate();
                active = false;
            }
        }
    }
}
