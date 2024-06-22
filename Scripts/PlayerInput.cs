using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ARE YOU SURE YOU WANT TO CHANGE TO LEVEL0?
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<GoatActions>().Jump();
        }

        //if (Input.GetKeyDown(keycode.f))
        //{
        //    getcomponent<goatanimations>().weregoat();
        //}

        GetComponent<GoatActions>().SetDir(Input.GetAxisRaw("Horizontal"));
    }

    private void FixedUpdate()
    {
        GetComponent<GoatActions>().Run();
    }
}
