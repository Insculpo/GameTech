using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillSphere : MonoBehaviour
{
    [SerializeField] GameObject parentWorld;
    public float HillRadius;
    Rigidbody thisMass;
    Rigidbody parentMass;
    [SerializeField] bool IsSun = false;

    // Start is called before the first frame update
    void Start()
    {
        if (IsSun == false)
        {
            parentWorld = GetComponent<OrbitVelocity>().ParentWorld;
        }
        parentMass = parentWorld.GetComponent<Rigidbody>();
        thisMass = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        HillRadius = Vector3.Distance(parentWorld.transform.position, transform.position) * Mathf.Pow(thisMass.mass / (3f * parentMass.mass),( 1f / 3f));
    }

    private void OnDrawGizmos()
    {
        Color G = Color.green;
        G.a = 0.3f;
        Gizmos.color = G;
        Gizmos.DrawSphere(transform.position, HillRadius);
    }
}
