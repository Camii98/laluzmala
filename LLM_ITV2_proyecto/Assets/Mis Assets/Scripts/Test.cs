using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    vThirdPersonInput _Move;
    // Start is called before the first frame update
    void Start()
    {
        _Move = gameObject.GetComponent<vThirdPersonInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _Move.enabled = false;
        }

     if (Input.GetKeyDown(KeyCode.R)) { _Move.enabled = true; }
    }
}
