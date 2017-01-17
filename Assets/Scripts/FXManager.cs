using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    const float fxTick = 0.25f;

    public List<GameObject> Effects = new List<GameObject>();
    public List<KeyValuePair<GameObject, float>> ActiveEffects = new List<KeyValuePair<GameObject, float>>();
    public List<KeyValuePair<GameObject, float>> EffectsToDeactivate = new List<KeyValuePair<GameObject, float>>();
    void Start()
    {
        InvokeRepeating("CheckFX", fxTick, fxTick);
    }

    public void Create(string Name, Vector3 Position, float Duration)
    {
        GameObject fxObj = Effects.FirstOrDefault(x => x.name == Name);
        if (fxObj == null)
        {
            Debug.LogError("Can´t find FX called " + Name);
            return;
        }

        //Try this. If it doesn´t work for multiple fx, instantiate/clone the gameobject
        fxObj.transform.position = Position;
        fxObj.SetActive(true);

        ActiveEffects.Add(new KeyValuePair<GameObject, float>(fxObj, Duration));
    }

    void CheckFX()
    {
        if (ActiveEffects.Count < 1)
            return;

        for (int i = 0; i < ActiveEffects.Count; i++)
        {
            float newValue = ActiveEffects[i].Value - fxTick;
            ActiveEffects[i] = new KeyValuePair<GameObject, float>(ActiveEffects[i].Key, newValue);

            if (newValue < 0)
            {
                EffectsToDeactivate.Add(ActiveEffects[i]);
            }
        }

        while (EffectsToDeactivate.Count > 0)
        {
            int index = ActiveEffects.FindIndex(j => j.Key == EffectsToDeactivate[0].Key && j.Value == EffectsToDeactivate[0].Value);
            if (index >= 0)
            {
                ActiveEffects[index].Key.SetActive(false);
                ActiveEffects.RemoveAt(index);
            }

            EffectsToDeactivate.RemoveAt(0);
        }
    }
}
