using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Button spawnButton;
    public Text timer;
    public float timerTime=5;
    float newTimerTime;

    int maxPlayerXP;
    public int currentPlayerXP;

    public PlayerXPBar playerXPBar;

    void Start()
    {
        //spawnButton.gameObject.SetActive(false);
        newTimerTime = timerTime;
        //playerXPBar.SetXP(currentPlayerXP);
    }

    void Update()
    {
        if (BlackBoard.player.isDead)
        {
            timer.gameObject.SetActive(true);
            timer.text = "You are Dead! Please wait " + newTimerTime.ToString("f0") + " Seconds To Spawn";
            newTimerTime -= Time.deltaTime;
            if (newTimerTime <= 0)
            {
                timerTime = Mathf.Clamp(timerTime, 0, timerTime);
                spawnButton.gameObject.SetActive(true);
                timer.text = "You can spawn";
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
        spawnButton.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        BlackBoard.player.isDead = false;
        BlackBoard.player.currentPlayerHP = BlackBoard.player.maxPlayerHP * 0.5f;
        BlackBoard.player.playerHealthBar.SetHealth(BlackBoard.player.currentPlayerHP);
        //BlackBoard.player.rend = GetComponent<Renderer>();
        //BlackBoard.player.rend.enabled = true;
        //BlackBoard.player.rend.sharedMaterial = BlackBoard.player.alive;
        if(timerTime < 60)
        {
            if (timerTime >= 30)
            {
                timerTime += 2;
            }
            else
            {
                timerTime += 5;
            }
        }
        newTimerTime = timerTime;
    }
}
