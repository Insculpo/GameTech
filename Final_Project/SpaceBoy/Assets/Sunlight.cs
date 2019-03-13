using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunlight : MonoBehaviour
{
    Transform sun;
    // Start is called before the first frame update
    void Start()
    {
        sun = FindObjectOfType<SolarHarm>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 AimDirection = sun.transform.position - transform.position;
        Quaternion RottingTurret = Quaternion.LookRotation(AimDirection);
        RottingTurret *= Quaternion.Euler(90f, 0f, 240f);
        transform.rotation = RottingTurret;
    }
}
