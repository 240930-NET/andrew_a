﻿using System;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Project0.Program;

public class MedievalDictionary {
    Dictionary<string, string> dict = new Dictionary<string, string>();

    public MedievalDictionary() {
        FillDictionary();
    }

    private void FillDictionary() {
        dict.Add("the", "ye");
        dict.Add("here", "hither");
        dict.Add("hello", "good day");
        dict.Add("hi", "good day");
        dict.Add("bye", "good day");
        dict.Add("goodbye", "good day");
        dict.Add("no", "nay");
        dict.Add("yes", "aye");
        dict.Add("does", "doth");
        dict.Add("your", "thy");
        dict.Add("you", "thou");
        dict.Add("are", "art");
        dict.Add("my", "mine");
        dict.Add("of", "o'");
        dict.Add("often", "oft");
        dict.Add("would", "wouldst");
        dict.Add("could", "couldst");
        dict.Add("those", "yon");
        dict.Add("is", "be");
        dict.Add("never", "ne'er");
        dict.Add("please", "prithee");
        dict.Add("joke", "jest");
        dict.Add("clown", "jester");
    }

    public string GetTranslatedWord(string word) {
        string translated = "";
        if (dict.TryGetValue(word, out translated)!) {
            return translated;
        } else {
            return word;
        }
    }
}

public class WordTranslator {
    MedievalDictionary dict = new MedievalDictionary();
    
    enum CapState {
        None = 0,
        First = 1,
        All = 2
    }

    public string TranslateSentence(string sentence) {
        string translated = "";
        string[] words = sentence.Split(' ');
        foreach (string word in words) {
            if (word.Length > 0) {
                translated += TranslateWord(word);
            }
            translated += " ";
        }
        translated = translated.Remove(translated.Length - 1);
        return translated;
    }

    public string TranslateWord(string word) {
        CapState caps = GetCapStateOfWord(word);
        string lower = ConvertStringToLower(word);
        char punctuation = GetPunctuation(lower);
        if (punctuation != (char)0) {
            lower = lower.Remove(lower.Length - 1);
        }
        string translated = dict.GetTranslatedWord(lower);
        return RestoreString(translated, caps, punctuation);
    }

    private CapState GetCapStateOfWord(string word) {
        if (Char.IsUpper(word[0])) {
            foreach (char c in word) {
                if (Char.IsLower(c)) {
                    return CapState.First;
                }
            }
            return CapState.All;
        } else {
            return CapState.None;
        }
    }

    private char GetPunctuation(string word) {
        char lastChar = word[word.Length - 1];
        if (Char.IsPunctuation(lastChar)) {
            return lastChar;
        } else {
            return (char)0;
        }
    }

    private string ConvertStringToLower(string word) {
        StringBuilder sb = new StringBuilder(word);
        for (int i = 0; i < sb.Length; i++) {
           sb[i] = Char.ToLower(sb[i]);
        }
        return sb.ToString();
    }

    private string RestoreString(string word, CapState caps, char punctuation) {
        StringBuilder sb = new StringBuilder(word);
        if (punctuation != (char)0) {
            sb.Append(punctuation);
        }
        if (caps == CapState.First) {
            sb[0] = Char.ToUpper(sb[0]);
        } else if (caps == CapState.All) {
            for (int i = 0; i < sb.Length; i++) {
                sb[i] = Char.ToUpper(sb[i]);
            }
        }
        return sb.ToString();
    }
}

class Program
{   
    static void Main(string[] args)
    {
        Console.WriteLine("Write something, and I'll translate it to medieval speak!");
        string input = Console.ReadLine()!;
        if (input.Length > 0){
            WordTranslator translator = new WordTranslator();
            string translated = translator.TranslateSentence(input);
            Console.WriteLine("What you entered translates to...");
            Console.WriteLine(translated);
            string fileName = "MedievalTranslation.json"; 
            string jsonString = JsonSerializer.Serialize(translated);
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine("Translation serialized and saved to "+fileName);
        } else {
            throw new ArgumentException("Input cannot be empty string");
        }
    }
}
