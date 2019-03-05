using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public float Density = 4f;
    public Vector2 WorldCoordinates;
    float Radius;
    float V;
    Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        Radius = transform.localScale.x;
        V = 2f * Mathf.PI * Mathf.Pow(Radius, 2f);
        RB = GetComponent<Rigidbody>();
        RB.mass = V * Density;

    }

    // Update is called once per frame
    void Update()
    {
        WorldCoordinates.x = transform.position.x;
        WorldCoordinates.y = transform.position.z;
    }
    
}
