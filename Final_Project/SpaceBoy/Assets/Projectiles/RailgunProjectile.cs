using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunProjectile : MonoBehaviour
{
    public GameObject LauncherOrientation;
    public float RailgunForce = 100f;
    public float LifeSpan = 1000f;
    public float Damage = 10f;
    public float Faction = 0f;

    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity += transform.TransformDirection(LauncherOrientation.transform.forward) * RailgunForce * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(LifeSpan < timer)
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(this);

        }
        timer++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Faction == 0f)
        {
            if (collision.gameObject.GetComponent<HealthSystem>() != null && collision.gameObject.tag != "Player")
            {
                collision.gameObject.GetComponent<HealthSystem>().HurtMe(Damage);
                Destroy(gameObject);
                return;
            }
            if (collision.gameObject.tag != "Player")
            {
                Destroy(gameObject);
            }
        }
        if (Faction == 1f)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<HealthSystem>().HurtMe(Damage);
                Destroy(gameObject);
                return;
            }
            if (collision.gameObject.tag != "Defense")
            {
                Destroy(gameObject);
            }
        }

    }
}
