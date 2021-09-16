using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Press Esc to quit.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Reset on backspace.
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Scene reloaded.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
