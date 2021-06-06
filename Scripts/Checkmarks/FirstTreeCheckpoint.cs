using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstTreeCheckpoint : MonoBehaviour
{
    float charLoadTime = 0.03f;

    Coroutine currentCoroutine;

    int firstTreeClicks = 0;
    public bool firstTree = false;
    public bool firstTreeCompleted = false;
    public GameObject firstTreeScroll;
    public Text firstTreeUIText;
    string firstTreeText = "Oh no! A tree fell!" +
        "\n\nThis deforestation\nhappens across the\nworld all of the time." +
        "\n\nThe world loses 27\nsoccer fields or 48\nfootball fields of\nforests per minute!";
    string firstTreeText2 = "With that much\ndeforestation, the\nEarth is being\ndestroyed, and the\nenvironment is being\npolluted." +
        "\n\nContinue fighting to\nprotect the forests\nand save the world!";

    // Update is called once per frame
    void Update()
    {
        if (firstTree)
        {
            Time.timeScale = 0;
            firstTreeScroll.SetActive(true);
            if (currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(RevealText(firstTreeUIText, firstTreeText));
            }

            if (Input.GetMouseButtonDown(1))
            {
                switch (firstTreeClicks)
                {
                    case 0:
                        firstTreeClicks++;
                        currentCoroutine = StartCoroutine(RevealText(firstTreeUIText, firstTreeText2));
                        break;
                    case 1:
                        firstTreeScroll.SetActive(false);
                        firstTreeCompleted = true;
                        firstTree = false;
                        Time.timeScale = 1;
                        currentCoroutine = null;
                        break;
                }
            }
        }
    }

    IEnumerator RevealText(Text uiText, string text)
    {
        firstTreeUIText.text = "";
        foreach (char c in text)
        {
            uiText.text += c;
            yield return new WaitForSecondsRealtime(charLoadTime);
        }
        yield break;
    }
}
