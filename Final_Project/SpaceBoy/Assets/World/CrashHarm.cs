using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashHarm : MonoBehaviour
{
    public Rigidbody CentralObj;
    public float ColDmg = 1f;
    // Start is called before the first frame update
    void Start()
    {
        CentralObj = transform.GetComponentInParent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        HealthSystem Harm = collision.gameObject.GetComponent<HealthSystem>();
        Rigidbody ColliderMomentum = collision.gameObject.GetComponentInParent<Rigidbody>();
        if (Harm != null)
        {
            Debug.Log("Collision Detected...");
            float MomentumSmash = (ColliderMomentum.mass * Vector3.Magnitude(ColliderMomentum.velocity) + CentralObj.mass * Vector3.Magnitude(CentralObj.velocity)) / (CentralObj.mass + ColliderMomentum.mass);
            float HarmGo = ColDmg * MomentumSmash;
            Harm.HurtMe(HarmGo);
        }
    }
}
