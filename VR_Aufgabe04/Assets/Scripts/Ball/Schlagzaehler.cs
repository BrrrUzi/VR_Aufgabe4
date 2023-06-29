using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



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

    // Liste aller Bahnen des Parcours
    [SerializeField]
    public Bahn[] bahnen;


    // Zähler aller Schläge auf dem Parcours seit Start des Spiels
    private int globalZaehler = 0;

    // Highscore aller bisher beendeten Spiele auf diesem Parcours seit Installation des Spiels
    private int globalHighscore = 0;



    // Speicherung der aktuell zu bespielenden Bahn
    private int currentBahn = 0;

    // Speicherung des Schilds und der Startposition zu jeder Bahn
    //[SerializeField]
    //private Dictionary<int, Bahn> bahnen = new Dictionary<int, Bahn>();

    // Rigidbody des Balls
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        Bahn b = bahnen[0];
        b.bahnOrigin = new Vector3(-25.27F, 0.35F, 23.88F);
        bahnen[0] = b;

        // Befülle origins mit den jeweiligen Startpositionen des Balls.
        // ...                                                                                                                  // ToDo

        // Lade den Highscore auf dieser Map
        globalHighscore = PlayerPrefs.GetInt("GesamtHighscore");

        // Setze die Texte auf dem Gesamt Schild
        setZaehlerText();
        setHighScoreText();

        rb = GetComponent<Rigidbody>();



        // Teleport Ball zur ersten Bahn
        transform.position = bahnen[0].bahnOrigin;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rb.velocity.magnitude > 0) {
            //Debug.Log("is Moving ...");
        }
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Club")) {
            // Spiele den Schlagsound ab
            schlagSound.Play();
            
            // Zähle einen neuen Schlag auf dem Schild mit der Gesamtübersicht
            globalZaehler++;
            setZaehlerText();

            // Zähle einen neuen Schlag auf dieser Bahn auf dem spezifischen BahnSchild
            bahnen[currentBahn].schild.addSchlag();

            // Wenn maximale Schläge getätig wurden, irgendwas machen
            // ...                                                                                                              // ToDo
        }
        else if (col.gameObject.CompareTag("Loch")) {

            Debug.Log("Loch getroffen");

            // Setze ggf. den Highscore neu
            bahnen[currentBahn].schild.updateHighscore();

            if (currentBahn < bahnen.Length - 1) {
                currentBahn++;

                // Teleport Ball zur nächsten Bahn
                transform.position = bahnen[currentBahn].bahnOrigin;
            } else {
                // Setze den Highscore auf dem Schild mit der Gesamtübersich
                if (globalZaehler < globalHighscore) {
                    globalHighscore = globalZaehler;
                    setHighScoreText();
                    PlayerPrefs.SetInt("GesagtHighscore", globalHighscore);
                }

                // Teleportiere Spieler vor ein Schild mit der Gesamtübersicht und gib ihm 
                // dort die Möglichkeit, sich zurück zur Lobby zu teleportieren.
            }
            
        }
        else if (col.gameObject.CompareTag("Grass")) {
            // Reset ball to current startpoint
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = bahnen[currentBahn].bahnOrigin;
        }
    }



    private void setZaehlerText() {
        zaehlerText.text = "Gesamtschläge: " + globalZaehler;
    }

    private void setHighScoreText() {
        if (globalHighscore < 0) {
            highScoreText.text = "Highscore: " + highScoreText;
        } else {
            highScoreText.text = "Highscore: none";
        }
    }
}
