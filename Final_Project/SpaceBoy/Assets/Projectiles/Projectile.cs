using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float LifeSpan = 1000f;
    public float Damage = 10f;
    public float Faction = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void CountDown()
    {
        if (LifeSpan <= 0)
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject);

        }
        LifeSpan--;
    }
}
