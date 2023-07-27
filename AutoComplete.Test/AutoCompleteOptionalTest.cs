using NUnit.Framework;

namespace AutoComplete.Test
{
    public class AutoCompleteOptionalTest
    {
        private Autocomplete _autocomplete;

        [SetUp]
        public void Setup()
        {
            _autocomplete = new Autocomplete();
        }

        [Test]
        public void TestAfterInsertAutoThenAutocomplete_RemoveAutocompleteReturnsTrue()
        {
            _autocomplete.Insert("auto");
            _autocomplete.Insert("autocomplete");
            Assert.IsTrue(_autocomplete.Remove("autocomplete"));
        }

        [Test]
        public void TestAfterInsertAutoThenAutocomplete_AndRemoveAutocomplete_GetMatchesCantFindAnyMatchesForAutocomplete()
        {
            _autocomplete.Insert("auto");
            _autocomplete.Insert("autocomplete");
            _autocomplete.Remove("autocomplete");
            Assert.IsEmpty(_autocomplete.GetMatches("autocomplete"));
        }

        [Test]
        public void TestAfterInsertAutoThenAutocomplete_RemoveTrieReturnsFalse()
        {
            _autocomplete.Insert("auto");
            _autocomplete.Insert("autocomplete");
            Assert.IsFalse(_autocomplete.Remove("trie"));
        }

        [Test]
        public void TestAfterInsertAutoThenAutocomplete_AndRemoveTrie_GetMatchesCanFindAutoAndAutocomplete_BySearchForAuto()
        {
            _autocomplete.Insert("auto");
            _autocomplete.Insert("autocomplete");
            _autocomplete.Remove("trie");

            var expected = new[] {"auto", "autocomplete"};
            CollectionAssert.AreEquivalent(expected, _autocomplete.GetMatches("auto"));
        }
    }
}
