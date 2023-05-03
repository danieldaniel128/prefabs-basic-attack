using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    // Start is called before the first frame update
    void Awake()
    {
        //healthBar = GetComponent<Image>();
    }
    public void HealthBarMethod(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        Debug.Log("health down");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
