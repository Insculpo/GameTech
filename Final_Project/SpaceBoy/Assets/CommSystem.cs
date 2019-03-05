using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommSystem : MonoBehaviour
{
    Transform localPos;
    LineRenderer CommRender;
    Collider commTrig;
    public float commRespawn = 1000f;
    float CommDelay = 0;
    [SerializeField] bool ActivatedComm = false;
    [SerializeField] float waveRate = 0.2f;
    [SerializeField] SphereCollider CommSphere;
    // Start is called before the first frame update
    void Start()
    {
        CommRender = new LineRenderer();
        commTrig = CommSphere;
        CommRender.material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C) && CommDelay < commRespawn)
        {
            CommDelay = 0;
            ActivatedComm = true;
        }
        if(ActivatedComm == true)
        {
            Shout();
            CommDelay++;
        }
        if(CommDelay >= commRespawn)
        {
            KillComm();
            ActivatedComm = false;
        }
    }

    void Shout()
    {

        commTrig.bounds.Expand(waveRate);
        DrawCommCircle();
    }

    void DrawCommCircle()
    {
        int segments = 360;
        CommRender.useWorldSpace = false;
        CommRender.startWidth = 0.1f;
        CommRender.positionCount = segments + 1;
        int Points = segments + 1;
        Vector3[] SetPoints = new Vector3[Points];
    }

    void KillComm()
    {
        commTrig.bounds.size.Set(0, 0, 0);
    }
}
