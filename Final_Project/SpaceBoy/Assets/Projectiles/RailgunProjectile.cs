using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunProjectile : Projectile
{
    public GameObject LauncherOrientation;
    public float RailgunForce = 100f;
    float timer = 0f;
    public float LaD = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        Quaternion Rot = Quaternion.AngleAxis(LaD, Vector3.up) * LauncherOrientation.transform.rotation;
        Vector3 LaDi = Rot * -LauncherOrientation.transform.forward;
        GetComponent<Rigidbody>().velocity += (LaDi * RailgunForce);
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

    private void OnTriggerEnter(Collider collision)
    {
        if (Faction == 0f)
        {
            if (collision.gameObject.GetComponent<HealthSystem>() != null && collision.gameObject.tag != "Player")
            {
                Debug.Log("A Collided with " + collision.gameObject.name);
                collision.gameObject.GetComponent<HealthSystem>().HurtMe(Damage);
                Destroy(gameObject);
                return;
            }
        }
        if (Faction == 1f)
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<HealthSystem>() != null)
            {
                collision.gameObject.GetComponent<HealthSystem>().HurtMe(Damage);
                Destroy(gameObject);
                return;
            }
            if (collision.gameObject.tag != "Defense")
            {
                Destroy(gameObject);
                return;
            }
        }

    }
}
