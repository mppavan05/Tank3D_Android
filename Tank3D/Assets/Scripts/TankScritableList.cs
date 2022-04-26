using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScritableList", menuName = "ScriptableObjects/NewTankScriptableObjectsList")]
public class TankScritableList : ScriptableObject
{
    public TankScritable[] tanks;
}