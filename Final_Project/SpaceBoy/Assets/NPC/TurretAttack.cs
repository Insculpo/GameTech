using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [SerializeField] RailGun RailgunModule;
    [SerializeField] GameObject Player;
    [SerializeField] float MinRecharge = 20f;
    [SerializeField] float MaxRecharge = 45f;
    [SerializeField] float TurnRate = 5f;
    [SerializeField] List<float> FirePattern;
    [SerializeField] bool PatternedFire = false;
    [SerializeField] float WakeDistance = 100f;
    int f = 0;
    Rigidbody RB;
    Vector3 PlayerLoc;
    float timer = 0f;
    float RandomReload = 0f;
    // Start is called before the first frame update
    void Start()
    {
        RandomReload = Random.Range(MinRecharge, MaxRecharge);
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < WakeDistance)
        {
            Vector3 AimDirection = Player.transform.position - transform.position;
            Quaternion RottingTurret = Quaternion.LookRotation(AimDirection);
            RottingTurret *= Quaternion.Euler(90f, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, RottingTurret, TurnRate * Time.deltaTime);
            if (timer > RandomReload && PatternedFire == false)
            {
                BlastEm();
                RandomReload = Random.Range(MinRecharge, MaxRecharge);
                timer = 0f;
            }
            if (PatternedFire == true && timer > FirePattern[f])
            {
                BlastEm();
                f++;
                timer = 0;
            }
            if (f >= FirePattern.Count)
            {
                Debug.Log("Resetting..");
                f = 0;
            }
            timer++;
        }
    }

    void BlastEm()
    {
        RailgunModule.Shoot();
    }
}
