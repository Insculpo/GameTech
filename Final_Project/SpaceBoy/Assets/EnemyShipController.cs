using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    Transform Player;
    Rigidbody Controls;
    [SerializeField] TurretModule[] Turrets;
    [SerializeField] float TurnRate = 5f;
    [SerializeField] float WakeDistance = 300f;
    [SerializeField] float MoveRate = 0.1f;
    [SerializeField] float StrafeImpulse = 100f;
    [SerializeField] int Modulus = 0;
    [SerializeField] int MoveThresholdMin = 200;
    [SerializeField] int MoveThresholdMax = 1000;
    int MoveConstantStart;
    int WrapTime = 0;
    bool yWrap = false;
    bool xWrap = false;

    // Start is called before the first frame update
    void Start()
    {
        SetMoveTimer();
        Player = FindObjectOfType<ControlShip>().gameObject.transform;
        Controls = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < WakeDistance)
        {
            Wrap();
            WrapTime++;
            if (WrapTime > 10)
            {
                WrapTime = 0;
                xWrap = false;
                yWrap = false;
            }
                Vector3 AimDirection = Player.transform.position - transform.position;

            Quaternion RottingTurret = Quaternion.LookRotation(AimDirection);
            RottingTurret *= Quaternion.Euler(90f, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, RottingTurret, TurnRate * Time.deltaTime);
            Controls.velocity = AimDirection * MoveRate;
            DefaultMoveController(AimDirection);
        }
    }

    void DefaultMoveController(Vector3 AimDirection)
    {
        if (Modulus > MoveConstantStart)
        {
            SetMoveTimer();
            float R = Random.Range(0, 8);
            switch (R)
            {
                case 0:
                    StartCoroutine(ReverseMovement(AimDirection));
                    break;
                case 1:
                    StartCoroutine(LeftStrafe(AimDirection));
                    break;
                case 2:
                    StartCoroutine(RightStrafe(AimDirection));
                    break;
                case 3:
                    StartCoroutine(Charge(AimDirection));
                    break;
                case 4:
                    StartCoroutine(Madness(AimDirection));
                    break;
                case 5:
                    StartCoroutine(MadnessInverse(AimDirection));
                    break;
                default:
                    StartCoroutine(Charge(AimDirection));
                    break;
            }
            Modulus = 0;
        }
        Modulus++;
    }

    void SetMoveTimer()
    {
        MoveConstantStart = Random.Range(MoveThresholdMin, MoveThresholdMax);
    }


    void Wrap()
    {
        if (!xWrap && (transform.position.x > 8000 || transform.position.x < -8000))
        {
            Vector3 newPos = new Vector3(-transform.position.x, 0f, transform.position.z);
            transform.position = newPos;
            xWrap = true;
        }
        if (!yWrap && (transform.position.z > 8000 || transform.position.z < -8000))
        {
            Vector3 newPos = new Vector3(transform.position.x, 0f, -transform.position.z);
            transform.position = newPos;
            yWrap = true;
        }
    }

    IEnumerator Charge(Vector3 AimDirection)
    {
        for (int i = 0; i < 1000f; i++)
        {
            Controls.velocity += AimDirection * MoveRate * 0.3f;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Madness(Vector3 AimDirection)
    {
        for (int i = 0; i < 1000f; i++)
        {
            Controls.velocity += AimDirection * MoveRate * Mathf.Cos(.05f * (float)i);
            Controls.velocity += transform.right * MoveRate * Mathf.Sin(.05f * (float)i);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator MadnessInverse(Vector3 AimDirection)
    {
        for (int i = 0; i < 1000f; i++)
        {
            Controls.velocity += AimDirection * MoveRate * Mathf.Sin(.05f * (float)i);
            Controls.velocity += transform.right * MoveRate * Mathf.Cos(.05f * (float)i);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator ReverseMovement(Vector3 AimDirection)
    {
        for (int i = 0; i < 100f; i++)
        { 
            Controls.velocity += -AimDirection * MoveRate;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator LeftStrafe(Vector3 AimDirection)
    {
        for (int i = 0; i < 1000f; i++)
        {
            Controls.velocity += transform.right * MoveRate * 10;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator RightStrafe(Vector3 AimDirection)
    {
        for (int i = 0; i < 1000f; i++)
        {
            Controls.velocity += -transform.right * MoveRate * 10;
            yield return new WaitForEndOfFrame();
        }
    }
}
