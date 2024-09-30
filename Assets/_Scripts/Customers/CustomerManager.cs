using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : Singleton<CustomerManager>
{
    #region Callbacks
    public delegate void OnCustomerAttended(CustomerController customer);
    public OnCustomerAttended onCustomerAttended;
    #endregion

    [Header("Customer Queue")]
    [SerializeField] Transform customerSpawnPoint;
    [SerializeField] Transform[] positions;
    [SerializeField] Transform enteringSpot;
    

    [Header("Customer Prefab")]
    [SerializeField] GameObject customerPrefab;
    [SerializeField] Transform customerParent;

    public int CustomersCount { get; private set; }
    public int CustomersMax { get; private set; }

    List<CustomerController> customers;

    // Start is called before the first frame update
    void Start()
    {
        CustomersCount = 0;
        CustomersMax = positions.Length;
        customers = new List<CustomerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            InstantiateCustomer();
        }
    }

    public void InstantiateCustomer() {
        // TODO: smooth customer appearing in the scene
        
        // instantiate the prefab
        GameObject customerObj = Instantiate(customerPrefab, customerSpawnPoint.position, Quaternion.identity);
        customerObj.transform.SetParent(customerParent);

        // TODO: define if the customer is instantiate with Walking or Entering
    }

    public void AddCustomerInQueue()
    {
        // update the count
        CustomersCount++;
    }

    public Vector3 GetCurrentLastPosition()
    {
        return positions[CustomersCount].position;
    }

    public Vector3 GetQueuePosition(int countPos)
    {
        return positions[countPos].position;
    }

    public Vector3 GetEnteringSpot()
    {
        return enteringSpot.position;
    }

    public void AttendCustomer(CustomerController customer)
    {
        CustomersCount--;
        onCustomerAttended?.Invoke(customer);
    }
}
