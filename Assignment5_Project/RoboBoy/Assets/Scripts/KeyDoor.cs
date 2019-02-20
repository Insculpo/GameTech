using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] float KeyAddress;
    [SerializeField] GameObject player;
    [SerializeField] GameObject door;
    [SerializeField] float OpenRate;
    [SerializeField] float raiseHeight;
    [SerializeField] bool Ambusher = false;
    Controller conts;
    Animator WarpDoor;
    float initialHeight;
    bool doorOpen = false;
    bool OpenTime;
    float TimerOpening = 0f;
    // Start is called before the first frame update
    void Start()
    {
        initialHeight = door.transform.position.y;
        WarpDoor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doorOpen == true)
        {
            TimerOpening++;
        }
        if (doorOpen == true && OpenTime == false)
        {
            WarpDoor.Play("OpenUp");
            OpenTime = true;
        }
        if(TimerOpening > 55f)
        {
            Destroy(gameObject);
        }
    }

    public void CheckAddress(float keyChecker)
    {
        if (keyChecker == KeyAddress)
        {
            doorOpen = true;
        }
    }
}

    