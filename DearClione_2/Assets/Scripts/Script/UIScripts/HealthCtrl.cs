using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCtrl : MonoBehaviour
{
    public Player_Info _Info;
    public GameObject Health_100, Health_10_99, Health_0_9;
    public Image HealthBar, HealthBG;
    public List<string> HealthText;
    public string SaveHealth;
    public Sprite[] Index;
    void Start()
    {

    }
    void Update()
    {
        HealthBar.fillAmount = _Info.Player_Health * 0.01f;
        if (HealthBG.fillAmount > HealthBar.fillAmount)
        {
            if (HealthBG.fillAmount - HealthBar.fillAmount > .2f)
                HealthBG.fillAmount -= 0.25f * Time.deltaTime;
            else
                HealthBG.fillAmount -= 0.1f * Time.deltaTime;
        }
        else if (HealthBG.fillAmount < HealthBar.fillAmount)
        {
            HealthBG.fillAmount = HealthBar.fillAmount;
        }
        SaveHealth = (_Info.Player_Health).ToString("000");
        for (int i = 0; i <= 2; i++)
        {
            HealthText[i] = SaveHealth.Substring(i, 1);
        }
        if (HealthBar.fillAmount == 1)
        {
            Health_100.SetActive(true);
            Health_10_99.SetActive(false);
            Health_0_9.SetActive(false);
        }
        else if (HealthBar.fillAmount < 1 && HealthBar.fillAmount > .09f)
        {
            Health_100.SetActive(false);
            Health_10_99.SetActive(true);
            Health_0_9.SetActive(false);
        }
        else
        {
            Health_100.SetActive(false);
            Health_10_99.SetActive(false);
            Health_0_9.SetActive(true);
        }
        for (int i = 0; i <= 9; i++)
        {
            if (HealthText[1] == i.ToString("0"))
            {
                Health_10_99.transform.GetChild(0).GetComponent<Image>().sprite = Index[i];
            }
            if (HealthText[2] == i.ToString("0"))
            {
                Health_10_99.transform.GetChild(1).GetComponent<Image>().sprite = Index[i];
                Health_0_9.transform.GetChild(0).GetComponent<Image>().sprite = Index[i];
            }
        }

    }
}
