using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseName : MonoBehaviour
{
    [SerializeField] GameObject ShopM, NameUi;
    public TMP_InputField nameField;
    private Animal current;

    public static ChooseName instance;

    private void Awake()
    {
        instance = this;
    }

    public void SetupAnimal(Animal animal)
    {
        current = animal;
        nameField.text = animal.name;
    }

    public void Validate()
    {
        current.SetName(nameField.text);
        NameUi.SetActive(false);
        ShopM.SetActive(true);
    }
}
