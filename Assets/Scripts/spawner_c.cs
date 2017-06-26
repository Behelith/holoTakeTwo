using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_c : MonoBehaviour
{
    public GameObject[] spawners = new GameObject[2];
    public GameObject noteBlock;
    public GameObject textPlane;
    public TextMesh textMesh;



    // Use this for initialization
    void Start()
    {

    }

    void spawn()
    {
        Random rand = new Random();

        int index = Mathf.FloorToInt(Random.Range(0,spawners.Length));
        Debug.Log(index);

        Debug.Log("Spawn!");
        GameObject newNoteBlock = Instantiate(noteBlock);
        newNoteBlock.transform.parent = spawners[index].transform;

        newNoteBlock.
                gameObject.GetComponent<MeshRenderer>()
                    .material.SetColor("_EmissionColor", new Color(1,0,0));


    }

    void playNote(AudioClip ac)
    {
        Debug.Log("Playing!");
        AudioSource.PlayClipAtPoint(ac, new Vector3(0, 0, 0));
    }

    public void playDing()
    {
    //    AudioClip ac2 =;
        AudioSource.PlayClipAtPoint(Resources.Load("tone") as AudioClip, new Vector3(0, 0, 0));


    }

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

        if (Input.GetKeyDown(KeyCode.T))
            Debug.Log("time: " + Time.time);

        

    }
}
