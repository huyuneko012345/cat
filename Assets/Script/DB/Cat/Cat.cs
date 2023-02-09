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
    [Range(0,100)]public int hunger;
    [Range(0,100)]public int favorability;
    [Range(0,100)]public int mental;
    [Range(0,100)]public int age;
    public string user;
    public bool interputTask;





}
