using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public Rigidbody centralMass;
    public float GravConstant = 0.4f;
    public float PublicForce;
    // Start is called before the first frame update
    void Start()
    {
        centralMass = GetComponent<Rigidbody>();
        Gravity[] attractors = FindObjectsOfType<Gravity>();
        //For the sake of convenience.
        foreach (Gravity Grav in attractors) { 
                Grav.GravConstant = GravConstant;
        }
    }

    void FixedUpdate()
    {
        Gravity[] attractors = FindObjectsOfType<Gravity>(); 
        foreach (Gravity Grav in attractors)
        {
            if (Grav != this && Grav.gameObject.tag != "World")
            {
                Attract(Grav);
            }
            
        }
    }

    // Update is called once per frame
    void Attract(Gravity friend)
    {
        Rigidbody targetBody = friend.centralMass;

        Vector3 Dir = centralMass.position - targetBody.position;
        float Dist = Dir.magnitude;

        float N = GravConstant * (centralMass.mass * targetBody.mass) / Mathf.Pow(Dist, 2);
        Vector3 force = Dir.normalized * N;
        //Makes the gravitational force public
        PublicForce = N;
        //Enforces the 2D nature of the simulation
        force.y = 0;

        targetBody.AddForce(force);

    }

    public float GetForce()
    {
        return PublicForce;
    }
    
    public float ReturnGravConstant()
    {
        return GravConstant;
    }
}
