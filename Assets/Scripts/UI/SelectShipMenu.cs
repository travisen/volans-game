﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SelectShipMenu : MonoBehaviour
{

    public Button mainMenu,
                  startGame,
                  selectFrigate,
                  selectCruiser,
                  selectBattleship;

    public GameObject notificationPanel;
    public Text notification;

    private bool isSelectionMade = false;


    // Use this for initialization
    void Start()
    {
        Button btn = mainMenu.GetComponent<Button>();
        btn.onClick.AddListener(DoSelectMainMenu);

        btn = startGame.GetComponent<Button>();
        btn.onClick.AddListener(DoSelectStartGame);

        btn = selectFrigate.GetComponent<Button>();
        btn.onClick.AddListener(DoSelectFrigate);

        btn = selectCruiser.GetComponent<Button>();
        btn.onClick.AddListener(DoSelectCruiser);

        btn = selectBattleship.GetComponent<Button>();
        btn.onClick.AddListener(DoSelectBattleship);


    }

    void DisplayNotification(string text)
    {
        notification.text = text;
        Debug.Log(text);
        notificationPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DoSelectFrigate()
    {
        string ship_type = "fighter";
        SaveShipType(ship_type);
        isSelectionMade = true;

        DisplayNotification("Fighter Selected!");
    }

    void DoSelectCruiser()
    {
        string ship_type = "cruiser";
        SaveShipType(ship_type);
        isSelectionMade = true;

        DisplayNotification("Cruiser Selected!");
    }

    void DoSelectBattleship()
    {
        string ship_type = "battleship";
        SaveShipType(ship_type);
        isSelectionMade = true;

        DisplayNotification("Battleship Selected!");
    }

    void DoSelectMainMenu()
    {
        Debug.Log("Main menu!");
        LoadScene(0);
    }

    void DoSelectStartGame()
    {
        Debug.Log("Start Game!");
        if (isSelectionMade == true)
            SceneManager.LoadScene("SolarSystem");
        else
        {
            DisplayNotification("Please select a ship before continuing!");
        }
    }

    public void LoadScene(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }

    // Set ship type in playerprefs.
    void SaveShipType(string ship)
    {
        PlayerPrefs.SetString("ship_type", ship);
    }
}