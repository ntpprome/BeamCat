using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void start()
    {
         SceneManager.LoadScene("GamePlay");
    }

    public void options()
    {
        
    }
    
    public void quit()
    {
        Application.Quit();
    }
}
