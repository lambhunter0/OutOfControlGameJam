using UnityEngine;
using UnityEngine.UI;

public class RadialFill : MonoBehaviour
{


    public Image fillImage;
    public Text displayText;


    protected float maxValue = 1f, minValue = 0f;


   
    public float CurrentValue
    {
        get
        {
            return _currentValue;
        }
        set
        {
            // Ensure the passed value falls within min/max range
            _currentValue = Mathf.Clamp(value, minValue, maxValue);

            // Calculate the current fill percentage and display it
            float fillPercentage = _currentValue / maxValue;
            fillImage.fillAmount = fillPercentage;
            displayText.text = (fillPercentage * 100).ToString("0") + "%";
        }
    }

    void Start()
    {
        CurrentValue = 0f;
    }

    void Update()
    {
        //CurrentValue += 0.0086f;
    }
    private float _currentValue = 0f;
}