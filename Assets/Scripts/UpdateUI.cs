using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text firstName;

    [SerializeField]
    private TMP_Text lastName;

    public void UpdateName()
    {
        firstName.text = DataSync.DefaultInstance.data.CurrentUser.firstName;

        lastName.text = DataSync.DefaultInstance.data.CurrentUser.lastName;

    }

    public void UpdatePastOrders() 
    {
        
    }
}
