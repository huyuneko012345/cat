using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
[Serializable]
public class Item : ScriptableObject     
{

    public int id;
    public int typeId;
    public string name;
    public string text;

    public int price;
    public Sprite image;

    public GameObject prefab;
    public int GetId(){
        return id;
    }
}

