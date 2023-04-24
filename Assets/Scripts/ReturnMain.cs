using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnMain : MonoBehaviour
{

    // Start is called before the first frame update
    public void LoadMainMenu()
    {   
        SceneManager.LoadScene("Start");
    }
}
