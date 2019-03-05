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
    public bool CanImpulse = true;
    float Impulse;
    [SerializeField] AudioSource thrustSound;
    Rigidbody CentralHull;
    Transform Rotator;
    public Vector2 ShipCoordinates;
    public bool isThrusting;
    bool ImpulseFrame = false;
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
        if (Input.GetKey(KeyCode.Q))
        {
            Rotator.Rotate(0f, 0f, RotationFactor);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Rotator.Rotate(0f, 0f, -RotationFactor);
        }

        if (DidThrust == true)
        {
            impulseTimer = 0f;
            return true;
        }
        return false;
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
