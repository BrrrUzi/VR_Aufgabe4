using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;
    public Vector3 dummy;
    public float count1 = 0;

    void Start()
    {
       
        rend = GetComponent<Renderer>();
        if(fadeOnStart )
        {   
            FadeIn();
            this.transform.position = new Vector3(0f, -1f, 0f);
        }
    }

    public void FadeIn()
    {
        
        Fade(1, 0);
        
    }

    public void FadeOut()
    {
        this.transform.position = dummy;
        Fade(0, 1);

    }


    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            rend.material.SetColor("_Color", newColor);
            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);
        dummy = this.transform.position;
    }
}
