using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjector : Projectile
{
    [SerializeField] GameObject target;
    [SerializeField] LineRenderer Laser;
    [SerializeField] CursorLock CL;
    [SerializeField] bool IsPlayer = true;
    [SerializeField] float LaserRange = 1000f;
    [SerializeField] Collider KillCollider;
    [SerializeField] float F = 0;
    [SerializeField] float BeamWait = 0;
    [SerializeField] AudioSource Beams;
    bool Beaming = false;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        Beams = GetComponent<AudioSource>();
        KillCollider = GetComponent<BoxCollider>();
        target = CL.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        LifeSpan += 10;
        if(BeamWait > 2)
        {
            StartCoroutine(EndBeam());
        }
        BeamWait++;
    }

    public void Beam()
    {
            Beams.Play();
        
        Laser.positionCount = 0;
        Vector3 Dir = target.transform.position - transform.position;
        Laser.positionCount = 2;
        Laser.SetPosition(0, transform.position);
        Laser.SetPosition(1, target.transform.position);
        CL.gameObject.GetComponent<TouchToKill>().Activate();
        if (Physics.Raycast(transform.position, Dir, out hit) && hit.transform.GetComponentInChildren<HealthSystem>() != null)
        {
            HealthSystem H = hit.transform.GetComponentInChildren<HealthSystem>();
            if (H.faction != F)
            {

                H.HurtMe(Damage);
            }
        }
        BeamWait = 0;
    }

    IEnumerator EndBeam()
    {
        CL.gameObject.GetComponent<TouchToKill>().Deactivate();
        Beams.Stop();
        yield return null;
        Laser.positionCount = 0;
    }

}
