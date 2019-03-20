using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustBurn : MonoBehaviour
{
    [SerializeField] float ThrustHarm = 1f;
    [SerializeField] float Faction = 0f;
    SpriteRenderer isEnabled;
    // Start is called before the first frame update
    void Start()
    {
        isEnabled = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        HealthSystem BurnMe = other.gameObject.GetComponent<HealthSystem>();
        if(BurnMe == null)
        {
            return;
        }
        if(isEnabled.enabled == true)
        {
            if(BurnMe.faction != Faction)
            {
                BurnMe.Health -= ThrustHarm;
            }
        }
    }
}
