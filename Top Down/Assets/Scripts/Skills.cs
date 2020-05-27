using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public Button skill_1;
    public Button skill_2;
    public Button skill_3;

    public Button skill1;
    public Button skill2;
    public Button skill3;


    public Image gray;

    void Start()
    {
        Time.timeScale = 0;
        skill_1.gameObject.SetActive(true);
        skill_2.gameObject.SetActive(true);
        skill_3.gameObject.SetActive(true);

        gray.gameObject.SetActive(true);

        skill1.gameObject.SetActive(false);
        skill2.gameObject.SetActive(false);
        skill3.gameObject.SetActive(false);
    }

    public void Skill1()
    {
        StartGame();
        skill1.gameObject.SetActive(true);
        skill2.gameObject.SetActive(false);
        skill3.gameObject.SetActive(false);
    }

    public void Skill2()
    {
        StartGame();
        skill1.gameObject.SetActive(false);
        skill2.gameObject.SetActive(true);
        skill3.gameObject.SetActive(false);
    }

    public void Skill3()
    {
        StartGame();
        skill1.gameObject.SetActive(false);
        skill2.gameObject.SetActive(false);
        skill3.gameObject.SetActive(true);
    }

    void StartGame()
    {
        Time.timeScale = 1;
        skill_1.gameObject.SetActive(false);
        skill_2.gameObject.SetActive(false);
        skill_3.gameObject.SetActive(false);

        gray.gameObject.SetActive(false);
    }
}
