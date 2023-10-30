using System;
using System.Collections.Generic;

namespace AutoComplete
{
    public class Autocomplete : Trie
    {
        public List<string> GetMatches(string prefix)
        {
            var allMatches = new List<string>();
            var currentNode = Root;
            foreach (var character in prefix)
            {
                var findTrieNodeWithCharacter = currentNode.Children.Find(trieNode => trieNode.Value == character);
                if (findTrieNodeWithCharacter == null) return allMatches;
                else
                {
                    currentNode = findTrieNodeWithCharacter;
                }
            }
            if (currentNode.End) allMatches.Add(prefix);

            foreach (var trieNode in currentNode.Children)
            {
                foreach (var stringVersion in GetRecursiveStrings(trieNode))
                {
                    allMatches.Add(prefix + stringVersion);
                }
            }
            return allMatches;
        }

        public List<string> GetRecursiveStrings(TrieNode trieNode)
        {
            var matches = new List<string>();
            var trieNodeCharacter = trieNode.Value;
            if (trieNode.Children.Count == 0)
            {
                matches.Add(trieNodeCharacter.ToString());
                return matches;
            }
            if (trieNode.End) 
            {
                matches.Add(trieNodeCharacter.ToString());
            }
            foreach (var childrenTrieNode in trieNode.Children)
            {
                foreach (var stringVersion in GetRecursiveStrings(childrenTrieNode))
                {
                    matches.Add(trieNodeCharacter + stringVersion);
                }
            }
            return matches;
        }
    }
}
