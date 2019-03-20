using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : Projectile
{
    [SerializeField] public GameObject target;
    [SerializeField] public GameObject cursor;
    [SerializeField] public GameObject LauncherKey;
    [SerializeField] Rigidbody MissileThruster;
    [SerializeField] float MissileRate = 100f;
    [SerializeField] float MissileHandling = 0.1f;
    [SerializeField] bool isPlayer = false;
    [SerializeField] float InitialVela = 2f;
    [SerializeField] float MissileAcceleration = 1f;
    [SerializeField] float AccelFactor = 0.1f;
    [SerializeField] bool Accelerates = false;
    [SerializeField] SpriteRenderer MissileThrust;
    [SerializeField] AudioSource MissileLaunched;


    // Start is called before the first frame update
    void Awake()
    {
        MissileLaunched = GetComponent<AudioSource>();
        MissileLaunched.Play();
        if (isPlayer == false)
        {
           // MissileThruster.velocity = gameObject.transform.forward * InitialVela;
            if (target == null)
            {
                target = Camera.main.transform.gameObject;
                return;
            }
            if (target != null)
            {
                target = FindObjectOfType<ControlShip>().gameObject;
            }
            return;
        }
        else
        {
            LauncherKey = FindObjectOfType<ControlShip>().gameObject;
            target = FindObjectOfType<CursorLock>().gameObject;
        }

            Quaternion Rot = Quaternion.AngleAxis(LaD, Vector3.up) * LauncherKey.transform.rotation;
            Vector3 LaDi = LauncherKey.transform.rotation * -LauncherKey.transform.forward;
            GetComponent<Rigidbody>().velocity = (LaDi * InitialVela) + LauncherKey.GetComponent<Rigidbody>().velocity;

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Flicker();
            CountDown();
            Chase();
        }
    }

    void Flicker()
    {
        int MRand = Random.Range(0, 4);
        if (MRand < 3)
        {
            MissileThrust.enabled = true;
        }
        else
        {
            MissileThrust.enabled = false;
        }
    }

    public void Chase()
    {
        Vector3 AimDirection = target.transform.position - transform.position;

        Quaternion RottingTurret = Quaternion.LookRotation(AimDirection);
        RottingTurret *= Quaternion.Euler(90f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, RottingTurret, MissileHandling * Time.deltaTime);
        if (Accelerates == true)
        {
            MissileThruster.velocity += (AimDirection.normalized * 0.1f * MissileAcceleration);
            MissileAcceleration += AccelFactor;
        }
        else
        {
            MissileThruster.maxAngularVelocity = MissileHandling;
            MissileThruster.velocity = AimDirection.normalized * MissileRate;
        }
    }


}
