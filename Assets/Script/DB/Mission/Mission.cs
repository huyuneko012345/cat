using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class Mission : ScriptableObject
{
   public int id;
   public string missionName;
   public int MaxCount ;

   public int count=0;

   public int fp=100;

   public void ZeroCount(){
      count=0;
   }
}
