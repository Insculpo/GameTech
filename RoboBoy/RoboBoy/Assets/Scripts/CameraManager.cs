using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] List<Camera> CameraCatalog;
    [SerializeField] List<followSwitch> Triggerers;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public Camera GetCam(int i)
    {
        return CameraCatalog[i];
    }

    public followSwitch GetSwitch(int i)
    {
        return Triggerers[i];
    }
}
