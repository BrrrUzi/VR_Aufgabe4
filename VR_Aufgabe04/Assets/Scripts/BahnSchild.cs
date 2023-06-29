using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BahnSchild : MonoBehaviour
{

    private int highscore = 0;
    private int schlaege = 0;

    private TextMeshPro bahnName;
    private TextMeshPro schlaegeZaehler;
    private TextMeshPro highscoreZaehler;

    // Start is called before the first frame update
    void Start()
    {
        bahnName = transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshPro>();
        schlaegeZaehler = transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshPro>();
        highscoreZaehler = transform.GetChild(2).gameObject.GetComponentInChildren<TextMeshPro>();

        setSchlaegeText();
        loadHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHighscore() {
        if (schlaege < highscore || highscore == 0) {
            highscore = schlaege;
            setHighscoreText();
            storeHighscore();
        }
    }

    private void storeHighscore() {
        PlayerPrefs.SetInt(bahnName.text, highscore);
    }

    private void loadHighscore() {
        highscore = PlayerPrefs.GetInt(bahnName.text);
        setHighscoreText();
    }

    public void addSchlag() {
        schlaege++;
        setSchlaegeText();
    }

    public void resetSchlaege() {
        schlaege = 0;
        setSchlaegeText();
    }

    private void setSchlaegeText() {
        schlaegeZaehler.text = "Schläge " + schlaege;
    }

    private void setHighscoreText() {
        if (highscore == 0) {
            highscoreZaehler.text = "Highscore none";
        } else {
            highscoreZaehler.text = "Highscore " + highscore;
        }
    }

    public string getBahnName() {
        return bahnName.text;
    }

}
