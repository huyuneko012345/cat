using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDataBaseManager : MonoBehaviour
{
    [SerializeField] private CatDataBase catDataBase;
    private void addCat(Cat cat){
        catDataBase.catDataList.Add(cat);
    }
}
