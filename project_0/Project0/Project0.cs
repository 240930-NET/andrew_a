﻿using System;

namespace Project0.Program;

public class WordTranslator {
    public string TranslateWord(string toTranslate) {
        if (toTranslate == "the") {
            return "thy";
        } else if (toTranslate == "here") {
            return "hither";
        } else {
            return toTranslate;
        }
    }
}

class Program
{   
    static void Main(string[] args)
    {
        Console.WriteLine("Write something, and I'll translate it to pirate speak!");
        string input = Console.ReadLine()!;
        string[] words = input.Split(' ');

        WordTranslator translator = new WordTranslator();
        string translated = "";
        
        foreach (string word in words) {
            translated += translator.TranslateWord(word);
            translated += " ";
        }

        Console.WriteLine(translated);
    }
}
