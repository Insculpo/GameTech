using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavArrow : MonoBehaviour
{
    Transform NavDir;
    // Start is called before the first frame update
    void Start()
    {
        NavDir = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(NavDir);
    }
}
