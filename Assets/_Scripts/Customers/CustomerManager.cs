using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : Singleton<CustomerManager>
{
    #region Callbacks
    public delegate void OnCustomerAttended(CustomerController customer);
    public OnCustomerAttended onCustomerAttended;
    #endregion
    

    [Header("Customer Prefab")]
    [SerializeField] GameObject customerPrefab;
    [SerializeField] Transform customerParent;


    [Header("Customer Positions")]
    [SerializeField] Transform customerSpawnPoint;
    [SerializeField] Transform[] queuePositions;
    [SerializeField] Transform[] attendPositions;

    
    [Header("Customer Spots")]
    [SerializeField] Transform enteringSpot;
    [SerializeField] Transform paymentSpot;

    CustomerController[] attendingCustomer = new CustomerController[3];

    public int CustomersCount { get; private set; }
    public int CustomersMax { get; private set; }

    List<CustomerController> customersQueue = new();

    // Start is called before the first frame update
    void Start()
    {
        CustomersCount = 0;
        CustomersMax = queuePositions.Length;
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

    #region Queue Control
    public void AddCustomerInQueue(CustomerController customer)
    {
        // TODO: check if max quantity reached
        // set the position in the customer controller
        customer.SetCurrentQueuePosition(CustomersCount);
        // add customer in queue
        customersQueue.Add(customer);
        // update the count
        CustomersCount++;
    }

    public void RemoveCustomerFromQueue(int index)
    {
        customersQueue.RemoveAt(index);
        // update the count
        CustomersCount--;
    }

    public bool AttendingSpotIsFree()
    {
        // check if has position in attending spots
        for(int i = 0; i < attendingCustomer.Length; i++)
        {
            // if attending spot is free
            if (attendingCustomer[i] == null)
            {
                return true;
                break;
            }
        }
        return true;
    }

    public void AttendCustomer()
    {
        // check if has position in attending spots
        for(int i = 0; i < attendingCustomer.Length; i++)
        {
            // if attending spot is free
            if (attendingCustomer[i] == null)
            {
                // get the first customer in queue
                attendingCustomer[i] = customersQueue[0];
                // remove it from the queue
                customersQueue.RemoveAt(0);
                // callback for all the other customers in queue
                onCustomerAttended?.Invoke(attendingCustomer[i]);
                Debug.Log("Customer is now being attended.");
                attendingCustomer[i].ChangeState(ECustomerState.Attending);
            }
            break;
        }
    }
    #endregion

    #region Get Spots
    public Vector3 GetQueuePosition(int index)
    {
        return queuePositions[index].position;
    }

    public Vector3 GetEnteringSpot()
    {
        return enteringSpot.position;
    }

    public Vector3 GetPaymentSpot()
    {
        return paymentSpot.position;
    }
    #endregion
}
