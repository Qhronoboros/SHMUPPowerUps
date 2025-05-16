using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    public void Execute(GameObject actor)
    {
        Debug.Log("Attack");
    }
}
