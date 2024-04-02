using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public BaseCharacter character;
    public Image healthBarFill;

    private void Update()
    {
        if (character != null && healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)character.currentHealth / character.maxHealth;
        }
    }
}
