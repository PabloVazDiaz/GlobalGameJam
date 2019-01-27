using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text text;
    public float timeLeft;
    public Image clock;
    public Image slider;
    public bool win;

    private float minutes;
    private float seconds;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        UpdateLevelTimer(timeLeft);
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        text.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        if (minutes == 0 && seconds == 0)
        {
            win = true;
        }
    }

    public void FillClock(float amount)
    {
        clock.fillAmount += amount;
        if (clock.fillAmount >= 1)
        {
            clock.fillAmount = 0;
        }
    }


    public void UpdateSlider(float amount)
    {
        slider.fillAmount = amount;
    }


}
