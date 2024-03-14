using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public static Villager SelectedVillager { get; private set; }
    public TextMeshProUGUI type;

    private void Start()
    {
        type.text = "No Selection";
    }

    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);

        if (SelectedVillager != null)
        {
            CharacterControl.instance.UpdateType(SelectedVillager.GetType().Name);
        }
        else
        {
            CharacterControl.instance.UpdateType("No Selection");
        }
    }

    public static CharacterControl instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateType(string text)
    {
        type.text = text;    }

}
