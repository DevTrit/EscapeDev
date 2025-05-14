using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public Text textMeshPro;
    public GameObject Final;
    public Text textMeshPro2;
    public Text textMeshPro3;
    public Text textMeshPro4;
    public Text textMeshPro5;
    public Text textMeshPro6;
    public Text textMeshPro7;
    public float typingSpeed = 0.075f;
    public GameObject End;
    public GameObject End2;
    public GameObject End3;
    public GameObject End4;
    public GameObject End5;

    private string fullText;

    public GameObject Creator;

    public int Number;

    public bool LastStory;

    void Start()
    {
        LastStory = false;
    }

    void OnTriggerEnter(Collider other)
    {
        LastStory = true;
        Final.SetActive(true);
        fullText = textMeshPro.text; // Store the full text
        textMeshPro.text = string.Empty; // Clear the text
        StartCoroutine(TypeText());// Start typing animation
        Invoke("Wait", 1.5f);
        Number = 0;
    }

    // Coroutine to simulate typing effect
    IEnumerator TypeText()
    {
        if(Number == 0) {
            foreach (char letter in fullText)
        {
            textMeshPro.text += letter; // Append each letter to the text
            yield return new WaitForSeconds(typingSpeed); // Wait for the specified duration
        } 
        } else
        {
            foreach (char letter in fullText)
            {
                textMeshPro5.text += letter; // Append each letter to the text
                yield return new WaitForSeconds(typingSpeed); // Wait for the specified duration
            }
        }
        
    }

    public void Wait()
    {
        fullText = textMeshPro2.text;
        textMeshPro.text = string.Empty;
        StartCoroutine(TypeText());
        Invoke("Wait2", 2.5f);
    }

    public void Wait2()
    {
        fullText = textMeshPro3.text;
        textMeshPro.text = string.Empty;
        StartCoroutine(TypeText());
        Invoke("Wait3", 3);
    }

    public void Wait3()
    {
        fullText = textMeshPro4.text;
        textMeshPro.text = string.Empty;
        StartCoroutine(TypeText());
        Invoke("Wait4", 2);
    }

    public void Wait4()
    {
        Number = 1;
        typingSpeed = .125f;
        Creator.SetActive(true);
        Final.SetActive(false);
        fullText = textMeshPro5.text; // Store the full text
        textMeshPro5.text = string.Empty;
        StartCoroutine(TypeText());
        Invoke("Wait5", 4.5f);
    }

    public void Wait5()
    {
        fullText = textMeshPro6.text;
        textMeshPro5.text = string.Empty;
        StartCoroutine(TypeText());
        Invoke("Wait6", 4.5f);
    }

    public void Wait6()
    {
        fullText = textMeshPro7.text;
        textMeshPro5.text = string.Empty;
        StartCoroutine(TypeText());
        Invoke("Clear", 4.5f);
    }



    public void Clear()
    {
        textMeshPro.text = string.Empty;
        End.SetActive(true);
        Invoke("END", 1.5f);
    }

    public void END()
    {
        End2.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Final.SetActive(false);
        Creator.SetActive(false);
        Invoke("SHOW", 1.5f);
    }

    public void SHOW()
    {
        End4.SetActive(true);
        End3.SetActive(true);
        End5.SetActive(true);
        Invoke("HIDE", Random.Range(.1f, .5f));
    }

    public void HIDE()
    {
        End3.SetActive(false);
        Invoke("SHOW", Random.Range(1,3));
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }
}
