using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private GameManager gm;
    public GameObject slicedFruit;
    public GameObject fruitJuice;
    private float rotationForce = 200;
    private Rigidbody rb;
    public int scorePoints; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }

    private void InstantiateSlicedFruit()
    {
        GameObject instatiatedFruit = Instantiate(slicedFruit, transform.position, transform.rotation);
        GameObject instatiatedJuice = Instantiate (fruitJuice, new Vector3(transform.position.x, transform.position.y, 0), fruitJuice.transform.rotation);

        Rigidbody[] slicedRb = instatiatedFruit.transform.GetComponentsInChildren<Rigidbody>(); 

        foreach (Rigidbody srb in slicedRb)
        {

            srb.AddExplosionForce(130, transform.position, 10);
        }

        Destroy(instatiatedFruit, 5);
        Destroy(instatiatedJuice, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            gm.UpdateTheScore(scorePoints);
            Destroy (gameObject);
            InstantiateSlicedFruit();
        }

        if (other.tag == "BottomTrigger")
        {

            gm.UpdateLives();
        }

    }
}
