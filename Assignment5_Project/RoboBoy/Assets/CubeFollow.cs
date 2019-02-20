using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeFollow : MonoBehaviour
{
    public NavMeshAgent KILL;
    [SerializeField] GameObject Player;
    public float CubeHP = 3f;
    [SerializeField] float CubeHarm = 1f;
    [SerializeField] float HarmCooldown = 2f;
    [SerializeField] float WakeDistance = 20f;
    [SerializeField] BoxCollider HurtBox;
    public Animator StateMe;
    AnimatorClipInfo Timer;
    float DieNow = 0f;
    float hurtCalc = 0f;
    public bool PlayerHit = false;

    // Start is called before the first frame update
    void Start()
    {
        KILL = GetComponent<NavMeshAgent>();
        StateMe = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHit == true && hurtCalc == 0)
        {
            HurtPlayer(CubeHarm);
            hurtCalc++;
        }
        else if (hurtCalc < HarmCooldown)
        {
            hurtCalc++;
        } else
        {
            hurtCalc = 0;
        }
        if (Player.GetComponent<Controller>().Health > 0 && CubeHP > 0)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) < WakeDistance)
            {
                KILL.SetDestination(Player.transform.position);
                return;
            }
        }

        else
        {

            StateMe.Play("Dead");
            if (DieNow > 35)
            {
                Destroy(gameObject);
            }
            DieNow++;
        }



    }

    public void HurtPlayer(float pain)
    {
        Player.GetComponent<Controller>().EnemyCollide(pain);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Controller Played = collision.gameObject.GetComponent<Controller>();
        PlasmaKill ByeBye = collision.gameObject.GetComponent<PlasmaKill>();
        if (ByeBye != null)
        {
            CubeHP -= ByeBye.Damage;
            return;
        }
    }


}
