using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BateryManager : MonoBehaviour
{
    [SerializeField] public Light luzLinterna;
    [SerializeField] public bool isOn;
    [SerializeField] private bool isEquiped;

    public float charge = 100;

    public FlashlightCharge chargeBehaviour;

    [Header("Visuales")]
    [SerializeField] public TextMeshProUGUI chargePercentage;
    [SerializeField] public Slider chargeSlider;

    public static BateryManager instance;

    private void Awake()
    {
        if(instance != null)
            Destroy(instance);
        instance = this;
    }
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

    public void ChargeFlashlight(float amount)
    {
        chargeBehaviour.Charge(amount);
    }
}
