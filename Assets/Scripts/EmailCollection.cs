using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Email Collection", order = 1)]

public class EmailCollection : ScriptableObject
{
   public Email[] emails;
}
