using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaCube : CubeFollow
{
    public KeyDoor BossDoor;
    bool Dead = false;
    float DeadTime = 0;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        StateMe.SetFloat("BossHP", CubeHP);
      
        if (CubeHP > 200)
        {
            KILL.acceleration = 1;
            KILL.angularSpeed = 2;
            KILL.speed = 10;
        }
        if(CubeHP <= 200 && CubeHP > 100)
        {
            KILL.acceleration = 2;
            KILL.angularSpeed = 4;
            KILL.speed = 20;
        }
        if (CubeHP <= 100 && CubeHP > 0)
        {
            KILL.acceleration = 4;
            KILL.angularSpeed = 8;
            KILL.speed = 30;
        }
        if (CubeHP <= 0)
        {
            OpenDoor();
        }
        

    }

    void OpenDoor()
    {
        BossDoor.CheckAddress(1);
    }
}
