using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject star;
    GameObject starClone;
    public GameObject starSpawn;

    GameObject[] stars;


    private bool onChest;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onChest == true)
        {
            anim.SetBool("isOpen", true);
            star.SetActive(true);
        }
        if(star.activeInHierarchy == true)
        {
            StartCoroutine(SpawnStar());
            StartCoroutine(DeleteStar());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            onChest = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            onChest = false;
        }
    }
    IEnumerator SpawnStar()
    {

        starClone = Instantiate(star, starSpawn.transform.position, Quaternion.identity);

        starClone.tag = "starClone";

        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator DeleteStar()
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("starClone");

        yield return new WaitForSeconds(5);

        for (int i = 0; i < stars.Length; i++)
        {
            GameObject.Destroy(stars[i]);
        }

    }
}
