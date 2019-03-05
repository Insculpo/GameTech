using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun : MonoBehaviour
{
    [SerializeField] RailgunProjectile RP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Shoot()
    {
        RP.LauncherOrientation = gameObject;
        Instantiate(RP, transform.position, transform.parent.rotation);
    }
}
