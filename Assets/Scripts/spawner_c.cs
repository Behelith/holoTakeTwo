using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_c : MonoBehaviour
{
    public GameObject[] spawners = new GameObject[9];
    public GameObject noteBlock;
    public GameObject textPlane;
    public TextMesh textMesh;
    public Color[] colors = new Color[3];
    public GameObject[] mapIndicators = new GameObject[9];
    public GameObject[] lanes = new GameObject[3];

    public int[] noteMap = new int[9];

    int points = 0;

    private Texture mask1, mask2;

    public int spawn_override = -1;

    // Use this for initialization
    void Start()
    {
        mask1 = Resources.Load("mask_1") as Texture;
        mask2 = Resources.Load("mask_2") as Texture;

        mapIndicators[0].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[0]);
        mapIndicators[1].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[0]);
        mapIndicators[2].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[0]);

        mapIndicators[3].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[1]);
        mapIndicators[4].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[1]);
        mapIndicators[5].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[1]);

        mapIndicators[6].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[2]);
        mapIndicators[7].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[2]);
        mapIndicators[8].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[2]);


    }

    public void indicatorControl(int noteMaxIndex, int value)
    {
        // zmienia kolory slabow na mapie
        noteMap[noteMaxIndex] += value;
        Debug.Log("index: " + noteMaxIndex);
        int laneIndex = noteMaxIndex % 3;
        int colorIndex = -1;
        if (noteMaxIndex > 5)
            colorIndex = 2;
        else if (noteMaxIndex > 2)
            colorIndex = 1;
        else
            colorIndex = 0;

        if (noteMap[noteMaxIndex] > 0)
        {
            mapIndicators[noteMaxIndex].gameObject.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", mask1);
        }
        else
        {
            mapIndicators[noteMaxIndex].gameObject.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", mask2);
        }

        if (noteMap[laneIndex] > 0 || noteMap[laneIndex + 3] > 0 || noteMap[laneIndex + 6] > 0)
        {
            lanes[laneIndex].gameObject.GetComponent<lane_c>().emissionColor = colors[colorIndex];
            lanes[laneIndex].gameObject.GetComponent<lane_c>().setColor (colors[colorIndex]);
            lanes[laneIndex].GetComponent<lane_c>().isActive = true;
           // lanes[laneIndex].gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[colorIndex]);

        }
        else
        {
            lanes[laneIndex].GetComponent<lane_c>().isActive = false;
        }
    }

    void spawn()
    {
        //Random rand = new Random();

        //  int index = Mathf.FloorToInt(Random.Range(0, spawners.Length));
        int spawnPointIndex;
        if (spawn_override != -1) spawnPointIndex = spawn_override;
        //else  spawnPointIndex = Mathf.FloorToInt(Random.Range(0, spawners.Length));
        else spawnPointIndex = Mathf.FloorToInt(Random.Range(0, 9));


        //   Debug.Log("Spawn! , index: " + spawnPointIndex);
        int colorIndex = -1;
        if (spawnPointIndex > 5)
            colorIndex = 2;
        else if (spawnPointIndex > 2)
            colorIndex = 1;
        else
            colorIndex = 0;


        //   Debug.Log("Spawn! , index: " + spawnPointIndex);
        GameObject newNoteBlock = Instantiate(noteBlock);
        newNoteBlock.transform.parent = spawners[spawnPointIndex].transform;

        newNoteBlock.gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", colors[colorIndex]);
        indicatorControl(spawnPointIndex, 1);
        Debug.Log("Spawn! , index: " + spawnPointIndex);

    }

    void playNote(AudioClip ac)
    {
        Debug.Log("Playing!");
        AudioSource.PlayClipAtPoint(ac, new Vector3(0, 0, 0));
    }

    public void addPoints(int amount)
    {
        points += amount;
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

        textMesh.text = "" + points;// = "time: " + Time.time;
        if (Input.GetKeyDown(KeyCode.Space))
            spawn();

        if (Input.GetKeyDown(KeyCode.F))
            setAnimationId(1);

        //if (Input.GetKeyDown(KeyCode.T))
        //    Debug.Log("time: " + Time.time);
    }
}
