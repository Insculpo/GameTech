using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaKill : MonoBehaviour
{
    [SerializeField] ParticleSystem DeathEmission;
    [SerializeField] Rigidbody projection;
    public float Rate = 0f;
    public float Damage;
    Vector3 ProjectileDirection;
    bool didPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        DeathEmission = GetComponentInChildren<ParticleSystem>();
        projection = GetComponent<Rigidbody>();
        projection.AddForce(GetComponentInParent<Transform>().up * Rate * 100);

    }

    // Update is called once per frame
    void Update()
    {
        if (DeathEmission.isPlaying == false && didPlay == true)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Can't touch this");

        } else
        {
            Debug.Log(collision.gameObject.name);
            DeathEmission.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            didPlay = true;
        }
    }
}
