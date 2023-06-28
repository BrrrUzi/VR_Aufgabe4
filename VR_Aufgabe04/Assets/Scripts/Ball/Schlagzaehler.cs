using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

struct Bahn {
    public Vector3 bahnOrigin;
    public BahnSchild schild;
}



public class Schlagzaehler : MonoBehaviour
{

    // Sound, der abgespielt wird, wenn der Schläger den Ball berührt
    [SerializeField]
    public AudioSource schlagSound;

    // Text, der die Gesamtanzahl der bisherigen Schläge auf dieser Bahn seit Start anzeigt
    [SerializeField]
    public TextMeshPro zaehlerText;

    // Text, der den Highscore aller bisher beendeten Spiele auf diesem Parcours seit Installation anzeigt
    [SerializeField]
    public TextMeshPro highScoreText;

    // Liste aller Schilder des Parcours, die zu einer Bahn gehören
    [SerializeField]
    public BahnSchild[] schilder;

    // Angabe über Anzahl aller Bahnen dieses Parcours
    [SerializeField]
    public int anzahlBahnen;


    // Zähler aller Schläge auf dem Parcours seit Start des Spiels
    private int zaehler = 0;

    // Highscore aller bisher beendeten Spiele auf diesem Parcours seit Installation des Spiels
    private int highscore = 0;



    // Speicherung der aktuell zu bespielenden Bahn
    private int currentBahn = 0;

    // Speicherung des Schilds und der Startposition zu jeder Bahn
    private Dictionary<int, Bahn> bahnen = new Dictionary<int, Bahn>();

    // Rigidbody des Balls
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= schilder.Length; i++) {
            Bahn bahn = new Bahn();
            bahn.schild = schilder[i - 1];
            bahnen[i] = bahn;
        }

        // Befülle origins mit den jeweiligen Startpositionen des Balls.
        // ...                                                                                                                  // ToDo


        // Lade den Highscore auf dieser Map
        highscore = PlayerPrefs.GetInt("GesamtHighscore");

        // Setze die Texte auf dem Gesamt Schild
        setZaehlerText();
        setHighScoreText();

        rb = GetComponent<Rigidbody>();



        // Teleport Ball zur ersten Bahn
        transform.position = bahnen[1].bahnOrigin;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rb.velocity.magnitude > 0) {
            Debug.Log("is Moving ...");
        }
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Club")) {
            // Spiele den Schlagsound ab
            schlagSound.Play();
            
            // Zähle einen neuen Schlag auf dem Schild mit der Gesamtübersicht
            zaehler++;
            setZaehlerText();

            // Zähle einen neuen Schlag auf dieser Bahn auf dem spezifischen BahnSchild
            bahnen[currentBahn].schild.addSchlag();

            // Wenn maximale Schläge getätig wurden, irgendwas machen
            // ...                                                                                                              // ToDo
        }
        else if (col.gameObject.CompareTag("Loch")) {
            // Setze ggf. den Highscore neu
            bahnen[currentBahn].schild.updateHighscore();

            if (currentBahn < anzahlBahnen) {
                currentBahn++;

                // Teleport Ball zur nächsten Bahn
                transform.position = bahnen[currentBahn].bahnOrigin;
            }else {
                // Setze den Highscore auf dem Schild mit der Gesamtübersich
                if (zaehler < highscore) {
                    highscore = zaehler;
                    setHighScoreText();
                    PlayerPrefs.SetInt("GesagtHighscore", highscore);
                }

                // Teleportiere Spieler vor ein Schild mit der Gesamtübersicht und gib ihm 
                // dort die Möglichkeit, sich zurück zur Lobby zu teleportieren.
            }
            
        }
        else if (col.gameObject.CompareTag("Grass")) {
            // Reset ball to current startpoint
            transform.position = bahnen[currentBahn].bahnOrigin;
        }
    }



    private void setZaehlerText() {
        zaehlerText.text = "Gesamtschläge: " + zaehler;
    }

    private void setHighScoreText() {
        if (highscore < 0) {
            highScoreText.text = "Highscore: " + highScoreText;
        } else {
            highScoreText.text = "Highscore: none";
        }
    }
}
