using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{

    public float Count;

    public float Correct;

    public GameObject GreenKey; //Real Key

    public GameObject G1;
    public GameObject G2;
    public GameObject G3;
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;
    public GameObject R1;
    public GameObject R2;
    public GameObject R3;

    public GameObject PropCode;

    private GameObject[] CanvasColor;

    public GameObject Player;

    public bool ColorSolvedCorrect;

    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        Correct = 0;
        ColorSolvedCorrect = false;

        CanvasColor = GameObject.FindGameObjectsWithTag("Canvas");
        //PropCode.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int OpenPanels = Player.GetComponent<Interact>().OpenPanels;
        if(OpenPanels == 0)
        {
            Count = 0;
            Correct = 0;
        }
    }

    public void Red() {
        Count += 1;

        if (Count == 1) {
            R1.SetActive(true);
        }
        if (Count == 2) {
            R2.SetActive(true);
            Correct += 1;
        }
        if (Count == 3) {
            R3.SetActive(true);
        }
    }
    public void Green() {
        Count += 1;

        if (Count == 1) {
            G1.SetActive(true);
            Correct += 1;
        }
        if (Count == 2) {
            G2.SetActive(true);
        }
        if (Count == 3) {
            G3.SetActive(true);
        }


    }
    public void Blue() {
        Count += 1;

        if (Count == 1) {
            B1.SetActive(true);
            Correct += 1;
        }
        if (Count == 2) {
            B2.SetActive(true);
        }
        if (Count == 3) {
            B3.SetActive(true);
            Correct += 1;
        }
    }
    public void Check() {
        if (Correct < 3) {
            Invoke("Incorrect", .75f);
            Invoke("Blank", 1.5f);
        }
        if(Count == 3 && Correct == 3) {
            Invoke("Solved", .75f);
            Invoke("Hide", 1.5f);
        }
    }

    public void Blank() {
        G1.SetActive(false);
        G2.SetActive(false);
        G3.SetActive(false);
        B1.SetActive(false);
        B2.SetActive(false);
        B3.SetActive(false);
        R1.SetActive(false);
        R2.SetActive(false);
        R3.SetActive(false);
    }
    public void Incorrect() {
        Count = 0;
        Correct = 0;
        G1.SetActive(false);
        G2.SetActive(false);
        G3.SetActive(false);
        B1.SetActive(false);
        B2.SetActive(false);
        B3.SetActive(false);
        R1.SetActive(true);
        R2.SetActive(true);
        R3.SetActive(true);
    }

    public void Solved() {
        Count = 0;
        Correct = 0;
        G1.SetActive(true);
        G2.SetActive(true);
        G3.SetActive(true);
        B1.SetActive(false);
        B2.SetActive(false);
        B3.SetActive(false);
        R1.SetActive(false);
        R2.SetActive(false);
        R3.SetActive(false);
        PropCode.SetActive(false);
    }

    public void Hide() {
        G1.SetActive(false);
        G2.SetActive(false);
        G3.SetActive(false);
        B1.SetActive(false);
        B2.SetActive(false);
        B3.SetActive(false);
        R1.SetActive(false);
        R2.SetActive(false);
        R3.SetActive(false);
        ColorSolvedCorrect = true;
        CanvasHide();
    }

    private void CanvasHide() {
        //CanvasColor = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (GameObject go in CanvasColor) {
            go.SetActive(false);
        }
    }
}
