using UnityEngine;
using UnityEngine.UI;

public class HealthBarSliderController : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("UI Components")]
    public Slider healthSlider;

    [Header("Color Gradient")]
    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.red;

    private Image fillImage;

    void Start()
    {
        currentHealth = maxHealth;

        // Get the Fill image automatically from the slider
        fillImage = healthSlider.fillRect.GetComponent<Image>();

        healthSlider.maxValue = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10f);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(5f);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
        float healthPercent = currentHealth / maxHealth;

        if (fillImage != null)
            fillImage.color = Color.Lerp(lowHealthColor, fullHealthColor, healthPercent);
    }
}
