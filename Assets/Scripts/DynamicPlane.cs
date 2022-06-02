using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlane : MonoBehaviour
{
    public Transform[] points;
    public GameObject[] prefabs;
    private GameObject[] blockObjects;
    
                                      // private Vector3[] TypeOfPlacementObject = new Vector3[5];
    
    
    // Start is called before the first frame update
    void Start()
    {
                                        // TypeOfPlacementObject[0] = new Vector3();
        blockObjects = new GameObject[points.Length];
        objectGame();
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

    private void objectGame()
    {
        for(int i=0;i<points.Length;i++)
        {
            
            int rand = Random.Range(0,7);
            if(rand != 7)
            {
                Vector3  pointPos = points[i].position;
                // Vector3 endPoint = new Vector3(0,prefabs[rand].transform.position.y,0);
                // Debug.Log("Rotation " + prefabs[rand].transform.rotation);
                // Debug.Log("Rotation " + pointPos+" --------- "+prefabs[rand]);
                blockObjects[i] = GameObject.Instantiate(prefabs[rand],pointPos+ new Vector3(0,prefabs[rand].transform.position.y,0) ,prefabs[rand].transform.rotation);
                // blockObjects[i] = GameObject.Instantiate(prefabs[rand],pointPos+ endPoint ,prefabs[rand].transform.rotation);
            }
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
