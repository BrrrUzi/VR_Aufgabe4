using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

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

    [SerializeField]
    public XROrigin player;


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

    bool hasCollided = false;

    GameObject club;

    Vector3 origin;

    Color originalColor;


    // Start is called before the first frame update
    void Start()
    {
        // Befülle origins mit den jeweiligen Startpositionen des Balls.
        // ...                                                                                                                  // ToDo

        // Lade den Highscore auf dieser Map
        globalHighscore = PlayerPrefs.GetInt("GesamtHighscore");

        // Setze die Texte auf dem Gesamt Schild
        setZaehlerText();
        setHighScoreText();

        rb = GetComponent<Rigidbody>();

        originalColor = GetComponent<Renderer>().material.color;

        // Teleport Ball zur ersten Bahn
        teleportBall();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.velocity *= 0.9F;
        if (rb.velocity.magnitude > 0) {
            //Debug.Log("is Moving ...");
        }

        if (hasCollided && rb.velocity.magnitude < 0.05F) 
        {
            club.GetComponent<Collider>().isTrigger = false;
            GetComponent<Renderer>().material.color = originalColor;

            if (bahnen[currentBahn].schild.getSchlaege() == 15) {
                currentBahn++;
                teleportBall();
                teleportPlayer();
            }
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.position = origin;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        */
    }
    /*private void OnTriggerEnter(Collider other){
        if (other.tag == "Club"){
            GetComponent<Rigidbody>().velocity = other.GetComponent<ClubHead>().getVelocity() * 1.25F;
        }
    }*/
    private void OnCollisionEnter(Collision col) {

        if (col.gameObject.CompareTag("Club")) {
            // Spiele den Schlagsound ab
            schlagSound.Play();
            //xr.SendHapticImpulse(0.7f, 2f);
            
        
            // Zähle einen neuen Schlag auf dem Schild mit der Gesamtübersicht
            globalZaehler++;
            setZaehlerText();

            // Zähle einen neuen Schlag auf dieser Bahn auf dem spezifischen BahnSchild
            bahnen[currentBahn].schild.addSchlag();

            // Wenn maximale Schläge getätig wurden, irgendwas machen
            // ...                                           

            club = col.gameObject;
            club.GetComponent<Collider>().isTrigger = true;
            GetComponent<Renderer>().material.color = new Color(0, 0.45F, 1F);
            hasCollided = true;
            Vector3 diff = (transform.position - col.transform.position);
            rb.velocity = club.GetComponent<ClubHead>().getVelocity() * 2F;
        }
        else if (col.gameObject.CompareTag("Loch")) {

            Debug.Log("Loch getroffen");

            // Setze ggf. den Highscore neu
            bahnen[currentBahn].schild.updateHighscore();

            if (currentBahn < bahnen.Length - 1) {
                currentBahn++;

                // Teleport Ball zur nächsten Bahn
                teleportBall();
                teleportPlayer();
            } else {
                // Setze den Highscore auf dem Schild mit der Gesamtübersich
                 player.transform.position = new Vector3(0, 0, 29);
                if ((globalZaehler < globalHighscore || globalHighscore == 0) && globalZaehler > 0) {
                    globalHighscore = globalZaehler;
                    setHighScoreText();
                    PlayerPrefs.SetInt("GesamtHighscore", globalHighscore);
                }

                // Teleportiere Spieler vor ein Schild mit der Gesamtübersicht und gib ihm 
                // dort die Möglichkeit, sich zurück zur Lobby zu teleportieren.
            }
            
        }
        else if (col.gameObject.CompareTag("Grass")) {
            // Reset ball to current startpoint
            teleportBall();
        }
    }



    private void teleportBall() {
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = Vector3.zero;
        transform.position = bahnen[currentBahn].bahnOrigin;
    }

    private void teleportPlayer() {
        player.transform.position = bahnen[currentBahn].playerSpawnPoint;
    }



    private void setZaehlerText() {
        zaehlerText.text = "Gesamtschläge: " + globalZaehler;
    }

    private void setHighScoreText() {
        if (globalHighscore > 0) {
            highScoreText.text = "Highscore: " + globalHighscore;
        } else {
            highScoreText.text = "Highscore: none";
        }
    }
}
