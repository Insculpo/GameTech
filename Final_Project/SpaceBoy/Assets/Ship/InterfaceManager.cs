using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject ShipCam;
    [SerializeField] Wormhole Wormy;
    [SerializeField] Slider HealthIndicator;
    [SerializeField] Slider ImpulseMeter;
    [SerializeField] TextMeshProUGUI WorldCoords;
    [SerializeField] TextMeshProUGUI VelocityIndicator;
    [SerializeField] TextMeshProUGUI ArtifactCounter;
    [SerializeField] TextMeshProUGUI ImpulseCheck;
    [SerializeField] RenderTexture Minimap;
    [SerializeField] GameObject SolarScrew;
    ControlShip PlayerLoc;
    HealthSystem PlayerHP;
    List<SolarHarm> SBurn;
    // Start is called before the first frame update
    void Start()
    {
        PlayerLoc = Player.GetComponent<ControlShip>();
        PlayerHP = Player.GetComponent<HealthSystem>();
        ImpulseMeter.maxValue = PlayerLoc.ImpulseDelay;

    }

    // Update is called once per frame
    void Update()
    {
        SolarHarm[] SBurn = FindObjectsOfType<SolarHarm>();
        foreach (SolarHarm S in SBurn)
        {
            if (S.IsBurning == true)
            {
                SolarScrew.SetActive(true);
            } else
            {
                SolarScrew.SetActive(false);
            }
        }
        ImpulseCheck.text = PlayerLoc.ImpToString();
        WorldCoords.text = PlayerLoc.CoordsToString();
        VelocityIndicator.text = PlayerLoc.VelToString();
        ArtifactCounter.text = Wormy.ArtifactCountToString();
        HealthIndicator.value = PlayerHP.GetHealth();
        ImpulseMeter.value = PlayerLoc.impulseTimer;
    }
}
