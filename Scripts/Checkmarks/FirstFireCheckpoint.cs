using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstFireCheckpoint : MonoBehaviour
{
    float charLoadTime = 0.03f;

    Coroutine currentCoroutine;

    int firstFireClicks = 0;
    public bool firstFire = false;
    public bool firstFireCompleted = false;
    public GameObject firstFireScroll;
    public Text firstFireUIText;
    string firstFireText = "Excessive wildfires lead to\ndeforestation." +
        "\n\nIn 2021, more than 12 million\nhectares of forests have\nbeen cut down or burned\nworldwide." +
        "\n\nOver the last 2 years, more\nthan 80,000 fires have\ndestroyed the Amazon.";
    string firstFireText2 = "You have to protect\nforests from rampant\nwildfires that cause heavy\ndeforestation and hurt\npeople and their homes." +
        "\n\nYou can follow the wisdom of Smokey the Bear!" +
        "\n\nBe safe.\nSave the forests.";

    // Update is called once per frame
    void Update()
    {
        if (firstFire)
        {
            Time.timeScale = 0;
            firstFireScroll.SetActive(true);
            if (currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(RevealText(firstFireUIText, firstFireText));
            }

            if (Input.GetMouseButtonDown(1))
            {
                switch (firstFireClicks)
                {
                    case 0:
                        firstFireClicks++;
                        currentCoroutine = StartCoroutine(RevealText(firstFireUIText, firstFireText2));
                        break;
                    case 1:
                        firstFireScroll.SetActive(false);
                        firstFireCompleted = true;
                        firstFire = false;
                        Time.timeScale = 1;
                        currentCoroutine = null;
                        break;
                }
            }
        }
    }

    IEnumerator RevealText(Text uiText, string text)
    {
        uiText.text = "";
        foreach (char c in text)
        {
            uiText.text += c;
            yield return new WaitForSecondsRealtime(charLoadTime);
        }
        yield break;
    }
}
