using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SceneM))]
public class Mech_Game_Collect : Mech_Game
{
    private SceneM m;
    public override void Start()
    {
        m = GetComponent<SceneM>();
        base.Start();
    }
    public override void Apply()
    {
        m.LoadScene(2);
        base.Apply();

    }

    public override void Applied()
    {
        base.Applied();
    }
}
