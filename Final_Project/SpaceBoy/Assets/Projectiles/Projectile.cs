using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float LifeSpan = 1000f;
    public float Damage = 10f;
    public float Faction = 0f;
    public float LaD = 0f;
    [SerializeField] bool IsLaser = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void CountDown()
    {
        if (LifeSpan <= 0 && IsLaser == false)
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject);

        }
        LifeSpan--;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "World")
        {
            Destroy(gameObject);
        }
        HealthSystem TargetHP = collision.gameObject.GetComponent<HealthSystem>();
        if (collision.gameObject.GetComponent<HealthSystem>() != null)
        { 
            if (TargetHP.faction == Faction)
            {
                Debug.Log("Same faction! " + TargetHP.faction);
                return;

            }
            else
            {
                collision.gameObject.GetComponent<HealthSystem>().HurtMe(Damage);
                if (IsLaser == false)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void LaunchDir(float LD)
    {
        LaD = LD;
    }

}
