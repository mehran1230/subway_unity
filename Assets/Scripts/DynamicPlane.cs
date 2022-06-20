using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlane : MonoBehaviour
{
    public Transform[] points;
    public GameObject[] prefabs;
    private GameObject[] blockObjects;
    [SerializeField] bool is_first_plane = false;
    // private Vector3[] TypeOfPlacementObject = new Vector3[5];


    // Start is called before the first frame update
    void Start()
    {
        // TypeOfPlacementObject[0] = new Vector3();
        blockObjects = new GameObject[points.Length];
        if (is_first_plane)
        {
            put_all_gold_for_first();

        }
        else
        {
            objectGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other) {
      if(other.transform.tag == "MainCamera")
      {
            DeleteObject();
            this.transform.parent.position += new Vector3(0 ,0 ,80);
            objectGame();
      }  
    }
    private void put_all_gold_for_first()
    {
       
            for (int i = 0; i < points.Length; i++)
            {

                Vector3 pointPos = points[i].position;
                blockObjects[i] = GameObject.Instantiate(prefabs[6], pointPos + new Vector3(0, prefabs[6].transform.position.y, 0), prefabs[6].transform.rotation);

            }
        
    }
     private void objectGame()
    {
        for (int i = 0; i < points.Length; i++)
        {

            int rand = Random.Range(0, prefabs.Length);
            Vector3 pointPos = points[i].position;
            // Vector3 endPoint = new Vector3(0,prefabs[rand].transform.position.y,0);
            // Debug.Log("Rotation " + prefabs[rand].transform.rotation);
            // Debug.Log("Rotation " + pointPos+" --------- "+prefabs[rand]);
            blockObjects[i] = GameObject.Instantiate(prefabs[rand], pointPos + new Vector3(0, prefabs[rand].transform.position.y, 0), prefabs[rand].transform.rotation);
            // blockObjects[i] = GameObject.Instantiate(prefabs[rand],pointPos+ endPoint ,prefabs[rand].transform.rotation);
        }

    }

    private void DeleteObject()
    {
        foreach(GameObject ObjectInPlane in blockObjects)
        {
            Destroy(ObjectInPlane);
        }
    }
}
