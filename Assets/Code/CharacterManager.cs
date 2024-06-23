using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Image shipIcon;  // UI Image component where the ship icon will be displayed
    private Dictionary<string, Sprite> shipIcons = new Dictionary<string, Sprite>();

    void Start()
    {
        // Load all sprites from the sprite sheet
        Sprite[] icons = Resources.LoadAll<Sprite>("shipIcons");
        foreach (Sprite icon in icons)
        {
            shipIcons[icon.name] = icon;
        }
    }

    public void ChangeShipIcon(string iconName)
    {
        if (shipIcons.ContainsKey(iconName))
        {
            shipIcon.sprite = shipIcons[iconName];
        }
        else
        {
            Debug.LogWarning("Icon with name " + iconName + " not found!");
        }
    }
}
