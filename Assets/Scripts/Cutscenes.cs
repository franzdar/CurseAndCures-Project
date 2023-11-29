using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private string cutsceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isFlowerObtained && cutsceneName == "Chase")
        {
            StartCoroutine(ShowCutscene(this.gameObject, 3f));
        }

        if(gameManager.isGameFinished && cutsceneName == "End")
        {
            StartCoroutine(ShowCutscene(this.gameObject, 3f));
        }    
    }

    public IEnumerator FadeOut(GameObject cutscene, float fadeTime)
    {
        // fade from opaque to transparent
        while (cutscene.GetComponent<CanvasGroup>().alpha > 0)
        {
            cutscene.GetComponent<CanvasGroup>().alpha -= 1 * Time.deltaTime / fadeTime;
            yield return null;
        }
        cutscene.GetComponent<CanvasGroup>().alpha = 0f;
        cutscene.SetActive(false);
        Debug.Log("Faded Out");
    }

    public IEnumerator ShowCutscene(GameObject cutscene, float fadeTime)
    {
        cutscene.SetActive(true);

        // fade from transparent to opaque
        while (cutscene.GetComponent<CanvasGroup>().alpha < 1)
        {
            cutscene.GetComponent<CanvasGroup>().alpha += Time.deltaTime / fadeTime;
            yield return null;
        }
        cutscene.GetComponent<CanvasGroup>().alpha = 1f;
        Debug.Log("Faded In");

        yield return new WaitForSeconds(fadeTime);

        // fade from opaque to transparent
        while (cutscene.GetComponent<CanvasGroup>().alpha > 0)
        {
            cutscene.GetComponent<CanvasGroup>().alpha -= 1 * Time.deltaTime / fadeTime;
            yield return null;
        }
        cutscene.GetComponent<CanvasGroup>().alpha = 0f;
        cutscene.SetActive(false);
        Debug.Log("Faded Out");
    }
}
