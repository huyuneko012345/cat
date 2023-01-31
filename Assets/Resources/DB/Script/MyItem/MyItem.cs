using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class MyItem : ScriptableObject
{
    public Item item;
    public int count;

    public void addCount(int count=1){
        this.count+=count;
    }
}
