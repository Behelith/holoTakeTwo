using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_c : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
      //  Debug.Log("start: " + Time.time);
        
        StartCoroutine( delayed());
    }

    public IEnumerator delayed()
    {
     //   print(Time.time);
        yield return new WaitForSeconds(1);
     //   gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(1, 0, 0));
      //  Debug.Log("HA! nie od razu: " + Time.time);
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
