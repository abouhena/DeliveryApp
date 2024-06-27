using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text firstName;

    [SerializeField]
    private TMP_Text lastName;

    [SerializeField]
    private GameObject orderItem;

    [SerializeField]
    private Transform parent;

    public void UpdateName()
    {
        firstName.text = DataSync.DefaultInstance.userData.CurrentUser.firstName;

        lastName.text = DataSync.DefaultInstance.userData.CurrentUser.lastName;
    }

    public void UpdatePastOrders() 
    {
        foreach (var item in DataSync.DefaultInstance.ordersData.orders)
        {
            GameObject newOrder = Instantiate(orderItem, parent);

            OrderDetails newOrderDetails = newOrder.GetComponent<OrderDetails>();

            newOrderDetails.OrderName = item.orderName;
            
            newOrderDetails.Price = item.price;

            newOrderDetails.ShippingAdresse = item.shippingAdresse;
        }
    }
}
