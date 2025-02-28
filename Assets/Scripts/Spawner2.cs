using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject[] objects;

    public float left;
    public float right;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomObject());
    }

    private IEnumerator SpawnRandomObject()
    {
        yield return new WaitForSeconds(1);

        while (FindObjectOfType<GameManager>().gameIsOver == false)
        {
            InstiantiateRandomObject();
            yield return new WaitForSeconds(RandomRepeatrate());
        }

    }

    // Update is called once per frame
    private void InstiantiateRandomObject()
    {
        int objectIndex = Random.Range(0, objects.Length);

        GameObject obj = Instantiate(objects[objectIndex], transform.position, objects[objectIndex].transform.rotation);

        obj.GetComponent<Rigidbody>().AddForce(RandomVector() * RandomForce(), ForceMode.Impulse);

        obj.transform.rotation = Random.rotation;
    }

    private float RandomForce()
    {
        float Force = Random.Range(14f, 16f);
        return Force;
    }

    private float RandomRepeatrate()
    {
        float repeterate = Random.Range(0.5f, 3f);
        return repeterate;
    }

    private Vector2 RandomVector()
    {
        Vector2 moveDirection = new Vector2(Random.Range(left, right), 1).normalized;   
        return moveDirection;
    }
}
