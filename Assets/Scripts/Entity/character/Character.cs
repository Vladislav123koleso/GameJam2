using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationWrap
{
    Stop,
    Talk,
    Jump,
    Run
}

public class Character : MonoBehaviour
{
    [SerializeField] private string _name;
    public string Nickname => _name;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
