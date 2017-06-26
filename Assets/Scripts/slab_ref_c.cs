﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slab_ref_c : MonoBehaviour
{
    public int ID;
    public float time;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool checkID()
    {
        //   bool var = (ID == GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerController_c>().overlappedID);
        //  Debug.Log("ID match: " + var + ", ID: " + ID + ", player refID: " + GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerController_c>().overlappedID);

        return (ID == GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerController_c>().overlappedID);
    }

    public bool checkTime()
    {

        //   float delTime = Mathf.Abs(time - GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerController_c>().time);
        //   Debug.Log("delta time: " + delTime);
        // if czas > 0 { if delta czasu <= 0.5s = true} 
        return    (time > 0 ? Mathf.Abs(time - GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerController_c>().time) <= 0.5 : false);
    }

    public void matchFound()
    {
        GameObject.FindGameObjectsWithTag("Spawner")[0].GetComponent<spawner_c>().playDing();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("NoteBlock"))
        {
            time = Time.time;
            Destroy(other.gameObject);
            bool var = checkID();

            if (var)
            {
                matchFound();
            }
        }
    }
}