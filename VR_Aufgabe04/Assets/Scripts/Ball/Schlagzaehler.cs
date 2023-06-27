using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Schlagzaehler : MonoBehaviour
{

    [SerializeField]
    public TextMeshPro zaehlerText;
    [SerializeField]
    public TextMeshPro highScoreText;

    private int zaehler = 0;
    private int highscore = 0;

    private int i = 0;

    private Rigidbody rb;
    [SerializeField]
    public AudioSource schlagSound;
    // Start is called before the first frame update
    void Start()
    {
        setZaehlerText();
        setHighScoreText();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rb.velocity.magnitude > 0) {
            Debug.Log(i++);
        }
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Club")) {
            zaehler++;
            setZaehlerText();
            schlagSound.Play();

        }
        else if (col.gameObject.CompareTag("Loch")) {
            if (zaehler < highscore) {
                highscore = zaehler;
                setHighScoreText();
            }
            
            zaehler = 0;
            setZaehlerText();
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
