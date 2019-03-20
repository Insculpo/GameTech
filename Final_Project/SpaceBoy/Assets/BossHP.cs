using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    [SerializeField] HealthSystem Boss;
    [SerializeField] Slider HosssHull;
    // Start is called before the first frame update
    void Start()
    {
        HosssHull.maxValue = Boss.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        HosssHull.value = Boss.GetHealth();
    }
}
