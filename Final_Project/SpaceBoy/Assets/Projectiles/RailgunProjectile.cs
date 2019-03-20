using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunProjectile : Projectile
{
    public GameObject LauncherOrientation;
    public float RailgunForce = 100f;
    float timer = 0f;
    Transform PlayerTransform;
    // Start is called before the first frame update
    void Awake()
    {
        Quaternion Rot = Quaternion.AngleAxis(LaD, Vector3.up) * LauncherOrientation.transform.rotation;
        Vector3 LaDi = Rot * -LauncherOrientation.transform.forward;
        if (Faction == 0f)
        {
            GetComponent<Rigidbody>().velocity += (LaDi * RailgunForce) + FindObjectOfType<ControlShip>().gameObject.GetComponent<Rigidbody>().velocity;
        }
        if (Faction == 1f)
        {
            GetComponent<Rigidbody>().velocity += (LaDi * RailgunForce) + LauncherOrientation.GetComponentInParent<Rigidbody>().velocity;
        }
    }

    public void LaunchDir(float LD)
    {
        LaD = LD;
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }
 
}
