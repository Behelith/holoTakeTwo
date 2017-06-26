using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_c : MonoBehaviour {

    public GameObject indicator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Clamp(GameObject.FindGameObjectsWithTag("Player")[0].gameObject.transform.position.x /** 6.66f*/, -1f,1f);
        float z = Mathf.Clamp(GameObject.FindGameObjectsWithTag("Player")[0].gameObject.transform.position.z /** 6.66f*/, -1f,1f);
        indicator.gameObject.transform.localPosition = new Vector3(x,0,z);

    }
}
