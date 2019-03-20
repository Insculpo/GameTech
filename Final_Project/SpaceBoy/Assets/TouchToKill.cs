using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToKill : MonoBehaviour
{
    [SerializeField] LaserProjector LP;
    bool CanKill = false;
    float harmRate;
    float faction;
    // Start is called before the first frame update
    void Start()
    {
        faction = LP.Faction;
        harmRate = LP.Damage;
    }

    public void Activate()
    {
        CanKill = true;
    }

    public void Deactivate()
    {
        CanKill = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<HealthSystem>() != null && CanKill == true && other.gameObject.GetComponent<HealthSystem>().faction != faction)
        {
            other.gameObject.GetComponent<HealthSystem>().Health -= harmRate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
