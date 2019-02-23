using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RESTClient;
using Azure.StorageServices;
using System;

public class AppManager : MonoBehaviour
{
    [Header("Azure Storage Service")]
    [SerializeField]
    private string storageAccount = "hhestorageaccount";
    [SerializeField]
    private string accessKey = "h9zw6wtKgJfyN71WYut5k0K4MCeQP/utPFe99NBQtk8ktkZ+rEBsBOlWJpzSVHe3sUm9mxk9BSoOi0/GPnWtvg==";
    [SerializeField]
    private string container = "vipjobsrapport";

    private StorageServiceClient client;
    private BlobService blobService;

    public string myData = "";

    class myItem
    {
        public int YearMonth;
        public string Customer;
        public int Envelopes;
    }

    List<myItem> myList= new List<myItem>();

    void Start()
    {
        if (string.IsNullOrEmpty(storageAccount) || string.IsNullOrEmpty(accessKey))
        {
            //Log.Text(label, "Storage account and access key are required", "Enter storage account and access key in Unity Editor", Log.Level.Error);
        }

        client = StorageServiceClient.Create(storageAccount, accessKey);
        blobService = client.GetBlobService();
        TappedLoadText();
    }

    private void TappedLoadText()
    {
        string resourcePath = container + "/myblob";
        StartCoroutine(blobService.GetTextBlob(GetTextBlobComplete, resourcePath));
    }

    private void GetTextBlobComplete(RestResponse response)
    {
        if (response.IsError)
        {
            //Log.Text(label, response.ErrorMessage + " Error getting blob:" + response.Content);
            return;
        }
        //Log.Text(label, "Get blob:" + response.Content);
        Parse_Data(response.Content);
    }

    private void Parse_Data(string myData)
    {
        this.myData = myData;
        myList.Clear();
        string[] lines = myData.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        foreach(string line in lines)
        {
            if(!line.StartsWith("2"))
            {
                continue;
            }
            myItem item = new myItem();
            string[] fields = line.Split(';');
            item.YearMonth = Int32.Parse(fields[0]);
            item.Customer = fields[1];
            item.Envelopes = Int32.Parse(fields[2]);
            myList.Add(item);
        }
        Visualize(myList);
    }

    private void Visualize(List<myItem> myList)
    {


    }
}
