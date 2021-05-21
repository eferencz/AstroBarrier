using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonScript : MonoBehaviour
{

    public GameObject TutorialPage;

    public GameObject StartMenu;

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
        TutorialPage.SetActive(true);

        StartMenu.SetActive(false);
    }

}

