using UnityEngine;


public class CameraControl : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Vector3 displace;
    public Camera FirstPerson;
    public Camera ThirdPerson;

    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] float tA = 40f;
    [SerializeField] Vector3 offset;
    [SerializeField] bool cams = false;
    [SerializeField] float Sensitivity = 90f;
    [SerializeField] float clampAngle = 100f;
    [SerializeField] float rotSpeed = 12f;
    private float rotX = 0.0f;
    private float rotY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void SwitchCamera()
    {
        if (cams == true)
        {
            FirstPerson.enabled = true;
            ThirdPerson.enabled = false;
            cams = false;
            return;
        }
        if (cams == false)
        {
            FirstPerson.enabled = false;
            ThirdPerson.enabled = true;
            cams = true;
            return;
        }
    }

    void Update()
    {
        if (FirstPerson.enabled == true)
        {
            float MouseY = Input.GetAxis("Mouse Y");
            transform.localRotation = Quaternion.AngleAxis(-MouseY, Vector3.right);
            target.transform.localRotation = Quaternion.AngleAxis(FirstPerson.transform.rotation.x, target.transform.up);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (FirstPerson.enabled == true)
        {
            FirstPerson.transform.position = target.position;
        } else {
            Vector3 wantPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, wantPosition, smoothSpeed);
            //Camera positioning varies depending on if it's first or third position.
            ThirdPerson.transform.position = smoothPosition;
            ThirdPerson.transform.LookAt(target.position);
        }
        MouseFPS();

    }

    void MouseFPS()
    {
        //Gets the directions and rotates the camera 
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        rotY += MouseX * Sensitivity * Time.deltaTime;
        rotX += MouseY * Sensitivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion localRot = Quaternion.Euler(rotX, rotY, 0.0f);
        FirstPerson.transform.rotation = localRot;
    }

    public bool returnCam()
    {
        return cams;
    }

    public Quaternion returnFPSRot()
    {
        return FirstPerson.transform.rotation;
    }

    public void RotateCam(bool i)
    {
        if (i == false)
        {
            ThirdPerson.transform.RotateAround(target.position, Vector3.up, rotSpeed);
        } else
        {
            ThirdPerson.transform.RotateAround(target.position, Vector3.up, -rotSpeed);
        }
    }
}

