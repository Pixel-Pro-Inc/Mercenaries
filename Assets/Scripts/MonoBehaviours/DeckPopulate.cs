using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Entities.CharacterPersona;

public class DeckPopulate : MonoBehaviour
{
    public List<Sprite> cardsLion = new List<Sprite>();
    public List<List<Sprite>> cards = new List<List<Sprite>>();
    public void OnClick(GameObject button)
    {
        SpeciesType type = button.GetComponent<SpeciesHolder>().type;

        SpeciesType[] array = (SpeciesType[])(SpeciesType.GetValues(typeof(SpeciesType)));
        for (int i = 0; i < array.Length; i++)
        {
            if (type == array[i])
                Populate(cards[i]);
        }
    }
    List<Sprite> currentlyActive = new List<Sprite>();
    private void Populate(List<Sprite> sprites)
    {
        for (int i = 0; i < currentlyActive.Count; i++)
        {
            Destroy(currentlyActive[i]);
        }

        Vector2 location = new Vector2(-6f, -3.8f);
        Vector2 scale = new Vector2(.25f, .25f);
        for (int i = 0; i < sprites.Count; i++)
        {
            GameObject spawnObject = new GameObject();
            GameObject _object = Instantiate(spawnObject, location, Quaternion.identity);
            _object.transform.localScale = scale;
            CreateCard(_object, sprites[i]);

            location += new Vector2(1.6f, 0);
        }
    }

    private void CreateCard(GameObject _object, Sprite sprite)
    {
        _object.AddComponent<CardBehaviour>();
        SpriteRenderer renderer = _object.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
    }
}
