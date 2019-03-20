using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class WeaponController : MonoBehaviour
{
    [SerializeField] RailGun RailgunLauncher;
    [SerializeField] RailGun RailgunLauncher2;
    [SerializeField] MissileLauncher Missiles;
    [SerializeField] LaserProjector Laser;

    int WeaponSelect = 0;
    public int missileAmmo = 50;
    public int railgunAmmo = 50;
    public float overHeating = 100f;
    public float coolDown = 0f;
    bool isCooled = true;
    float overHeatingDefault = 40f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Cool();
        RationalizeWeapons();
        float Scroll = Input.mouseScrollDelta.y;
        if (Scroll > 0)
        {
            WeaponSelect++;
        }
        if (Scroll < 0)
        {
            WeaponSelect--;
        }
        switch (WeaponSelect)
        {
            case 0: FireRailgun();
                    break;
            case 1: FireMiss();
                    break;
            case 2: FireGauss();
                    break;
            default:FireGauss();
                break;
        }
        FireLaser();


    }
    void RationalizeWeapons()
    {
        if (WeaponSelect > 2)
        {
            Debug.Log("Triggered");
            WeaponSelect = 0;
        }
        if (WeaponSelect < 0)
        {
            WeaponSelect = 2;
        }
    }

    void Cool()
    {
        if(coolDown <= 0f)
        {
            isCooled = true;
        }
        coolDown--;
    }

    void FireMiss()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && missileAmmo > 0)
        {
            Missiles.FireMissile();
            missileAmmo--;
        }
    }

    void FireRailgun()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && railgunAmmo > 0)
        {
            RailgunLauncher.Shoot();
            if(RailgunLauncher.SuccessfulShot == true)
            {
                railgunAmmo--;
            }
        }
    }
    void FireGauss()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Shooting Gauss...");
            RailgunLauncher2.Shoot();
        }
    }
    void FireLaser()
    {
        if(coolDown > overHeating)
        {
            isCooled = false;
        }
        if (Input.GetKey(KeyCode.Mouse1) && isCooled == true)
        {
            if (Laser != null)
            {
                Laser.Beam();
                coolDown++;
            }
        }
    }

    public string MissileAmmo()
    {
        return "Missile Ammo: " + missileAmmo;
    }

    public string RailgunAmmo()
    {
        return "Railgun Ammo: " + railgunAmmo;
    }

    public float Cooling()
    {
        return coolDown;
    }
    
}
