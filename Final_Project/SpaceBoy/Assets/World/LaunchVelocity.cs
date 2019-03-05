using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchVelocity : MonoBehaviour
{
    [SerializeField] GameObject LittleStroid;
    [SerializeField] float ImpactForce = 5000f;
    [SerializeField] float MinStroid = 3;
    [SerializeField] float MaxStroid = 5;
    float ChildrenCount;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        float ChildrenCount = Random.Range(MinStroid, MaxStroid);
        Debug.Log(ChildrenCount);
        if(LittleStroid.GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("Error: Rigidbody is required!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 10f)
        {
            Splode();
            timer = 0f;
            //Destroy(this);
        }
        timer++;
    }

    void Splode()
    {
        GameObject LStroid;
        Rigidbody ARB;
        float RandomX;
        float RandomZ;
        for (int a = 0; a <= ChildrenCount; a++)
        {
            LStroid = LittleStroid;
            ARB = LStroid.GetComponent<Rigidbody>();
            RandomX = (Random.Range(-100f, 100f) / ARB.mass) * ImpactForce;
            RandomZ = (Random.Range(-100f, 100f) / ARB.mass) * ImpactForce;
            LStroid.GetComponent<Transform>().Rotate(0, Random.Range(0, 360), 0);
            LStroid.GetComponent<Rigidbody>().AddForce(RandomX,RandomZ, RandomZ);
            Instantiate(LStroid,transform);
        }
    }
}
