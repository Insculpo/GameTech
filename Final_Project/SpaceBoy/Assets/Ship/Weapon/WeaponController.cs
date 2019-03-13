using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] RailGun RailgunLauncher;
    [SerializeField] MissileLauncher Missiles;

    int WeaponSelect = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RailgunLauncher.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Missiles.FireMissile();
        }
    }
    
}
