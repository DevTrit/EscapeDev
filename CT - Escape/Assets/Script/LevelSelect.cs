using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
        public void OnButtonPress(string Play) 
        {
            SceneManager.LoadScene(Play);
        }
}
