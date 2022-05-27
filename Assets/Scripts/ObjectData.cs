using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    LinksContainer _linksContainer;
    PlayerData _playerData;
    
    private void Start()
    {
        _linksContainer = LinksContainer.Instance;
        _playerData = new PlayerData();
        _linksContainer.LengthChanger.Save += SaveTableInfo;
        _linksContainer.ColourApply.Save += SaveHex;
    }
    public void SaveAllData()
    {
        string json = JsonUtility.ToJson(_playerData);

        File.WriteAllText(Application.dataPath + "/SavedData.json", json);
    }
    private void SaveTableInfo(Vector3 lengthOfTable, int numberOfChairs)
    {
        _playerData._length = lengthOfTable;
        _playerData._numberOfChairs = numberOfChairs;
    }
    private void SaveHex(string hexColour)
    {
        _playerData._hexColour = hexColour;

    }
    public void LoadData()
    {
        string json = File.ReadAllText(Application.dataPath + "/SavedData.json");
        PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log("length: " + loadedData._length);
        Debug.Log("number of chairs: " + loadedData._numberOfChairs);
        Debug.Log("hex code: " + loadedData._hexColour);
    }
}
public class PlayerData
{
    public string _hexColour;
    public int _numberOfChairs;
    public Vector3 _length;
}
