using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BateryManager : MonoBehaviour
{
    [SerializeField] public Light luzLinterna;
    [SerializeField] public bool isOn;
    [SerializeField] private bool isEquiped;
    public float charge;
    public float lostCharge = 0.5f;
    public int chargeMax = 100;
    public int chargeMin = 0;

    FlashlightCharge chargeBehaviour;

    [Header("Visuales")]
    [SerializeField] public TextMeshProUGUI chargePercentage;
    [SerializeField] public Slider chargeSlider;

    private void Start()
    {
        chargeBehaviour = new FlashlightCharge(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isEquiped == true)
        {
            isOn = !isOn;

            if (isOn)
            {
                luzLinterna.enabled = true;
            }

            if (!isOn)
            {
                luzLinterna.enabled = false;
            }
        }

        chargeBehaviour.ArtificialUpdate();

    }

    public void Charge(float amount)
    {
        charge += amount;
        charge = Mathf.Clamp(charge, chargeMin, chargeMax);
        chargeSlider.value = amount;
    }

}
