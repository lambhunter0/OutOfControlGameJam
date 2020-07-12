using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Enemy[] numberOne;
    private int _enemiesLeft;
    public GameObject winScreen;
    public Pickup[] pickups = new Pickup[3];
    void Start()
    {
        if (numberOne != null)
        {
            _enemiesLeft = numberOne.Length;
        }
    }

    void Update()
    {
        int count = 0;
        foreach (Enemy e in numberOne) 
        {
            if (e == null) 
            {
                count++;
            }
        }
        if (count == _enemiesLeft) 
        {
            winScreen.SetActive(true);
        }
    }

    public void ReloadLevel() 
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1.0f;
    }

    public void LoadMainMenu() 
    {
        Application.LoadLevel(0);
    }

    public void LoadLevel1() 
    {
        Application.LoadLevel(1);
    }
    public void LoadLevel2()
    {
        Application.LoadLevel(2);
    }
    public void LoadControls()
    {
        Application.LoadLevel(4);
    }
    public void LoadLevel3() 
    {
        Application.LoadLevel(3);
    }
    public void LoadWin() 
    { 
        
    }
}
