using System.Collections.Generic;

namespace AutoComplete
{
    public class TrieNode
    {
        public char Value;
        public List<TrieNode> Children = new();
        public bool End = false;

        public TrieNode(char value)
        {
            Value = value;
        }
    }
}
