using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float Health = 100f;
    [SerializeField] GameObject Parent;
    float FadeOut = 1f;
    public bool IsDead = false;
    bool NextFrame = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0)
        {
                StartCoroutine(KillTheParent());
        }
    }

    public void HurtMe(float dmg)
    {
        Health -= dmg;
    }
    IEnumerator KillTheParent()
    {
        while (FadeOut > 0)
        {

            FadeOut -= 0.05f;
            if (Parent.GetComponent<SpriteRenderer>() != null)
            {
                Parent.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, FadeOut);
            } else
            {
                Debug.Log("Object missing sprite renderer! " + Parent.gameObject.name);
            }
            yield return null;
        }
        Parent.gameObject.SetActive(false);
    }
        

    public float GetHealth()
    {
        return Health;
    }
}
