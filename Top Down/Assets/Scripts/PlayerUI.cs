using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text timer;
    public float timerTime=10;
    public Button spawnButton;

    int maxPlayerXP;
    public int currentPlayerXP;

    public PlayerXPBar playerXPBar;

    void Start()
    {
        spawnButton.gameObject.SetActive(false);
        playerXPBar.SetXP(currentPlayerXP);
    }

    void Update()
    {
        if (BlackBoard.player.isDead)
        {
            timer.gameObject.SetActive(true);
            timer.text = "You are Dead! Please wait " + timerTime.ToString("f0") + " Seconds To Spawn";
            timerTime-=Time.deltaTime;
            if (timerTime <= 0)
            {
                timer.text = "You Can Spawn";
                timerTime = Mathf.Clamp(timerTime, 0, timerTime);
                spawnButton.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GetXPToPlayer(20);
        }
    }

    void GetXPToPlayer(int XP)
    {
        currentPlayerXP += 25;
        playerXPBar.SetXP(currentPlayerXP);
    }

    public void RespawnPlayer()
    {
        timer.gameObject.SetActive(false);
        BlackBoard.player.isDead = false;
        BlackBoard.player.currentPlayerHP = BlackBoard.player.maxPlayerHP * 0.5f;
        BlackBoard.player.playerHealthBar.SetHealth(BlackBoard.player.currentPlayerHP);
        BlackBoard.player.rend = GetComponent<Renderer>();
        BlackBoard.player.rend.enabled = true;
        BlackBoard.player.rend.sharedMaterial = BlackBoard.player.alive;
        spawnButton.gameObject.SetActive(false);
        timerTime = 10;
    }
}
