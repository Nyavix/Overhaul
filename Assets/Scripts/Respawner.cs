using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawner : MonoBehaviour
{
    private GameObject Player;
    public Transform load1;
    public Transform load2;

    private int loadIndex;

    public bool resetePlayerPrefs;

    public GameObject c3l3b1;
    public GameObject c3l3b2;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (PlayerPrefs.HasKey("LoadIndex"))
        {
            loadIndex = PlayerPrefs.GetInt("LoadIndex");
        }
        else
        {
            loadIndex = 0;
        }

        if (loadIndex == 0)
        {
            Player.transform.position = load1.position;
            c3l3b1.SetActive(true);
            c3l3b2.SetActive(false);
        }
        else
        {
            Player.transform.position = load2.position;
            c3l3b1.SetActive(false);
            c3l3b2.SetActive(true);
            Player.GetComponent<PlayerController>().hasLeg = true;
            Player.GetComponent<PlayerCombat>().hasBlade = true;
            Player.GetComponent<PlayerShoot>().hasGun = true;
        }

    }

    private void Update()
    {
        if (resetePlayerPrefs || Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteKey("LoadIndex");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            resetePlayerPrefs = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            loadIndex = 1;
            c3l3b1.SetActive(false);
            c3l3b2.SetActive(true);
            PlayerPrefs.SetInt("LoadIndex", loadIndex);
        }
    }
}
