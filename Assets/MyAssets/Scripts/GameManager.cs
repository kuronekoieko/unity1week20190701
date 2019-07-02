using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] CatController cat;
    [SerializeField] CameraController cam;
    // Start is called before the first frame update
    void Start()
    {
        cat.Init();
        cam.Init();
    }

    // Update is called once per frame
    void Update()
    {
        cat.Upd();
        cam.Upd();
    }
}
