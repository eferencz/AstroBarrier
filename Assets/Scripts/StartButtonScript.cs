using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{

    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;

    public GameObject StartMenu;

    public GameObject MainMenu;

    public GameObject Tutorial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        Level1.SetActive(true);

        StartMenu.SetActive(false);

        MainMenu.SetActive(true);

        Tutorial.SetActive(false);
    }

    public void StartingMenu()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Level4.SetActive(false);
        StartMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
