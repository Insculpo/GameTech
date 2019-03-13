using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Camera CamPosition;
    [SerializeField] Transform ShipPosition;
    [SerializeField] float ScrollConstant = 0.001f;
    [SerializeField] float Distance = -15f;
    Vector3 Central;
    // Start is called before the first frame update
    void Start()
    {
        Central = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float ShipDisplaceX = Central.x - ShipPosition.position.x;
        float ShipDisplaceZ = Central.z - ShipPosition.position.z;

        //float distX = (Player.transform.position.x * ScrollConstant);
        float NewPosX = (CamPosition.transform.position.x - ShipDisplaceX * ScrollConstant);
        float NewPosZ = (CamPosition.transform.position.z - ShipDisplaceZ * ScrollConstant);
        transform.position.Set(ShipDisplaceX, 0f, ShipDisplaceZ);

//
    }
}
