using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lane_c : MonoBehaviour {

    public Color baseColor = new Color (.5f,0,0);
    public Color emissionColor = new Color (1,0,0);
    public bool isActive = false;
    public float repeatSpeed = .2f;
    public float offsetSpeed = 0.3f;

    float offset = 0;
    // Use this for initialization
    void Start () {
        setEmissionColor(emissionColor);
        setColor(baseColor);
    }

    void setColor(Color color)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
    }

    void setEmissionColor(Color color)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
    }

    // Update is called once per frame
    void Update () {

      //  float emission;
      //  emission = (isActive ? 1 : 0) ;
        //  emission = (isActive ? Mathf.Clamp01(1 - Mathf.Sin(Time.time * repeatSpeed)) : 0);
        setEmissionColor(emissionColor * (isActive ? 1 : 0));

        if (isActive) 
        {
        offset = (offset >= 1 ? 0 : offset+ 0.01f * repeatSpeed);
        gameObject.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }

    }
}
