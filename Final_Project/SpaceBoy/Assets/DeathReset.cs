using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathReset : MonoBehaviour
{
    [SerializeField] ControlShip CShip;
    [SerializeField] HealthSystem PlayerHP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        if (PlayerHP.IsDead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
