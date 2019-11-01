using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character
{
    public int Lives { get; private set; }

    public PlayableCharacter(GameObject Instance) : base(Instance)
    {
        Lives = 2;
    }
}
