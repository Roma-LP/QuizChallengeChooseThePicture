using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizChallenge.Scripts.Extensions
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns a random item from the list, or the default value if the list is empty or null.
        /// </summary>
        public static T GetRandomItem<T>(this List<T> list)
        {
            if (list == null)
                return default(T);

            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Creates and returns a clone of any given scriptable object.
        /// </summary>
        public static T Clone<T>(this T scriptableObject) where T : ScriptableObject
        {
            if (scriptableObject == null)
            {
                Debug.LogError($"ScriptableObject was null. Returning default {typeof(T)} object.");
                return (T)ScriptableObject.CreateInstance(typeof(T));
            }

            T instance = UnityEngine.Object.Instantiate(scriptableObject);
            instance.name = scriptableObject.name; // remove (Clone) from name
            return instance;
        }

        /// <summary>
        /// Extension method to invoke a given action after a specified delay using a coroutine.
        /// </summary>
        public static Coroutine InvokeMethodAfterDelay(this MonoBehaviour monoBehaviour, Action action, float delay)
        {
            return monoBehaviour.StartCoroutine(InvokeMethodAfterDelay(action, delay));
        }

        private static IEnumerator InvokeMethodAfterDelay(Action method, float delay)
        {
            yield return new WaitForSeconds(delay);
            method?.Invoke();
        }
    }
}
