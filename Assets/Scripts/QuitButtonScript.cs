using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    public StartButtonScript restartGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCLick()
    {

        Application.Quit();

        Debug.Log("You have quit the game!");

        restartGame.StartingMenu();
    }
}
