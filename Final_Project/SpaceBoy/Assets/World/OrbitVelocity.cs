using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitVelocity : MonoBehaviour
{
    public GameObject ParentWorld;
    [SerializeField] public float SemiMajor = 1000f;
    [SerializeField] float AngleOfMajorAxis = 0f;
    [SerializeField] public float SemiMinor = 1000f;
    [SerializeField] Vector3 VCounter;
    [SerializeField] float Eccentricity = 1f;
    [SerializeField] bool Retrograde = false;
    [SerializeField] public float OrbitIteration = 0;
    [SerializeField] float ResetValue;
    [SerializeField] public float Vela = .03f;
    [SerializeField] int AccelerationFactor = 1;
    [SerializeField] float GravVelocity;
    [SerializeField] Vector3 StartPos;
    [SerializeField] Vector3 EndPos;
    public Vector3 OrbitalVelocity;
    public float VelCap = 40f;
    Vector3 EllipseCenter;
    Vector3 Displacement;
    public Rigidbody CentralBody;
    public Gravity GravityWell;
    public float ConversionForce = 4000f;
    Rigidbody rb;
    float FociDist;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        GravityWell = ParentWorld.GetComponent<Gravity>();
        CentralBody = ParentWorld.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        FociDist = Mathf.Sqrt((SemiMajor * SemiMajor) - (SemiMinor * SemiMinor));
        Displacement = new Vector3(FociDist, 0f, 0f);
        Displacement = Quaternion.AngleAxis(AngleOfMajorAxis, Vector3.up) * Displacement;
        EllipseCenter = CentralBody.transform.position + Displacement;
        Debug.Log("Ellipse Center: " + EllipseCenter);
        Debug.Log("Parent Body: " + CentralBody);
        StartCoroutine(OrbitTime());
        
    }

    IEnumerator OrbitTime()
    {
        while (true)
        {
            for (int i = 0; i < AccelerationFactor; i++)
            {

                float ParentDist = Vector3.Distance(transform.position, ParentWorld.transform.position);
                GravVelocity = Mathf.Sqrt((GravityWell.ReturnGravConstant() * CentralBody.mass) / ParentDist);
                //float prefaction = Mathf.Pow(GravVelocity, -3 / 2);
                Vector3 CurrentPosition = new Vector3();
                CurrentPosition.x = SemiMajor * Mathf.Cos(  Mathf.Deg2Rad * OrbitIteration * Vela);
                CurrentPosition.z = SemiMinor * Mathf.Sin( Mathf.Deg2Rad * OrbitIteration * Vela);
                transform.position = ParentWorld.transform.position + CurrentPosition + Displacement;
                //Force it to be a circle
                
                if (Retrograde == true)
                {
                    OrbitIteration--;
                }
                else
                {
                    OrbitIteration++;
                }
            }
            yield return null;
        }
    }

    void FixedUpdate()
    {


    }
}
