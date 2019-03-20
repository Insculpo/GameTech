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
    [SerializeField] HealthSystem PlayerHP;
    [SerializeField] WeaponController WeaponData;
    [SerializeField] TextMeshProUGUI MissileCounter;
    [SerializeField] TextMeshProUGUI RailgunCounter;
    [SerializeField] TextMeshProUGUI WarningFlasher;
    float warningFlash = 0;
    float burnFlash = 0;
    float iterator = 0;
    List<SolarHarm> SBurn;
    // Start is called before the first frame update
    void Start()
    {
        PlayerLoc = Player.GetComponent<ControlShip>();
        WeaponData = Player.GetComponent<WeaponController>();
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
              //  StartCoroutine(Flash());
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
        MissileCounter.text = WeaponData.MissileAmmo();
        RailgunCounter.text = WeaponData.RailgunAmmo();
    }

    IEnumerator Flash()
    {
        while (SolarScrew.activeSelf == true || iterator < 1000000f)
        {
            burnFlash = 1f;
            warningFlash = 1f;
            SpriteRenderer Flashy = SolarScrew.GetComponent<SpriteRenderer>();
            Flashy.color = new Color(Flashy.color.r, Flashy.color.g, Flashy.color.b, burnFlash);
            WarningFlasher.color = new Color(WarningFlasher.color.r, WarningFlasher.color.g, WarningFlasher.color.b, warningFlash);
            iterator++;
            yield return new WaitForEndOfFrame();
        }
    }
}
