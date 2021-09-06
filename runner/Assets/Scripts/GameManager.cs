using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Camera;
    public bool isGameActive = true;
    public bool LevelUp = false;
    public static GameManager gameManagerInstance;
    public TextMeshProUGUI GameOverText;
    public Button LevelUpBotton;
    public Button StartFromBeginingBotton;

    public int levelnum;
    public int LevelToLoad;

    public int speed;

    private void Awake()
    {
        gameManagerInstance = this;
       LevelToLoad = PlayerPrefs.GetInt("Level");

    }
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive )
        {
            MoveForward(Player,speed);
        }
        if(isGameActive == false && LevelUp == false)
        {
            GameOverText.gameObject.SetActive(true);
        }

    }

    public void MoveForward(GameObject gameObject, int speed)
    {
        gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartLevel()
    {
        LevelToLoad = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(LevelToLoad);

    }

    public void StartFromBeggining()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(1);


    }





}
