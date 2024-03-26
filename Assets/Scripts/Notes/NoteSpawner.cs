using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notes; 
    public void spawnNotes()
    {
        Instantiate(notes, transform.position, transform.rotation, GameObject.FindGameObjectWithTag("NoteSpawner").transform); 
        //Debug.Log("Spawned a note"); 
    }
}
