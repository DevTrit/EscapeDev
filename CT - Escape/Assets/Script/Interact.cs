using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public string triggerName = "";

    public GameObject RedKey;
    public GameObject BlueKey;
    public GameObject GreenKey;

    public GameObject heldItem;
    public string heldItemName;

    public float EnterKeys;

    private GameObject Key;
    private GameObject Door;

    //public GameObject UIKey;

    public GameObject Red1;

    public GameObject Red2;
    public GameObject Green2;
    public GameObject Blue2;

    public GameObject Red3;
    public GameObject Green3;
    public GameObject Blue3;

    public GameObject Panel;
    public GameObject Text;
    public Text text;

    public string ColorCode;
    private GameObject[] CanvasColor;
    private GameObject[] CanvasColor1;
    public float Completed1;
    public float Completed2;
    public float held;

    public int End;


    public float open;



    // Start is called before the first frame update
    void Start()
    {
        Completed1 = 0;
        Completed2 = 0;
        End = 0;
        held = 0;
        open = 0;
        Text.SetActive(false);
        Panel.SetActive(false);
        CanvasColor = GameObject.FindGameObjectsWithTag("Canvas");
        CanvasColor1 = GameObject.FindGameObjectsWithTag("Canvas1");
        CanvasHide();
    }

    // Update is called once per frame
    void Update()
    {

        if(heldItemName == "") {
            held = 0;
        }

        if(EnterKeys == 1)
        {
            Door = GameObject.Find("Door1");
            Destroy(Door);
            Door = GameObject.Find("Lock1");
            Destroy(Door);
            Completed1 = 1;
        }

        if (EnterKeys == 4)
        {
            Door = GameObject.Find("Door2");
            Destroy(Door);
            Door = GameObject.Find("Lock2");
            Destroy(Door);
        }

        if (EnterKeys == 7) {
            Door = GameObject.Find("Door3");
            Destroy(Door);
            Door = GameObject.Find("Lock3");
            Destroy(Door);
        }

        if (triggerName == "Code" || triggerName == "PropCodeMain" || End == 1) {

        } else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            open = 0;
            CanvasHide();
        }

        if(End == 1)
        {
            Invoke("Finish", 25);
        }


        if (Input.GetKeyDown("e"))
        {


            if (triggerName == "Code") 
            {
                open = 1;
                CanvasShow1();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                text.text = "";
                Text.SetActive(false);
                Panel.SetActive(false);
            }


            if(triggerName == "PropCodeMain"){
                open = 1;
                CanvasShow();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                text.text = "";
                Text.SetActive(false);
                Panel.SetActive(false);
            }
            //Room1

            if (triggerName == "RKey1" && heldItemName == "")
            {
                PickUpItem(RedKey, "Red1");
                Key = GameObject.Find("RKey1");
                Destroy(Key);
            }

            if (triggerName == "Lock1" && heldItemName == "Red1")
            {
                RemoveHeldItem();
                EnterKeys += 1;
                Red1.SetActive(true);
                Completed1 = 1;
                text.text = "";
                Text.SetActive(false);
                Panel.SetActive(false);

            }
            
            
            //Room2 
            if (triggerName == "RKey2" && heldItemName == "")
            {
                PickUpItem(RedKey, "Red2");
                Key = GameObject.Find("RKey2");
                Destroy(Key);

            }
            if (triggerName == "BKey2" && heldItemName == "")
            {
                PickUpItem(BlueKey, "Blue2");
                Key = GameObject.Find("BKey2");
                Destroy(Key);
            }
            if (triggerName == "GKey2" && heldItemName == "")
            {
                PickUpItem(GreenKey, "Green2");
                Key = GameObject.Find("GKey2");
                Destroy(Key);
            }









            if (triggerName == "RKey3" && heldItemName == "") {
                PickUpItem(RedKey, "Red3");
                Key = GameObject.Find("RKey3");
                Destroy(Key);

            }
            if (triggerName == "BKey3" && heldItemName == "") {
                PickUpItem(BlueKey, "Blue3");
                Key = GameObject.Find("BKey3");
                Destroy(Key);
            }
            if (triggerName == "GKey3" && heldItemName == "") {
                PickUpItem(GreenKey, "Green3");
                Key = GameObject.Find("GKey3");
                Destroy(Key);
            }




            if (triggerName == "Lock2" && heldItemName == "Red2")
            {
                RemoveHeldItem();
                EnterKeys += 1;
                Red2.SetActive(true);
                Text.SetActive(false);
                Panel.SetActive(false);

            }
            if (triggerName == "Lock2" && heldItemName == "Blue2")
            {
                RemoveHeldItem();
                EnterKeys += 1;
                Blue2.SetActive(true);
                Text.SetActive(false);
                Panel.SetActive(false);
            }
            if (triggerName == "Lock2" && heldItemName == "Green2")
            {
                RemoveHeldItem();
                EnterKeys += 1;
                Green2.SetActive(true);
                Text.SetActive(false);
                Panel.SetActive(false);
            }




            if (triggerName == "Lock3" && heldItemName == "Red3") {
                RemoveHeldItem();
                EnterKeys += 1;
                Red3.SetActive(true);
                Text.SetActive(false);
                Panel.SetActive(false);

            }
            if (triggerName == "Lock3" && heldItemName == "Blue3") {
                RemoveHeldItem();
                EnterKeys += 1;
                Blue3.SetActive(true);
                Text.SetActive(false);
                Panel.SetActive(false);

            }
            if (triggerName == "Lock3" && heldItemName == "Green3") {
                RemoveHeldItem();
                EnterKeys += 1;
                Green3.SetActive(true);
                Text.SetActive(false);
                Panel.SetActive(false);
            }
        }




        
    }

    private void PickUpItem(GameObject itemPrefab, string itemName)
    {
        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = new Vector3(.4f, .5f, 1.5f);
        heldItemName = itemName;
        held = 1;
        text.text = "";
        Text.SetActive(false);
        Panel.SetActive(false);
    }

    private void RemoveHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
        held = 0;
        Text.SetActive(false);
        Panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        triggerName = other.name;
        if (other.name.Contains("ode") && open == 0) {
            Panel.SetActive(true);
            Text.SetActive(true);
            text.text = "E to enter code";
        }

        if (other.name.Contains("ock") && Completed1 == 0 && held == 1) {
            Panel.SetActive(true);
            Text.SetActive(true);
            text.text = "E to enter key";
        }

        if (other.name.Contains("ock") && Completed2 == 0 && held == 1) {
            Panel.SetActive(true);
            Text.SetActive(true);
            text.text = "E to enter key";
        }

        if (other.name.Contains("ey") && held == 0) {
            Panel.SetActive(true);
            Text.SetActive(true);
            text.text = "E to grab key";
        }


        if (other.name.Contains("EndingS"))
        {
            End = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
        Panel.SetActive(false);
        Text.SetActive(false);
        text.text = "";

    }


    private void Finish()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CanvasHide() {
        //CanvasColor = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (GameObject go in CanvasColor) {
            go.SetActive(false);
        }
        foreach (GameObject go in CanvasColor1) {
            go.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void CanvasShow() {
        //CanvasColor = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (GameObject go in CanvasColor) {
            go.SetActive(true);
        }
    }

    private void CanvasShow1() {
        //CanvasColor = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (GameObject go in CanvasColor1) {
            go.SetActive(true);
        }
    }
}
