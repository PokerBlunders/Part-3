using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    //public TMPro.TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;

    public static Villager SelectedVillager { get; private set; }

    public TMP_Dropdown dropdown;

    public List<Villager> villagers;

    private void Start()
    {
        Instance = this;
    }

    public void OnDropdownValueChanged(int value)
    {
        SetSelectedVillager(villagers[value]);
        //currentSelection.text = SelectedVillager.ToString();
    }

        public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        //Instance.currentSelection.text = villager.ToString();
    }
}
