﻿using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour
{

    public int playerMaxHealth;
    public int playerCurrentHealth;

    private bool flashActive;
    public float flashLength;
    private float flashCounter;

    private SpriteRenderer playerSprite;

	// Use this for initialization
	void Start()
    {
        playerCurrentHealth = playerMaxHealth;

        playerSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update()
    {
	    if(playerCurrentHealth <= 0)
        {
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            gameObject.SetActive(false);

        }

        if(flashActive)
        {
            if(flashCounter > flashLength * 0.66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if(flashCounter > flashCounter * 0.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if(flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
	}

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;

        flashActive = true;
        flashCounter = flashLength;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
