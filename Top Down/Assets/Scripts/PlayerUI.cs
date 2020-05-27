using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class PlayerUI : MonoBehaviour
{
    public int maxPlayerHP;
    public int currentPlayerHP;
    bool dead;

    int maxPlayerXP;
    public int currentPlayerXP;

    public PlayerHealthBar playerHealthBar;
    public PlayerXPBar playerXPBar;

    void Start()
    {
        currentPlayerHP = maxPlayerHP;
        playerXPBar.SetXP(currentPlayerXP);
        playerHealthBar.SetMaxHealth(maxPlayerHP);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeHpFromPlayer(20);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GetXPToPlayer(20);
        }

        if (currentPlayerHP <= 0)
        {
            dead = true;
        }
    }

    void TakeHpFromPlayer(int damage)
    {
        currentPlayerHP -= damage;
        playerHealthBar.SetHealth(currentPlayerHP);
    }

    void GetXPToPlayer(int XP)
    {
        currentPlayerXP += 25;
        playerXPBar.SetXP(currentPlayerXP);
    }
}
