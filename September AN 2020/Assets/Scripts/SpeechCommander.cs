using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;
using UnityEngine.Windows.Speech;

public class SpeechCommander : MonoBehaviour
{

    Dictionary<string, Action> m_keywordDictionary = new Dictionary<string, Action>();

    KeywordRecognizer m_keywordRecognizer;

    void OnEnable()
    {
        //Add phrases to be recognized and associate functions with them
        m_keywordDictionary.Add("Hello World", Speak);
        m_keywordDictionary.Add("What are we", Speak);
        m_keywordDictionary.Add("Who is juan", Speak);
        m_keywordDictionary.Add("Ra Za Na Ba Do A", Speak);
        m_keywordDictionary.Add("Fire", SpawnFire);
        m_keywordDictionary.Add("Explosion", SpawnExplosion);
        m_keywordDictionary.Add("Bit", SpawnBit);

        m_keywordRecognizer = new KeywordRecognizer(m_keywordDictionary.Keys.ToArray());
        m_keywordRecognizer.OnPhraseRecognized += OnKeyWordRecognized;
        m_keywordRecognizer.Start();
    }

    void OnDisable()
    {
        m_keywordDictionary.Clear();
        m_keywordRecognizer.OnPhraseRecognized -= OnKeyWordRecognized;
        m_keywordRecognizer.Stop();
    }

    void OnKeyWordRecognized(PhraseRecognizedEventArgs args)
    {
        m_keywordDictionary[args.text].Invoke();
    }

    void Speak()
    {
        Debug.Log("Juan is cool");
        Debug.Log("We are all sugar coated marsh mallows");
    }

    public GameObject m_fireball;
    public GameObject m_explosion;
    public GameObject m_bit;
    void SpawnFire()
    {
        Instantiate(m_fireball, transform.position, transform.rotation);
    }
    void SpawnExplosion()
    {
        Instantiate(m_explosion, transform.position, transform.rotation);
    }
    void SpawnBit()
    {
        Instantiate(m_bit, transform.position, transform.rotation);
    }
}
