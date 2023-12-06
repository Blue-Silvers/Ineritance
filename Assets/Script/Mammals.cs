using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using UnityEngine;

public class Mammals : ZooScript
{
    bool here = false;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (!here)
        {
            //NewMammals();
            here = true;
        }

    }
}
