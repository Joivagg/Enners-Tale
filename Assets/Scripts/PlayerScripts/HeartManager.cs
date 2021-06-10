using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite threeQuarterHeart;
    public Sprite halfFullHeart;
    public Sprite oneQuarterHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for(int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            //hearts[i].sprite = fullHeart;
        }
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RuntimeValue / 4;
        for (int i = 0; i < heartContainers.RuntimeValue; i ++)
        {
            float currHeart = Mathf.Ceil(tempHealth - 1);
            if(i <= tempHealth - 1)
            {
                // Full Heart
                hearts[i].sprite = fullHeart;
            }
            else if(i >= tempHealth)
            {
                // Empty Heart
                hearts[i].sprite = emptyHeart;
            }
            else if(i == currHeart && (tempHealth % 1) == 0.50)
            {
                // Half Full Heart
                hearts[i].sprite = halfFullHeart;
            }
            else if(i == currHeart && (tempHealth % 1) == 0.25)
            {
                // 1/4 Heart
                hearts[i].sprite = oneQuarterHeart;
            }
            else
            {
                // 3/4 Heart
                hearts[i].sprite = threeQuarterHeart;
            }
        }
    }
}
