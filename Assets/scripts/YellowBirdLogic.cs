using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBirdLogic : RedbirdLogic
{
    protected override void ShowSkill()
    {
        rgd.velocity = rgd.velocity * 3;
    }
}
