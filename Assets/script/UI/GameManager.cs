using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Dynamic;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool isPaused = false;
    public GameObject menu;

    private Image SaveLog;

    void Start()
    {
        SaveLog = menu.transform.Find("SaveLog").GetComponent<Image>();
        ContinueGame();
    }

    void Awake()
    {
        Pause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    private void Pause()
    {
        isPaused = true;
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    private void UnPause()
    {
        SaveLog.transform.localScale = new Vector3(0,0,0);
        isPaused = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ContinueGame()
    {
        UnPause();
    }

    public void SaveGame()
    {
        PlayerStatus ps = player.GetComponent<PlayerStatus>();
        //´æµµ£º

        PlayerPrefs.SetString("SceneName",SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("HP_Save",ps.MyCurrentHealth);

        Debug.Log("PlayerHP:"+PlayerPrefs.GetString("HP_Save"));
        Debug.Log("SceneName:"+PlayerPrefs.GetString("SceneName"));
        SaveLog.transform.localScale = new Vector3(1,1,1);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {   
        SceneManager.LoadScene(PlayerPrefs.GetString("SceneName"));
    }

    public void MainMenu()
    {

        SceneManager.LoadScene("0");

    }

    
}

