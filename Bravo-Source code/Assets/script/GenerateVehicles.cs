using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateVehicles : MonoBehaviour
{

    LinkedList<GameObject> l;
    GameObject NextGOPrefab;
    GameObject NextGO;
    LinkedListNode<GameObject> temp;

    // Use this for initialization
    void Start()
    {
        l = new LinkedList<GameObject>();
        NextGOPrefab = Resources.Load<GameObject>("vehicle" + Random.Range(1, 5));
        //NextGOPrefab.transform.localScale= new Vector3(1,1,1);
        float x = (float)(Camera.main.transform.position.x + Random.Range(6, 8) + 11.5);
        Vector3 point = new Vector3(x, NextGOPrefab.transform.position.y, 0);//new  Vector3(x, -2.5f, 0); //NextGOPrefab.transform.position.y
        NextGO = Instantiate(NextGOPrefab, point, NextGOPrefab.transform.rotation);

        l.AddLast(NextGO);


        Debug.Log(NextGO.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        temp = l.Last;
        if (temp.Value.transform.position.x < 11.5 + Camera.main.transform.position.x)
        {
            NextGOPrefab = Resources.Load<GameObject>("vehicle" + Random.Range(1, 5));
            //NextGOPrefab.transform.localScale= new Vector3(1,1,1);
            float x = (float)(Camera.main.transform.position.x + Random.Range(6, 10) + 11.5);
            Vector3 point = new Vector3(x, NextGOPrefab.transform.position.y, 0);
            NextGO = Instantiate(NextGOPrefab, point, NextGOPrefab.transform.rotation);
            l.AddLast(NextGO);
        }
        if (temp.Value.transform.position.x < Camera.main.transform.position.x - 11.5)
        {
            temp = l.First;
            Destroy(temp.Value);
        }

    }



}