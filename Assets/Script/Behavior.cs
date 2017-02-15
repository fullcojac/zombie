using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Behavior : MonoBehaviour {
    [SerializeField]
    GameObject bullets;
    [SerializeField]
    GameObject bulletText;
    Animator animator;
    [SerializeField]
    float speed = 5;
    int nbrOfBullets;
    int index = 5;
    Vector2[] lookAt;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        lookAt = new Vector2[4] { new Vector2(10f,0f),
                                  new Vector2(-10f, 0f),
                                  new Vector2(0f,-10f),
                                  new Vector2(0f,10f) };
        nbrOfBullets = 0;
        UpdateBulletText();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("d")) {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingRight"))
            {
                index = 0;
                animator.SetTrigger("GoingRight");
            }
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey("a")){
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingLeft"))
            {
                index = 1;
                animator.SetTrigger("GoingLeft");
            }
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey("s"))
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingDown"))
            {
                animator.SetTrigger("GoingDown");
                index = 2;
            }
            transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey("w"))
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingUp"))
            {
                animator.SetTrigger("GoingUp");
                index = 3;
            }
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }
        if (Input.GetKeyDown("space") && nbrOfBullets > 0)
        {
            GameObject bul;
            if (index == 2 || index == 3)
                bul = Instantiate(bullets, transform.position, new Quaternion(90f,90f,0f,0f));
            else
                bul = Instantiate(bullets, transform.position, Quaternion.identity);
            bul.GetComponent<Rigidbody2D>().velocity = lookAt[index];
            nbrOfBullets--;
            UpdateBulletText();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
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
