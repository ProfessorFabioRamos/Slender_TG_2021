using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public Camera fpsCam;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score+"/8";

        RaycastHit hit;

        Vector3 rayOrigin = fpsCam.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, 2.0f))
        {
            if(hit.transform.tag == "Gun")
            {
                //INPUT
                Destroy(hit.transform.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Collect")
        {
            score ++;
            Destroy(other.gameObject);
        }
    }
}
