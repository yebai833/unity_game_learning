using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldBirdDestroy : BlueCloneDestroy
{
    protected override void LoadNext()
    {
        GameManagerLogic.Instance.LoadNextBird();
    }

}
