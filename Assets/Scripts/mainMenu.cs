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

    [Header("Material for player")]
    public Material Player;

    private void Start()
    {

        ChangePlayerSkin(0);

        int textureIndex = 0;

        Sprite[] textures = Resources.LoadAll<Sprite>("Player");
        foreach(Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonContainer.transform, false);

            int index = textureIndex;
            container.GetComponent<Button>().onClick.AddListener(()=>ChangePlayerSkin(index));
            textureIndex++;
        }
    }

    public void lookAtMenu(Transform menuTransform)
    {
        Camera.main.transform.LookAt(menuTransform.position);

    }

    public void ChangePlayerSkin(int index)
    {
        float x = (index % 4) * 0.25f;
        float y = (index / 4) * 0.25f;

        //Making sure Unity is reading the materials in correct order from top left to bottom right on the material
        if (y == 0.0f)
            y = 0.75f;
        else if (y == 0.25f)
            y = 0.5f;
        else if (y == 0.50f)
            y = 0.25f;
        else if (y == 0.75f)
            y = 0;

        Player.SetTextureOffset("_MainTex", new Vector2(x, y));

    }

}
