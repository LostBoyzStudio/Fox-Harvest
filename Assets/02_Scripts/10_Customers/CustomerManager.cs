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

    public void AddCustomer() {
        // TODO: smooth customer in the scene
        // set the customer position
        float xPos = (int)(customersCount / queueRow) * queueOffset.x;
        float zPos = (customersCount % queueColumn) * queueOffset.z;
        // TODO: revert the second line
        // zPos = ((int)(customersCount / queueColumn) == 1) ? -zPos : zPos;
        Vector3 offset = Vector3.right * xPos + Vector3.forward * zPos;
        Vector3 pos = queueStart.position + offset;
        // instantiate the prefab
        GameObject customerObj = Instantiate(customerPrefab, pos, Quaternion.identity);
        customerObj.transform.SetParent(queueStart);
        customers.Add(customerObj.GetComponent<CustomerController>());
        // update the count
        customersCount++;

    }
}
