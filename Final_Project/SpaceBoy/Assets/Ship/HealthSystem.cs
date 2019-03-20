using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] public float Health = 100f;
    [SerializeField] GameObject Parent;
    [SerializeField] AudioSource DeathSound;
    [SerializeField] float DelayFactor = 0.1f;
    float FadeOut = 1f;
    public bool IsDead = false;
    bool NextFrame = false;
    public float faction = 1f;
    float HarmTimer = 0;
    bool Played = false;
    // Start is called before the first frame update
    void Start()
    {
        DeathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0)
        {
            if (Played == false)
            {
                DeathSound.Play();
                Played = true;
            }
            StartCoroutine(KillTheParent());


        }
        HarmTimer++;
    }

    public void HurtMe(float dmg)
    {
        Health -= dmg;
        HarmTimer = 0;
    }
    IEnumerator KillTheParent()
    {
        while (FadeOut > 0f)
        {

            Parent.GetComponent<SpriteRenderer>().color = new Color(Parent.GetComponent<SpriteRenderer>().color.r, Parent.GetComponent<SpriteRenderer>().color.g, Parent.GetComponent<SpriteRenderer>().color.b, FadeOut);
            FadeOut -= 0.001f;
            yield return new WaitForSeconds(DelayFactor);
        }
        if (FadeOut <= 0f)
        {
            IsDead = true;
            Parent.gameObject.SetActive(false);
        }
    }

    public bool wasHarmed(float delayCheck)
    {
        if(HarmTimer > delayCheck)
        {
            return false;
        }
        return true;
    }

    public float GetHealth()
    {
        return Health;
    }
}
