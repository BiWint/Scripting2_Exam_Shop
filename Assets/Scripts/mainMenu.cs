using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    [Header("Button to store")]
    public GameObject toStoreButtonPrefab;

    [Header("In store material buttons")]
    public GameObject shopButtonPrefab;
    public GameObject shopButtonContainer;

    private void Start()
    {
        Sprite[] textures = Resources.LoadAll<Sprite>("Player");
        foreach(Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonContainer.transform, false);
        }
    }

    public void lookAtMenu(Transform menuTransform)
    {
        Camera.main.transform.LookAt(menuTransform.position);

    }
}
