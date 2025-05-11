using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterNumber : MonoBehaviour {

    public Text main;
    public GameObject Answer;
    public GameObject Main;
    public float Number;
    public float Digit;
    public GameObject door;
    private GameObject[] CanvasColor1;
    // Start is called before the first frame update
    void Start() {
        main.text = "";
        Number = 0;
        Digit = 0;
        CanvasColor1 = GameObject.FindGameObjectsWithTag("Canvas1");
    }

    // Update is called once per frame
    void Update() {
        if (main.text == "47261") {
            Answer.SetActive(true);
            Main.SetActive(false);
            Number = 1;
            Invoke("Solved", 1);
        }

        if (Digit == 5 && main.text != "47261") {
            Invoke("Clear", 1);

        }
    }

    public void Solved() {
        Destroy(door);
        CanvasHide();
        Digit = 0;
        main.text = "";
    }
    public void One() {
        if (Number == 0) {
            main.text += "1";
            Digit += 1;
        }
    }

    public void Two() {
        if (Number == 0) {
            main.text += "2";
            Digit += 1;
        }
    }
    public void Three() {
        if (Number == 0) {
            main.text += "3";
            Digit += 1;
        }
    }
    public void Four() {
        if (Number == 0) {
            main.text += "4";
            Digit += 1;
        }
    }
    public void Five() {
        if (Number == 0) {
            main.text += "5";
            Digit += 1;
        }
    }
    public void Six() {
        if (Number == 0) {
            main.text += "6";
            Digit += 1;
        }
    }
    public void Seven() {
        if (Number == 0) {
            main.text += "7";
            Digit += 1;
        }
    }
    public void Eight() {
        if (Number == 0) {
            main.text += "8";
            Digit += 1;
        }
    }
    public void Nine() {
        if (Number == 0) {
            main.text += "9";
            Digit += 1;
        }
    }
    public void X() {
        if (Number == 0) {
            Clear();
        }
    }

    private void Clear() {
        Digit = 0;
        main.text = "";
    }
    private void CanvasHide() {
        foreach (GameObject go in CanvasColor1) {
            go.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void CanvasShow1() {
        //CanvasColor = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (GameObject go in CanvasColor1) {
            go.SetActive(true);
        }
    }
}
