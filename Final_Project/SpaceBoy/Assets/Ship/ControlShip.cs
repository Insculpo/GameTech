using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShip : MonoBehaviour
{
    public float ThrustFactor = 5f;
    public float StrafeFactor = 4f;
    public float StrafeImpulseBoost = 4f;
    public float RotationFactor = 1f;
    public float ImpulseFactor = 10f;
    public float VelCap = 100f;
    public float ImpulseDelay = 10f;
    public float impulseTimer = 0f;
    public float rechargeDelay = 20f;
    public float rechargeRate = 0.5f;
    public float Decelerator = 0.5f;
    public float Shielding = 50f;
    float Deceleration = 1f;
    public bool CanImpulse = true;
    public bool UpdeadImpulse = false;
    Vector3 CurrentVela;
    Vector3 PrevVela;
    Vector3 Acceleration;
    float Impulse;
    [SerializeField] AudioSource thrustSound;
    [SerializeField] CursorLock AimHere;
    [SerializeField] HealthSystem HS;
    [SerializeField] SpriteRenderer ThrusterBack;
    [SerializeField] SpriteRenderer ThrusterFront;
    [SerializeField] SpriteRenderer ThrusterLeft;
    [SerializeField] SpriteRenderer ThrusterRight;
    [SerializeField] SpriteRenderer ImpThrusterBack;
    [SerializeField] SpriteRenderer ImpThrusterFront;
    [SerializeField] SpriteRenderer ImpThrusterLeft;
    [SerializeField] SpriteRenderer ImpThrusterRight;

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
        if(UpdeadImpulse == true)
        {
            CanImpulse = true;
        }
        if(HS.GetHealth() < Shielding && HS.wasHarmed(rechargeDelay) == false)
        {
            HS.Health += rechargeRate;
        }
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
        float StrafeVar = 1f;
        if (Input.GetKeyDown(KeyCode.T) && ImpulseFrame == true && UpdeadImpulse == true)
        {
            ImpulseFrame = false;
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
        //Aim();


        if (Input.GetKey(KeyCode.W))
        {
            CentralHull.AddForce(transform.up * ThrustFactor * Impulse * Deceleration);
            ThrustFlicker(ThrusterBack);
            StartCoroutine(CheckImpulse(ImpThrusterBack));
            DidThrust = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            CentralHull.AddForce(-transform.up * ThrustFactor * Impulse * Deceleration);
            ThrustFlicker(ThrusterFront);
            StartCoroutine(CheckImpulse(ImpThrusterFront));
            DidThrust = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (DidThrust == true)
            {
                StrafeVar = Impulse * StrafeImpulseBoost;
            }
            ThrustFlicker(ThrusterLeft);
            StartCoroutine(CheckImpulse(ImpThrusterLeft));
            CentralHull.AddForce(-transform.right * StrafeFactor * StrafeVar * Deceleration);
            DidThrust = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (DidThrust == true)
            {
                StrafeVar = Impulse * StrafeImpulseBoost;
            }
            ThrustFlicker(ThrusterRight);
            StartCoroutine(CheckImpulse(ImpThrusterRight));
            CentralHull.AddForce(transform.right * StrafeFactor * StrafeVar * Deceleration);
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
        else
        {
            DisableAllThrusts();
        }
        PrevVela = CentralHull.velocity;
        return false;
    }

    IEnumerator CheckImpulse(SpriteRenderer Imp)
    {
        int I = 0;
        if (ImpulseFrame == true)
        {
            while (I < 5)
            {
                Imp.enabled = true;
                I++;
                yield return null;
            }
        }
        else
        {
            Imp.enabled = false;
        }

    }

    void DisableAllThrusts()
    {
        ImpThrusterBack.enabled = false;
        ImpThrusterFront.enabled = false;
        ImpThrusterLeft.enabled = false;
        ImpThrusterRight.enabled = false;
        ThrusterBack.enabled = false;
        ThrusterFront.enabled = false;
        ThrusterLeft.enabled = false;
        ThrusterRight.enabled = false;
    }

    void ThrustFlicker(SpriteRenderer Thrusty)
    {
        int FlickProp = Random.Range(0, 6);
        if(FlickProp < 5)
        {
            Thrusty.enabled = true;
        }
        else
        {
            Thrusty.enabled = false;
        }
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
            thrustSound.spatialBlend = Random.Range(0.3f, 0.8f);
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
