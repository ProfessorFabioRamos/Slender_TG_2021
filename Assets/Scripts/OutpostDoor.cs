using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutpostDoor : MonoBehaviour
{
    private Animation anim;
    public bool isOpen = false;
    public GameObject hintText;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponent<Animation>();
        hintText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int score = other.GetComponent<Player>().score;
            if (score >= 8 && !isOpen)
            {
                anim.Play("Opening");
                isOpen = true;
            }
            else
            {
                hintText.SetActive(true);
                hintText.GetComponent<Text>().text =
                    "Voce possui " + score + " livros. Colete 8 para abrir a porta.";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hintText.SetActive(false);
        }
    }
}
