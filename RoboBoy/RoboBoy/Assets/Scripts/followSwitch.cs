using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followSwitch : MonoBehaviour
{
    [SerializeField] LookCam PrimeCam;
    [SerializeField] LookCam SecundCam;
    int OneEnter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if (OneEnter == 0 && other.tag == "Player")
        {
            PrimeCam.FlipOff();
            SecundCam.FlipOn();
            OneEnter = 1;
            return;
        }
        if(OneEnter == 1 && other.tag == "Player")
        {
            PrimeCam.FlipOn();
            SecundCam.FlipOff();
            OneEnter = 0;
            return;
        }
    }
}
