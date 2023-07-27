using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AutoComplete.Test
{
    public class AutoCompleteTest
    {
        private class SearchlistItem
        {
            public string term;
            public string[] expect;
        }

        private Autocomplete _autocomplete;

        [SetUp]
        public void Setup()
        {
            _autocomplete = new Autocomplete();
        }

        [Test]
        public void TestAfterOneInsert_GetMatchesCanReturnTheInsertedWord()
        {
            _autocomplete.Insert("autocomplete");
            Assert.IsNotEmpty(_autocomplete.GetMatches("autocomplete"));
        }

        [Test]
        public void TestAfterInsertAuto_GetMatchesCantFindAutocomplete()
        {
            _autocomplete.Insert("auto");
            Assert.IsEmpty(_autocomplete.GetMatches("autocomplete"));
        }

        [Test]
        public void TestAfterInsertAutoThenAutocomplete_GetMatchesCanFindTwoMatchesForAuto()
        {
            _autocomplete.Insert("auto");
            _autocomplete.Insert("autocomplete");

            var expected = new[] { "auto", "autocomplete" };

            CollectionAssert.AreEquivalent(expected, _autocomplete.GetMatches("auto"));
        }

        [Test]
        public void TestAfterInsertAutocomplete_GetMatchesCanFindItByAutocomp()
        {
            _autocomplete.Insert("autocomplete");
            var expected = new[] {"autocomplete"};
            CollectionAssert.AreEquivalent(expected, _autocomplete.GetMatches("autocomp"));
        }

        [Test]
        public void TestAfterInsertCaseSensitiveAutocomplete_GetMatchesCantFindIt_ByCaseInsensitiveAuto()
        {
            _autocomplete.Insert("Autocomplete");
            Assert.IsEmpty(_autocomplete.GetMatches("auto"));
        }

        [Test]
        public void TestAfterInsertFromWordlist_GetMatchesFindEverythingFromSearchList()
        {
            var wordList = File.ReadAllLines("wordlist.txt");
            foreach (var word in wordList)
                _autocomplete.Insert(word);

            var searchListString = File.ReadAllText("searchlist.json");
            var searchList = JsonConvert.DeserializeObject<SearchlistItem[]>(searchListString);

            foreach (var searchListItem in searchList)
            {
                CollectionAssert.AreEquivalent(searchListItem.expect, _autocomplete.GetMatches(searchListItem.term));
            }
        }
    }
}