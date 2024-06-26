using Firebase.Database;
using System.Collections;
using UnityEngine;
using Newtonsoft.Json;
using Firebase.Auth;

public class DataSync : MonoBehaviour
{
    public static DataSync DefaultInstance;

    public DatabaseReference databaseRef;

    public SavedData data;

    [SerializeField]
    private UpdateUI updateUI;

    private void Awake()
    {
        databaseRef = FirebaseDatabase.GetInstance("https://universityprojects-eedf6-default-rtdb.firebaseio.com/").RootReference;

        DefaultInstance = this;

        data = new SavedData();
    }

    public void UploadData(SavedData Data)
    {
        string json = JsonConvert.SerializeObject(Data);

        string UserID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        databaseRef.Child(UserID).SetRawJsonValueAsync(json);

        Debug.Log(json);
    }

    public void DownloadData()
    {
        StartCoroutine(DownloadDataEnum());
    }

    private IEnumerator DownloadDataEnum()
    {
        var serverData = databaseRef.Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => serverData.IsCompleted);

        DataSnapshot snapshot = serverData.Result;

        string jsonData = snapshot.GetRawJsonValue();

        if (jsonData != null)
        {
            data = JsonConvert.DeserializeObject<SavedData>(jsonData);
        }
        else
        {
            Debug.Log("No data has been found!");
        }

        updateUI.UpdateName();

        updateUI.UpdatePastOrders();
    }
}

public class SavedData 
{
    public User CurrentUser;
}

public class User 
{
    public string firstName;

    public string lastName;

    public string phoneNo;
}