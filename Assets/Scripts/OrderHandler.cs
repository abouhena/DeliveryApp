using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderHandler : MonoBehaviour
{
 
    private Button placeOrderButton;

    [SerializeField]
    private TMP_Text orderName;

    [SerializeField]
    private TMP_InputField adresse;

    [SerializeField]
    private TMP_Text price;

    private void Start()
    {
        placeOrderButton = GetComponent<Button>();

        placeOrderButton.onClick.AddListener(() => { PlaceOrder(orderName.text, adresse.text, price.text); });
    }

    public void PlaceOrder(string name, string adresse, string price) 
    {
        DataSync.DefaultInstance.DownloadPastOrdersData();

        Order newOrder = new Order();

        newOrder.orderName = name;

        newOrder.price = price;

        newOrder.shippingAdresse = adresse;

        DataSync.DefaultInstance.ordersData.orders.Add(newOrder);

        DataSync.DefaultInstance.UploadPastOrdersData();
    }
}
