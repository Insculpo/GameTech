using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLook : MonoBehaviour
{
    Transform PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = FindObjectOfType<ControlShip>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 AimDirection = PlayerPos.position - transform.position;
        Quaternion RottingTurret = Quaternion.LookRotation(AimDirection);
        RottingTurret *= Quaternion.Euler(90f, 0f, 0f);
        transform.rotation = RottingTurret;
    }
}
