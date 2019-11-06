using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public int Lives { get; private set; }

    public PlayerCharacter(GameObject Instance) : base(Instance)
    {
        Lives = 2;
    }
}
