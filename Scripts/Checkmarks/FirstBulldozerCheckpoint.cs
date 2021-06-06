using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstBulldozerCheckpoint : MonoBehaviour
{
    float charLoadTime = 0.03f;

    Coroutine currentCoroutine;

    public bool firstBulldozer = false;
    public bool firstBulldozerCompleted = false;
    public GameObject firstBulldozerScroll;
    public Text bulldozerUIText;
    string text = "Bulldozers have large\ndirt-pushing blades that\ncan demolish natural\nland and forests." +
        "\n\nOveruse of bulldozers\nfor clearing farmland\nerodes land and\ncontributes to\ndeforestation.";

    // Update is called once per frame
    void Update()
    {
        if (firstBulldozer)
        {
            Time.timeScale = 0;
            firstBulldozerScroll.SetActive(true);
            if (currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(RevealText(bulldozerUIText, text));
            }

            if (Input.GetMouseButtonDown(1))
            {
                firstBulldozerScroll.SetActive(false);
                firstBulldozerCompleted = true;
                firstBulldozer = false;
                Time.timeScale = 1;
                currentCoroutine = null;
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
