using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    [SerializeField] PlasmaKill BurnBaby;
    // Start is called before the first frame update
    public void FirePlasma(float damage, float FireSpeed)
    {
                BurnBaby.Damage = damage;
        BurnBaby.Rate = FireSpeed;
        Instantiate(BurnBaby, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
