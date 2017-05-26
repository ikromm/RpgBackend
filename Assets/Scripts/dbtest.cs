using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ikromm.Characters;
using SQLiteNetExtensions.Extensions;
using ikromm;
using ikromm.Items;

public class dbtest : MonoBehaviour {

    public void Start()
    {
        // check getting data recursively from the database 
        Character character = DbManager.Instance.Get<Character>(1);
        Debug.Log(character.ToString());
        Debug.LogFormat("Gold: {0}", character[0].Quantity);

        // check indexing operator of character
        foreach (Stats stat in System.Enum.GetValues(typeof(Stats)))
            Debug.LogFormat("{0} Mod: {1}", stat, character[stat].Modifier);
        
        // checking resource manager operation
        Texture t = character.LoadResource<Texture>(ResourcePaths.IngameMenu, ResourcePostfixes.Portrait);
        if (t == null)
            Debug.LogErrorFormat("Error loading texture {0},{1} for object {2}",
                ResourcePaths.IngameMenu, ResourcePostfixes.Portrait, character.ToString());

        // check can upgrade requirements for colleen
        Item item = DbManager.Instance.Get<Item>(2);
        Debug.LogFormat("{0} can upgrade {1}: {2}", character.ToString(), item.ToString(), item.CanUpgrade(character));

        // check can upgrade requirements for ikromm
        character = DbManager.Instance.Get<Character>(2);
        Debug.LogFormat("{0} can upgrade {1}: {2}", character.ToString(), item.ToString(), item.CanUpgrade(character));

    }
}
