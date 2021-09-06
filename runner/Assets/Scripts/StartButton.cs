using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    int LevelToLoad;

    private void Awake()
    {

        LevelToLoad = PlayerPrefs.GetInt("Level");

        if(LevelToLoad == 0)
        {
            // First time
            PlayerPrefs.SetInt("Level", 1);
            LevelToLoad = 1;
        }
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

}
