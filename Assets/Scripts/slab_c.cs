using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slab_c : MonoBehaviour
{

    public GameObject refSlab;
 //   public Color baseColor = new Color(.5f, 0, 0);
    public Color emissionColor = new Color(1, 0, 0);
    public int slabID = 0;

    private Texture mask1, mask2;

    // Use this for initialization
    void Start()
    {
        mask1 = Resources.Load("mask_1") as Texture;
        mask2 = Resources.Load("mask_2") as Texture;


        setEmissionColor(emissionColor);
    }



    //   // Update is called once per frame
    //   void Update () {

    //}

    void setColor(Color color)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
        refSlab.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
    }

    void setEmissionColor(Color color)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
        refSlab.gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
    }

    void setEmissionMask(Texture texture)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", texture);
        refSlab.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", texture);

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          //  Debug.Log("slab ID: " + slabID);

            //  setColor();
            //playerController_c pc = 
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerController_c>().time = Time.time;
          //  setEmissionColor(emissionColor);
            setEmissionMask(mask1);
            other.gameObject.GetComponent<playerController_c>().overlappedID = slabID;


            // czy gracz zdarzyl slapac punkt
            float deltaTime = refSlab.gameObject.GetComponent<slab_ref_c>().checkTime();
            if (deltaTime <=.5f && refSlab.gameObject.GetComponent<slab_ref_c>().checkID())
                refSlab.gameObject.GetComponent<slab_ref_c>().matchFound(60+ Mathf.FloorToInt(deltaTime*20));






        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        //    setEmissionColor(baseColor);
            setEmissionMask(mask2);
            other.gameObject.GetComponent<playerController_c>().overlappedID = -1;



        }
    }
}



/*
     _Color
     _MainTex
     _Cutoff
     _Glossiness
     _Metallic
     _MetallicGlossMap
     _BumpScale
     _BumpMap
     _Parallax
     _ParallaxMap
     _OcclusionStrength
     _OcclusionMap
     _EmissionColor
     _EmissionMap
     _DetailMask
     _DetailAlbedoMap
     _DetailNormalMapScale
     _DetailNormalMap
     _UVSec
     _EmissionScaleUI
     _EmissionColorUI
     _Mode
     _SrcBlend
     _DstBlend
     _ZWrite
 */
