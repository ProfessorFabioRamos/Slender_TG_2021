using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public Camera fpsCam;
    private GameObject gunPlayer;
    public float shootingDistance = 10.0f;
    private bool canShoot = false;
    public int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
        canShoot = false;
        gunPlayer = transform.GetChild(0).Find("GunPlayer").gameObject;
        gunPlayer.SetActive(false);
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
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    gunPlayer.SetActive(true);
                    canShoot = true;
                }
            }
        }

        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, shootingDistance))
            {
                if (hit.transform.name == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                }
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

    public void TakeDamage()
    {
        hp--;
        if(hp <= 0)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("Game Over");
        }
    }
}
