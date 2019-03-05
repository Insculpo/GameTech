using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarHarm : MonoBehaviour
{
    [SerializeField] float Burner = 0.1f;
    [SerializeField] float Delay = 5.0f;
    bool IsColliding = false;
    float Residue = 0.1f;

    public bool IsBurning;
    // Start is called before the first frame update
    void Start()
    {
        IsBurning = false;
    }

    void Update()
    {
        if (IsColliding == true)
        {

        }
        else
        {
            IsBurning = false;
        }

    }
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        HealthSystem burn = other.gameObject.GetComponent<HealthSystem>();
        if (burn != null && other.gameObject.tag == "Player")
        {
            IsBurning = true;
            burn.HurtMe(Burner);
            IsColliding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            IsColliding = false;
        }
    }
}
