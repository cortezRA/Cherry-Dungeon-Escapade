using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    // Start is called before the first frame update
    private void Update()
    {   
        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0;

        }

        if (Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Start");

        }

    }
}
