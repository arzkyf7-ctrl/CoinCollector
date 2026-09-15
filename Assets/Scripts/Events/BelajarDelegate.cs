using System;
using UnityEngine;

public class BelajarDelegate : MonoBehaviour
{
    delegate void AksiSederhana();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Langkah1_SimpanSatuMethod();
        Langkah2_BeberapaMethodSekaligus();
        Langkah3_ActionSiapPakai();
    }
    void Langkah1_SimpanSatuMethod()
    {
        AksiSederhana kotak=PrintHelloWorld;
        kotak();
    }
    void Langkah2_BeberapaMethodSekaligus()
    {
        AksiSederhana kotak = PrintHelloWorld;
        kotak += PrintHelloWorld;
        kotak();
    }
    void Langkah3_ActionSiapPakai()
    {
        Action kotak = PrintHelloWorld;
        kotak += PrintHelloWorld;
        kotak();
    }
    void PrintHelloWorld()
    {
        Debug.Log("Hello World");
    }
}
