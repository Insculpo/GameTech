using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun : MonoBehaviour
{
    [SerializeField] RailgunProjectile RP;
    [SerializeField] float AttackAngle = 0f;
    [SerializeField] float reload = 20f;
    [SerializeField] bool isTurret = true;
    [SerializeField] AudioSource RailSound;
    float reloadTimer = 0;
    public bool SuccessfulShot = false;
    // Start is called before the first frame update
    void Start()
    {
        RailSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        reloadTimer++;
    }

    // Update is called once per frame
    public void Shoot()
    {
        RP.LauncherOrientation = gameObject;
        RP.LaunchDir(AttackAngle);
        if(isTurret == true && RP != null)
        {
            Instantiate(RP, transform.position, transform.parent.rotation);
            RailSound.Play();
            SuccessfulShot = true;
            return;
        }
        if (RP != null && reloadTimer >= reload)
        {
            Instantiate(RP, transform.position, transform.parent.rotation);
            RailSound.Play();
            SuccessfulShot = true;
            reloadTimer = 0;
            return;
        }
        SuccessfulShot = false;
    }
}
