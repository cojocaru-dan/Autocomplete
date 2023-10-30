using System;
using System.Linq;

namespace AutoComplete
{
    public class Trie
    {
        public TrieNode Root;

        public Trie()
        {
            Root = new TrieNode('\0');
        }

        public void Insert(string word)
        {
            var currentNode = Root;
            foreach (var letter in word)
            {
                var findTrieNodeWithLetter = currentNode.Children.Find(trienode => trienode.Value == letter);
                if (findTrieNodeWithLetter != null)
                {
                    currentNode = findTrieNodeWithLetter;
                } else
                {
                    var newTrieNode = new TrieNode(letter);
                    currentNode.Children.Add(newTrieNode);
                    currentNode = newTrieNode;
                }
            }
            currentNode.End = true;
        }

        public bool Remove(string word)
        {
            // This function is optional
            throw new NotImplementedException();
        }
    }
}
