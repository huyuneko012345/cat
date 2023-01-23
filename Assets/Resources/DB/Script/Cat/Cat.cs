using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class Cat : ScriptableObject
{
    public string _name;
    public string personality;
    public string gender;
    [Range(1,100)]public int hunger;
    [Range(1,100)]public int favorability;
    [Range(1,100)]public int mental;
    [Range(1,100)]public int age;
    public string user;



}
