using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WarpGate : interactionObject
{

    public string WarpScene; 


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void action() {
        base.action();
        SceneManager.LoadScene(WarpScene);


    }

}
