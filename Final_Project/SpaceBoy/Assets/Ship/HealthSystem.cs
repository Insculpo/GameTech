using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float Health = 100f;
    [SerializeField] GameObject ThisObject;
    float FadeOut = 1f;
    public bool IsDead = false;
    bool NextFrame = false;
    // Start is called before the first frame update
    void Start()
    {
        ThisObject = gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0)
        {
            FadeOut -= 0.05f;
            GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, FadeOut);
            if(NextFrame == true)
            {
                KillTheKids();
                ThisObject.SetActive(false);
            }
            if (FadeOut <= 0)
            {
                IsDead = true;
                NextFrame = true;
            }
        }
    }

    public void HurtMe(float dmg)
    {
        Health -= dmg;
    }

    void KillTheKids()
    {
        for(int c = 0; c < transform.childCount; c++)
        {
            transform.GetChild(c).gameObject.SetActive(false);
        }
    }

    public float GetHealth()
    {
        return Health;
    }
}
