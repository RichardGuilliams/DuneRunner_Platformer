using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StaminaGuage : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;
    private float maxStamina;
    private float currentStamina;
    private float lastValue;
    private Color backgroundColor;
    private Color fillColor;
    public Slider staminaBar;
    public GameObject fill;
    public GameObject background;
    private float gaugeWidth;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        backgroundColor = background.GetComponent<Image>().color;
        backgroundColor.a = 0;
        background.GetComponent<Image>().color = backgroundColor;
        fillColor = fill.GetComponent<Image>().color;
        fillColor.a = 0;
        fill.GetComponent<Image>().color = fillColor;
    }

    public void FadeInGuage(float value)
    {
            if(backgroundColor.a < 3)
        {
            backgroundColor.a += value;
            background.GetComponent<Image>().color = backgroundColor;

            fillColor.a += value;
            fill.GetComponent<Image>().color = fillColor;
        }
    }

    public void FadeOutGuage(float value)
    {
        if (backgroundColor.a > 0f)
        {
            backgroundColor.a += value;
            background.GetComponent<Image>().color = backgroundColor;

            fillColor.a += value;
            fill.GetComponent<Image>().color = fillColor;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        staminaBar.maxValue = playerController.stats.stm.currentStat;
        staminaBar.value = playerController.stats.stm.maxStat;
        if (staminaBar.value < staminaBar.maxValue)
        {
            FadeInGuage(.05f);
        }
        else FadeOutGuage(-.05f);
    }
}
