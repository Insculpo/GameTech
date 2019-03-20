using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPlacer : MonoBehaviour
{
    [SerializeField] Sprite[] asteroidTypes;
    SpriteRenderer ASR;
    Transform MainBody;
    Gravity GR;
    OrbitVelocity OB;
    [SerializeField] float DistanceMin = 400f;
    [SerializeField] float DistanceMax = 7800f;
    // Start is called before the first frame update
    private void Awake()
    {
    }

    void Start()
    {
        float Tint = Random.Range(120, 255);
        float Iter = Random.Range(0, 1000000);
        OB = GetComponent<OrbitVelocity>();
        GR = GetComponent<Gravity>();
        MainBody = GetComponent<Transform>();
        ASR = GetComponent<SpriteRenderer>();
        ASR.sprite = asteroidTypes[Random.Range(0, asteroidTypes.Length)];
        ASR.color = new Color(Tint * 0.0039f, Tint * 0.0039f, Tint * 0.0039f);
        //OB.ParentWorld = ParentCenter;
        OB.SemiMajor = Random.Range(DistanceMin, DistanceMax);
        OB.OrbitIteration = Iter;
        OB.SemiMinor = Random.Range(OB.SemiMajor * 0.8f, OB.SemiMajor);
        GetComponentInChildren<HealthSystem>().Health = Random.Range(200f, 500f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
