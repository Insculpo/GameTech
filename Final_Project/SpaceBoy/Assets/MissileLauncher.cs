using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] HomingMissile HM;
    [SerializeField] float Recharge = 10f;
    [SerializeField] float LaunchDirection = 0f;
    [SerializeField] public int MissileCount = 100;
    [SerializeField] public int MissileTimer = 0;
    [SerializeField] CursorLock TargetPos;
    [SerializeField] GameObject PlayerTarget;
    [SerializeField] bool PlayerLauncher = false;
    // Start is called before the first frame update

    void Start()
    {
        PlayerTarget = FindObjectOfType<ControlShip>().gameObject;
    }

    void Update()
    {
        MissileTimer++;
    }

    // Update is called once per frame
    public void FireMissile()
    {
        if (Recharge < MissileTimer && MissileCount > 0)
        {

            if (PlayerLauncher == true && HM.target != null)
            {
                HM.target = TargetPos.gameObject;
                HM.LaD = LaunchDirection;
                Instantiate(HM, transform.position, transform.parent.rotation);
            }
            else
            {
                if (PlayerTarget != null)
                {
                    //JUST STOP
                    HM.target = PlayerTarget;
                    HM.LaD = LaunchDirection;
                    Instantiate(HM, transform.position, transform.parent.rotation);
                }
            }
            MissileTimer = 0;
            MissileCount--;
        }
    }

    public string MissileAmmo()
    {
        return "Missiles Left: " + MissileCount;
    }
}
