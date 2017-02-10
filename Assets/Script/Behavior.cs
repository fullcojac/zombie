using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Behavior : MonoBehaviour {
    [SerializeField]
    GameObject bullets;
    [SerializeField]
    GameObject bulletText;
    [SerializeField]
    float speed = 5;
    int nbrOfBullets;
    int index = 0;
    Vector3[] lookAt;
	// Use this for initialization
	void Start () {
        lookAt = new Vector3[4] { new Vector3(10f,0f,0f),
                                  new Vector3(-10f, 0f, 0f),
                                  new Vector3(0f,-10f,0f),
                                  new Vector3(0f,10f,0f) };
        nbrOfBullets = 0;
        UpdateBulletText();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("d")) {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            index = 0;
        }
        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            index = 1;
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
            index = 2;
        }
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
            index = 3;
        }
        if (Input.GetKeyDown("space") && nbrOfBullets > 0)
        {
            GameObject bul = Instantiate(bullets);
            bul.transform.position = transform.position;
            bul.GetComponent<Rigidbody>().velocity = lookAt[index];
            nbrOfBullets--;
            UpdateBulletText();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BulletBag")
        {
            nbrOfBullets += other.GetComponent<BulletQuantity>().ReturnQuantity();
            other.gameObject.SetActive(false);
            UpdateBulletText();
        }
    }
    void UpdateBulletText()
    {
        bulletText.GetComponent<Text>().text = "Bullets : " + nbrOfBullets;
    }
}
