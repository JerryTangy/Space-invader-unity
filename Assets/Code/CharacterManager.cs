using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    private int index;
    private SpriteRenderer spaceShipSR;

    private int money;

    private int health;

    [Header("Player Config")]
    public GameObject spaceship;
    public Sprite[] spaceShipSprites;
    [Header("Enemy Config")]
    public Sprite[] enemySprites;
    [Header("Meteors")]
    public Sprite[] Meteors;

    
    void Start()
    {
        spaceShipSR = spaceship.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            if (index >= spaceShipSprites.Length)
            {
                index = 0;
            }
            ChangeSpaceship();
        }
    }

    void ChangeSpaceship()
    {
    spaceShipSR.sprite = spaceShipSprites[index];
    }
}  