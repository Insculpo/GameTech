using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Controller : MonoBehaviour
{
    Transform Teleporter;
    Rigidbody Forces;
    CharacterController cControl;
    [SerializeField] GameObject FlashLight;
    [SerializeField] Animator animBlast;
    [SerializeField] Animator animHead;
   // [SerializeField] Animator animHover;


    // [SerializeField] CameraControl CamCon;
    // [SerializeField] TextMeshProUGUI scoreBoard;cContrtol
    [SerializeField] float Movement = 1f;
    [SerializeField] float JumpForce = 100f;
    [SerializeField] float gravity = -10f;
    [SerializeField] float rotationFlash = 6f;
    public float Health = 10f;
    public float zipper = 0.02f;
    float zip = 0f;
    bool FisOn = true;
    AnimationState fireState;
    Quaternion defaultRot;
    float AnimationTimer = 0f;
    float ReactionTimer = 0f;
    float HarmTimer = 0f;
    bool GoldTimer = false;
    bool HurtTime = false;
    [SerializeField] float ChargeTime = 30f;
    [SerializeField] float LoadingTime = 90f;
    float originalCharge;
    [SerializeField] ProjectileFire BlasterArmControl;
    float DeadTime = 0f;

    float ySpeed = 0;


    public int score = 0;

    Vector3 newSpeed;

    public bool newScore;

    // Start is called before the first frame update
    void Start()
    {
        cControl = GetComponent<CharacterController>();
        Teleporter = GetComponent<Transform>();
        Forces = GetComponent<Rigidbody>();
        defaultRot = new Quaternion();
        defaultRot = transform.rotation;
        originalCharge = ChargeTime;
        cControl.detectCollisions = true;
        ChargeTime = LoadingTime;
         zip = 0f;
       // fireState = animBlast["Recoil"];
    }

    // Update is called once per frame
    void Update()
    {
        if (Health > 0)
        {
            float xAxis = Input.GetAxis("Vertical") * -Movement;
            float yAxis = Input.GetAxis("Horizontal") * -Movement;
            if (Input.GetKey(KeyCode.Q))
            {
                Teleporter.Rotate(new Vector3(0, 0, rotationFlash));
            }
            if (Input.GetKey(KeyCode.E))
            {
                Teleporter.Rotate(new Vector3(0, 0, -rotationFlash));
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (FisOn == true)
                {
                    FlashLight.GetComponent<Light>().enabled = false;
                    FisOn = false;
                }
                else
                {
                    FlashLight.GetComponent<Light>().enabled = true;
                    FisOn = true;
                }

                transform.localPosition += Vector3.up * Mathf.Sin(zip) / 10;
                zip += zipper;
            }
            /*if (newScore == true)
             {
                 newScsore = false;
                 scoreBoard.text = score.ToString();

             }*/


            if (cControl.isGrounded == true)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    animBlast.SetBool("IsFiring", true);
                    if (AnimationTimer >= ChargeTime)
                    {
                        ChargeTime = originalCharge;
                        AnimationTimer = 0;
                        BlasterArmControl.FirePlasma(10, 10);
                    }
                    AnimationTimer++;
                    // ySpeed = JumpForce;
                }
                else
                {
                    AnimationTimer = 0;
                    animBlast.SetBool("IsFiring", false);
                    ChargeTime = LoadingTime;
                    //  ySpeed = gravity * Time.deltaTime;
                }
            }
            else
            {
                ySpeed += gravity;
            }

            //Clockwise/Counterclockwise Camera rotation

            //To keep rotations on one axis only
            /*  if (CamCon.returnCam() == true)
              {
                  transform.rotation = CamCon.returnFPSRot();
              } */



            Vector3 mover = new Vector3(xAxis, yAxis, ySpeed);
            mover *= Time.deltaTime;
            mover = transform.TransformDirection(mover);
            cControl.Move(mover);
        } else
        {
            animHead.SetBool("IsDead", true);
            if(DeadTime > 100f)
            {
                SceneManager.LoadScene("PlayableReleaseOne");
            }
            
        }
        CheckTimers();

    }

    public void PickUpCollide()
    {
            animHead.SetBool("IsGold", true);
            GoldTimer = true;
    }

    public void EnemyCollide( float Harm)
    {
            animHead.SetBool("IsHarmed", true);
            Health -= Harm;
            HurtTime = true;
    }

    

    void CheckTimers()
    {
        if (GoldTimer == true && ReactionTimer < 60)
        {
            ReactionTimer++;
        }
        else
        {
            animHead.SetBool("IsGold", false);
            GoldTimer = false;
            ReactionTimer = 0;
        }
        if (HurtTime == true && HarmTimer < 60)
        {
            HarmTimer++;
        }
        else
        {
            animHead.SetBool("IsHarmed", false);
            HurtTime = false;
            HarmTimer = 0;
        }
        if(Health <= 0)
        {
            DeadTime++;
        }
    }


}
