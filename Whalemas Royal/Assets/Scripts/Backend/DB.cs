using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class DB : MonoBehaviour
{
    public DB instance;

    // For Testing
    public InputField userName, passwordText;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);        
    }

    public void GenerateUser()//string name, string password) 
    {
        string name = userName.text;
        string password = passwordText.text.Trim();
        
        if (password.Length > 0)
        {                        
            StartCoroutine(CreateUser(name, ComputeSha256Hash(password)));
        }
        else
            StartCoroutine(GetUser(name));
    }

    private IEnumerator CreateUser(string name, string hashedPassword)
    {
        string URL = "http://192.168.0.2:6969/AddUser?" + "Name=" + name + "&Password=" + hashedPassword;

        UnityWebRequest www = new UnityWebRequest(URL.Replace(" ", ""));

        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
        }   
    }

    private IEnumerator GetUser(string name)
    {
        string URL = "http://192.168.0.2:6969/Users?collection=Users&Name=" + name;

        print(URL);

        UnityWebRequest www = new UnityWebRequest(URL);

        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
        }
    }

    public void Login(string username, string password)
    {
        
    }

    public string ComputeSha256Hash(string rawData)  
    {  
        // Create a SHA256   
        using (SHA256 sha256Hash = SHA256.Create())  
        {  
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();  
            for (int i = 0; i < bytes.Length; i++)  
            {  
                builder.Append(bytes[i].ToString("x2"));  
            }  
            return builder.ToString();  
        }  
    }  
}
