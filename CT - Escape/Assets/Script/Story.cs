using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour {
    public Text textMeshPro;
    public Text textMeshPro2;
    public Text textMeshPro3;
    public Text textMeshPro4;
    public Text textMeshPro5;
    public float typingSpeed;

    private string fullText;

    private void Start() {
        fullText = textMeshPro.text; // Store the full text
        textMeshPro.text = string.Empty; // Clear the text
        StartCoroutine(TypeText());// Start typing animation
        Invoke("Wait", 5.5f);
    }

    // Coroutine to simulate typing effect
    IEnumerator TypeText() {
        foreach (char letter in fullText) {
            textMeshPro.text += letter; // Append each letter to the text
            yield return new WaitForSeconds(typingSpeed); // Wait for the specified duration
        }
    }

    public void Wait() {
        fullText = textMeshPro2.text;
        textMeshPro.text = string.Empty;
        StartCoroutine(TypeText());
        Invoke("Wait2", 4.5f);
    }

    public void Wait2() {
        fullText = textMeshPro3.text;
        textMeshPro.text = string.Empty;
        StartCoroutine(TypeText());
        Invoke("Wait3", 5);
    }

    public void Wait3() {
        fullText = textMeshPro4.text;
        textMeshPro.text = string.Empty;
        StartCoroutine(TypeText());
        Invoke("Wait4", 4.5f);
    }

    public void Wait4() {
        fullText = textMeshPro5.text;
        textMeshPro.text = string.Empty;
        StartCoroutine(TypeText());
        Invoke("Clear", 4.5f);
    }

    public void Clear() {
        textMeshPro.text = string.Empty;
    }
}
