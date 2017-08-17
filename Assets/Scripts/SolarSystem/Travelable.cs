﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Travelable : MonoBehaviour {

    public List<string> Connections;

    public string Type;
    public string Name;
    public int Difficulty;
    public string EncounterType;
    public bool WasVisited;
    public string Tag;

    public IModule ModuleReward;
    public GameObject PlayerShipUI;

    //Put slot to hold a module

    private Vector2 Destination;

    public void Initialize(string Name, int Difficulty, IModule ModuleReward = null)
    {
        this.Name = Name;
        this.WasVisited = false;
        this.Difficulty = Difficulty;
        this.ModuleReward = ModuleReward;
    }

    public void OnMouseDown()
    {
        SolarSystemManager script = Camera.main.GetComponent<SolarSystemManager>();
        script.GetPlayerShipUI();

        Destination = gameObject.transform.position;
        Destination.y = Destination.y - 1.75f;

        script.SetPlayerShipUI(Destination);
    }

    private void TravelHere()
    {
        if(PlayerShipUI.GetComponent<Rigidbody2D>().IsSleeping())
        {
            Vector2.MoveTowards(transform.position, Destination, 10 * Time.deltaTime);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        TravelHere();

        if (this.WasVisited == true)
        {
            ChangetoVisited();
        }

    }

    private void ChangetoVisited()
    {
        Color tmp = this.gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = .25f;
        this.gameObject.GetComponent<SpriteRenderer>().color = tmp;
    }

    private void LoadHostileEncounter(string planet)
    {
        GameManager.game.sData.isFleetEncounter = false;
        print(planet);
        SceneManager.LoadScene("HostileEncounter");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && this.WasVisited == false ||
            GameManager.game.sData.PlanetsData[this.Name].wasVisited == false)
        {
            WasVisited = true;
            print(this.Name);
            GameManager.game.sData.PlanetsData[this.Name].wasVisited = true;
            //this.tag = "Visited";
            //LoadHostileEncounter(this.name);
        }

        if (this.WasVisited == true)
        {
            ChangetoVisited();
        }
    }
}

