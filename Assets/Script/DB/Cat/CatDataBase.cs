using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
[SerializeField]
public class CatDataBase : ScriptableObject
{
    public List<Cat> catDataList=new List<Cat>();
}
