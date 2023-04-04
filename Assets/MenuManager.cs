using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject kitchenFurniture;
    public GameObject livingRoomFurniture;
    public GameObject bedroomFurniture;
    public GameObject title;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private string[] roomNames = {"Kitchen", "Living Room", "Bedroom"};
    private GameObject[] roomList = new GameObject[3];
    private int roomIndex;
    private void Start()
    {
        roomList[0] = kitchenFurniture;
        roomList[1] = livingRoomFurniture;
        roomList[2] = bedroomFurniture;
    }

    public void NextRoom()
    {
        roomIndex = (roomIndex + 1) % roomList.Length;
        UpdateScrollList();
    }

    public void PreviousRoom()
    {
        // accounts for negative numbers
        roomIndex = ((roomIndex - 1) % roomList.Length + roomList.Length) % roomList.Length;
        UpdateScrollList();
    }

    private void UpdateScrollList()
    {
        for (int i = 0; i < roomList.Length; i++) {
            if (i == roomIndex)
                roomList[i].SetActive(true);
            else
                roomList[i].SetActive(false);
        }
        TMPro.TextMeshPro txt = title.GetComponent<TMPro.TextMeshPro>();
        txt.text = roomNames[roomIndex];
    }

    public void AddToDestroy(GameObject o) {
        spawnedObjects.Add(o);
    }

    public void DeleteAll() {
        for (int i = 0; i < spawnedObjects.Count; i++)
            Destroy(spawnedObjects[i]);
    } 

}

