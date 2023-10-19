using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChooser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        skin = Random.Range(1, 4);
        background = Random.Range(1, 3);

        if (skin == 1)
            yellowSkin.SetActive(true);

        if (skin == 2)
            blueSkin.SetActive(true);

        if (skin == 3)
            redSkin.SetActive(true);

        if (background == 1)
            day.SetActive(true);

        if (background == 2)
            night.SetActive(true);
        */



        // arba

        //get random skin
        int i = Random.Range(0, transform.childCount);

        transform.GetChild(i).gameObject.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
