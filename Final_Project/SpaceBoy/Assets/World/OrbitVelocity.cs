using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitVelocity : MonoBehaviour
{
    public GameObject ParentWorld;
    [SerializeField] float AphelionDistance;
    [SerializeField] Vector3 VCounter;
    [SerializeField] float Eccentricity = 1f;
    [SerializeField] bool Retrograde = false;
    public Vector3 OrbitalVelocity;
    public Rigidbody CentralBody;
    public Gravity GravityWell;
    public float ConversionForce = 4000f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        GravityWell = ParentWorld.GetComponent<Gravity>();
        CentralBody = ParentWorld.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        float GravVelocity = Mathf.Sqrt((GravityWell.ReturnGravConstant() * CentralBody.mass) / transform.position.magnitude );
        OrbitalVelocity = new Vector3(GravVelocity,0, 0);
        if (Retrograde == true)
        {
            rb.velocity += OrbitalVelocity * Eccentricity;

        }
        else
        {
            rb.velocity += OrbitalVelocity * Eccentricity;
        }
    }

            void FixedUpdate()
    {
       VCounter = rb.velocity;
    }
}
