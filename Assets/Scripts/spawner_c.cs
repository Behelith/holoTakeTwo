using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_c : MonoBehaviour
{
    public GameObject[] spawners = new GameObject[3];
    public GameObject noteBlock;
    public GameObject textPlane;
    public TextMesh textMesh;
    public Color[] colors = new Color[3];
    public GameObject[] mapIndicators = new GameObject[3];
    public GameObject[] lanes = new GameObject[3];

    public int[] noteMap = new int[3];

    private Texture mask1, mask2;



    // Use this for initialization
    void Start()
    {
        mask1 = Resources.Load("mask_1") as Texture;
        mask2 = Resources.Load("mask_2") as Texture;

        mapIndicators[0].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[0]);
        mapIndicators[1].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[1]);
        mapIndicators[2].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[2]);

    }

    public void indicatorControl(int index, int value)
    {
        // zmienia kolory slabow na mapie
        noteMap[index] += value;
        if (noteMap[index] > 0)
        {
            mapIndicators[index].gameObject.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", mask1);
            lanes[index].GetComponent<lane_c>().isActive = true;
        }
        else
        {
            mapIndicators[index].gameObject.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", mask2);
            lanes[index].GetComponent<lane_c>().isActive = false;
        }
    }

    void spawn()
    {
        Random rand = new Random();

        int index = Mathf.FloorToInt(Random.Range(0, spawners.Length));
        Debug.Log(index);

        Debug.Log("Spawn! , index: " + index);
        GameObject newNoteBlock = Instantiate(noteBlock);
        newNoteBlock.transform.parent = spawners[index].transform;

        newNoteBlock.gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[index]);
        indicatorControl(index, 1);
    }

    void playNote(AudioClip ac)
    {
        Debug.Log("Playing!");
        AudioSource.PlayClipAtPoint(ac, new Vector3(0, 0, 0));
    }

    public void playDing()
    {
        AudioSource.PlayClipAtPoint(Resources.Load("tone") as AudioClip, new Vector3(0, 0, 0));
    }

    //animator controller
    void setAnimationId(int id)
    {
        gameObject.GetComponent<Animator>().SetInteger("animationID", id);
    }

    void setTexture(Texture texture)
    {
        textPlane.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture);
    }

    void Update()
    {

        textMesh.text = "time: " + Time.time;
        if (Input.GetKeyDown(KeyCode.Space))
            spawn();

        if (Input.GetKeyDown(KeyCode.F))
            setAnimationId(1);

        //if (Input.GetKeyDown(KeyCode.T))
        //    Debug.Log("time: " + Time.time);
    }
}
