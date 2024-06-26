using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductDetails : MonoBehaviour
{

    [SerializeField]
    private TMP_Text productName;

    [SerializeField]
    private TMP_Text productPrice;

    [SerializeField]
    private Image productImage;    
    
    [SerializeField]
    private TMP_Text Name;

    [SerializeField]
    private TMP_Text Price;

    [SerializeField]
    private Image Image;


    public void UpdateProductDetails()
    {
        Name.text = productName.text;

        Price.text = "Total Price : " + productPrice.text;

        Image.sprite = productImage.sprite;
    }
}
