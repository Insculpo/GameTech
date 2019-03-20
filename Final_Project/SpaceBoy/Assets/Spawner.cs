using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject ProbeSpawn;
    [SerializeField] float minDelay = 500f;
    [SerializeField] float maxDelay = 1000f;
    float spawnTimer;
    float delayTime;
    [SerializeField] EnemyShipController ESC;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0f;
        delayTime = Random.Range(minDelay, maxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if(ESC.WakeSound == true)
        {
            if (spawnTimer > delayTime)
            {
                MakeProbe();
            }
            spawnTimer++;
        }
    }

    void MakeProbe()
    {
        Instantiate(ProbeSpawn, gameObject.transform.position, gameObject.transform.rotation);
        spawnTimer = 0f;
        delayTime = Random.Range(minDelay, maxDelay);
    }


}
