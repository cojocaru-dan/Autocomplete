using System;

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
            throw new NotImplementedException();
        }

        public bool Remove(string word)
        {
            // This function is optional
            throw new NotImplementedException();
        }
    }
}
