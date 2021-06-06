using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsButtonScript : MonoBehaviour
{
    public GameObject actionsPage;

    public void Pause()
    {
        Time.timeScale = 0;
        actionsPage.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        actionsPage.SetActive(false);
    }

}
