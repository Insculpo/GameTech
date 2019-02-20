using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCam : MonoBehaviour
{
    [SerializeField] bool XOnly = false;
    [SerializeField] bool YOnly = false;
    [SerializeField] bool ZOnly = false;

    [SerializeField] bool isAwake = false;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (isAwake == true && XOnly == false && YOnly == false && ZOnly == false)
        {
            transform.LookAt(player);
            return;
        }
        if(XOnly == true)
        {
            Vector3 Target = new Vector3(transform.position.x, player.position.y, player.position.z);
            transform.LookAt(Target);
            return;
        }
        if (YOnly == true)
        {
            Vector3 Target = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(Target);
            return;
        }
        if (ZOnly == true)
        {
            Vector3 Target = new Vector3(player.position.x, player.position.y,transform.position.z);
            transform.LookAt(Target);
        }
    }

    // Update is called once per frame
    public void FlipOff()
    { 
       isAwake = false;
        GetComponent<Camera>().enabled = false;
    }
    public void FlipOn()
    {
        isAwake = true;
        GetComponent<Camera>().enabled = true;
    }

}
