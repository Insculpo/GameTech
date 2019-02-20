using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float thresholdScore;
    [SerializeField] GameObject player;
    [SerializeField] GameObject door;
    [SerializeField] float OpenRate;
    Controller conts;
    // Start is called before the first frame update
    void Start()
    {
        conts = player.GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        conts = player.GetComponent<Controller>();
        if (thresholdScore <= conts.score)
        {
            door.transform.Translate(0, OpenRate, 0);
        }
        if(door.transform.position.y > 13f)
        {
            door.transform.Translate(0, 0, 0);
        }
    }

    
}
