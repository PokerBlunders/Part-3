using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterSelector : MonoBehaviour
{
    private BaseCharacter selectedCharacter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosition);
            foreach (Collider2D collider in colliders)
            {
                BaseCharacter character = collider.GetComponent<BaseCharacter>();
                if (character != null)
                {
                    SelectCharacter(character);
                    break;
                }
            }
        }
    }

    private void SelectCharacter(BaseCharacter character)
    {
        if (selectedCharacter != null)
        {
            selectedCharacter.DeselectCharacter();
        }
            selectedCharacter = character;
            selectedCharacter.SelectCharacter();
    }
}
