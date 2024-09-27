using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [Header("Customer Queue")]
    [SerializeField]
    Transform queueStart;
    [SerializeField]
    Vector3 queueOffset;
    [SerializeField]
    int queueRow;
    [SerializeField]
    int queueColumn;

    [Header("Customer Prefab")]
    [SerializeField]
    GameObject customerPrefab;

    int customersCount = 0;

    List<CustomerController> customers;

    // Start is called before the first frame update
    void Start()
    {
        customers = new List<CustomerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            AddCustomer();
        }
    }

    [SerializeField] Transform customerSpawnPoint;

    public void AddCustomer() {
        // TODO: smooth customer in the scene
        float rowPos = 0;
        // check row count
        if ((int)(customersCount / queueColumn) % 2 == 0)
        {
            // if pair position goes on
            rowPos = (int)(customersCount % queueColumn);
            // Debug.Log($"Row pair with: {rowPos}");
        } else
        {
            // else revert the second line
            rowPos = 2 - (int)(customersCount % queueColumn);
            // Debug.Log($"Row odd with: {rowPos}");
        }
        // set the customer position
        float xPos = (int)(customersCount / queueRow) * queueOffset.x;
        float zPos = rowPos * queueOffset.z;
        Vector3 offset = Vector3.right * xPos + Vector3.forward * zPos;
        Vector3 pos = queueStart.position + offset;
        // instantiate the prefab
        GameObject customerObj = Instantiate(customerPrefab, customerSpawnPoint.position, Quaternion.identity);
        customerObj.transform.SetParent(queueStart);
        customers.Add(customerObj.GetComponent<CustomerController>());
        // set customer movement to the position
        customerObj.GetComponent<CustomerMovement>().MoveTo(pos);
        // update the count
        customersCount++;
    }
}
