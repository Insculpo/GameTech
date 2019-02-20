using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookit : MonoBehaviour
{
    [SerializeField] Camera startCam;
    [SerializeField] List<Camera> allCam;
    bool startUP = true;
    int vk = 0;
    // Start is called before the first frame update
    void Start()
    {
        startCam = Camera.main;
        startCam.enabled = true;
        disableOtherCams();
    }

    void Update()
    {
        if (startUP == true)
        {
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            startCam.enabled = true;
            vk++;
        }
        if (vk < 100)
        {
            startUP = false;
        }


    }

    void disableOtherCams()
    {
        for (int i = 0; i < allCam.Count; i++)
        {
            allCam[i].enabled = false;
        }
    }
}
