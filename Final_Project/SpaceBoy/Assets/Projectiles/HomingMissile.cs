using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : Projectile
{
    [SerializeField] public GameObject target;
    [SerializeField] public GameObject cursor;
    [SerializeField] Rigidbody MissileThruster;
    [SerializeField] float MissileRate = 100f;
    [SerializeField] float MissileHandling = 0.1f;
    [SerializeField] bool isPlayer = false;
    [SerializeField] float InitialVela = 2f;

    // Start is called before the first frame update
    void Awake()
    {
        if (isPlayer == false)
        {
            MissileThruster.velocity = gameObject.transform.forward * InitialVela;
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
            MissileThruster.velocity = gameObject.transform.forward * InitialVela;
            target = FindObjectOfType<CursorLock>().gameObject; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            CountDown();
            Chase();
        }
    }

    public void Chase()
    {
        Vector3 AimDirection = target.transform.position - transform.position;

        Quaternion RottingTurret = Quaternion.LookRotation(AimDirection);
        RottingTurret *= Quaternion.Euler(90f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, RottingTurret, MissileHandling * Time.deltaTime);
        MissileThruster.velocity = (AimDirection * MissileRate);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (Faction == 0f)
        {
            if (collision.gameObject.GetComponent<HealthSystem>() != null && collision.gameObject.tag != "Player")
            {
                Debug.Log("A Collided with " + collision.gameObject.name);
                collision.gameObject.GetComponent<HealthSystem>().HurtMe(Damage);
                Destroy(gameObject);
                return;
            }
        }
        if (Faction == 1f)
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<HealthSystem>() != null)
            {
                collision.gameObject.GetComponent<HealthSystem>().HurtMe(Damage);
                Destroy(gameObject);
                return;
            }
            if (collision.gameObject.tag != "Defense")
            {
                Destroy(gameObject);
                return;
            }
        }

    }
}
