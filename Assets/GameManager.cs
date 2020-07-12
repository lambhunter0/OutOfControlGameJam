using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadLevel() 
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1.0f;
    }
}
