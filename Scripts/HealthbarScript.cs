using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarScript : MonoBehaviour
{

    [System.NonSerialized]
    public int hp = 10;

    public SpriteRenderer treehp;

    public Sprite healthbar9;
    public Sprite healthbar8;
    public Sprite healthbar7;
    public Sprite healthbar6;
    public Sprite healthbar5;
    public Sprite healthbar4;
    public Sprite healthbar3;
    public Sprite healthbar2;
    public Sprite healthbar1;

    public Sprite healthbar0;
    public GameObject lastGreenCover;
    public GameObject lastGreenCover1;
    public GameObject lastGreenCover2;

    public SpriteRenderer rend;

    GameObject[] grasses;

    public Color grassColor;

    private void Start()
    {
        hp = GameObject.FindGameObjectsWithTag("Tree").Length;
        grasses = GameObject.FindGameObjectsWithTag("Grass");
    }

    // Update is called once per frame
    void Update()
    {

        switch (hp)
        {
            case 9:
                rend.sprite = healthbar9;
                break;
            case 8:
                rend.sprite = healthbar8;
                break;
            case 7:
                rend.sprite = healthbar7;
                break;
            case 6:
                rend.sprite = healthbar6;
                break;
            case 5:
                rend.sprite = healthbar5;
                break;
            case 4:
                rend.sprite = healthbar4;
                break;
            case 3:
                rend.sprite = healthbar3;
                break;
            case 2:
                rend.sprite = healthbar2;
                break;
            case 1:
                rend.sprite = healthbar1;
                break;
            case 0:
                rend.sprite = healthbar0;
                lastGreenCover.SetActive(false);
                lastGreenCover1.SetActive(false);
                lastGreenCover2.SetActive(false);
                FindObjectOfType<GameManagerScript>().gameOver = true;
                foreach (GameObject grass in grasses)
                {
                    grass.GetComponent<SpriteRenderer>().color = grassColor;
                }
                treehp.color = grassColor;
                break;
        }
    }
}
