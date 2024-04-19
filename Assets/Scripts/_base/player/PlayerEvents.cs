using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] List<Transform> teleportPos = new List<Transform>();
    public void Teleport(int index)
    {
        transform.position = teleportPos[index].position;
    }

}
