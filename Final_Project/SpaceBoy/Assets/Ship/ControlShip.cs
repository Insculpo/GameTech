using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShip : MonoBehaviour
{
    public float ThrustFactor = 5f;
    public float StrafeFactor = 4f;
    public float RotationFactor = 1f;
    public float ImpulseFactor = 10f;
    public float VelCap = 100f;
    public float ImpulseDelay = 10f;
    public float impulseTimer = 0f;
    public float rechargeDelay = 20f;
    public float rechargeRate = 0.5f;
    public bool CanImpulse = true;
    float Impulse;
    [SerializeField] AudioSource thrustSound;
    [SerializeField] CursorLock AimHere;
    Rigidbody CentralHull;
    Transform Rotator;
    public Vector2 ShipCoordinates;
    public bool isThrusting;
    bool ImpulseFrame = false;
    bool xWrap = false;
    bool yWrap = false;
    bool WrapDelay = false;
    int WrapTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        ShipCoordinates = new Vector2();
        CentralHull = GetComponent<Rigidbody>();
        Rotator = GetComponent<Transform>();
        thrustSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Wrap();
        WrapTime++;
        if(WrapTime > 10)
        {
            WrapTime = 0;
            xWrap = false;
            yWrap = false;
        }
        if (ImpulseFrame == true && CanImpulse == true)
        {
            Impulse = ImpulseFactor;
        }
        else
        {
            Impulse = 1f;
        }
        ShipCoordinates.x = transform.position.x;
        ShipCoordinates.y = transform.position.z;
       // Aim();
        isThrusting = CheckThrust();

        if (CentralHull.velocity.magnitude > VelCap)
        {
            CentralHull.velocity = Vector3.ClampMagnitude(CentralHull.velocity, VelCap);

        }
        if (ImpulseFrame == true && isThrusting == true)
        {
            ImpulseFrame = false;
        }
        if (isThrusting == true)
        {
            impulseTimer = 0f;
            ThrustEffects();
        }
        else
        {
            if (impulseTimer > ImpulseDelay)
            {
                ImpulseFrame = true;
            }
            else
            {
                impulseTimer++;
            }
            thrustSound.Stop();
        }

    }

    void Aim()
    {
        transform.LookAt(AimHere.transform);
        transform.rotation *= Quaternion.Euler(90f, 0f, 0f);
        float A = Vector3.Angle(transform.position, AimHere.transform.position);
        transform.rotation *= Quaternion.AngleAxis(A, transform.up);

    }

    bool CheckThrust()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (CanImpulse == false)
            {
                CanImpulse = true;
            }
            else
            {
                CanImpulse = false;
            }
        }
        bool DidThrust = false;
        Aim();
        if (Input.GetKey(KeyCode.W))
        {
            CentralHull.AddForce(transform.up * ThrustFactor * Impulse);
            DidThrust = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            CentralHull.AddForce(-transform.up * ThrustFactor * Impulse);
            DidThrust = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            CentralHull.AddForce(-transform.right * StrafeFactor * Impulse);
            DidThrust = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            CentralHull.AddForce(transform.right * StrafeFactor * Impulse);
            DidThrust = true;
        }

/*        if (Input.GetKey(KeyCode.A))
        {
            Rotator.Rotate(0f, 0f, RotationFactor);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rotator.Rotate(0f, 0f, -RotationFactor);
        }*/

        if (DidThrust == true)
        {
            impulseTimer = 0f;
            return true;
        }
        return false;
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
        WrapDelay = true;
    }

    void ThrustEffects()
    {
        if (thrustSound.isPlaying == false)
        {
            thrustSound.Play();
        }
    }

    public string CoordsToString()
    {
        return "Coordinates: " + Mathf.Floor(ShipCoordinates.x) + " , " + Mathf.Floor(ShipCoordinates.y);
    }

    public string VelToString()
    {
        return "Velocity: " + Mathf.Floor(CentralHull.velocity.magnitude) + "Km/s";
    }

    public string ImpToString()
    {
        if (CanImpulse == true)
        {
            return "Impulse Drive Active";
        }
        return "Impulse Drive Disabled";
    }
}
