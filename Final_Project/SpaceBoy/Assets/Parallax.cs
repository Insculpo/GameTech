using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float ScrollConstant = 0.001f;
    [SerializeField] float Distance = -15f;
    Vector3 Origin;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<ControlShip>().GetComponent<Transform>();
        transform.position = new Vector3(Player.transform.position.x, Distance, Player.transform.position.z);
        Vector3 Origin = Player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float distX = (Player.transform.position.x * ScrollConstant);
        float distZ = (Player.transform.position.z * ScrollConstant);

        transform.position = new Vector3(Origin.x + distX, transform.position.y, Origin.z + distZ);

    }
}
