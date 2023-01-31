using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasType : MonoBehaviour
{
   [SerializeField]private int typeId;
   public int GetTypeId{
    get{
        return typeId;
    }
   }


}
