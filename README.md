# hearthstonejson-CSharpDeserializer
Very little deserializer for data from Hearthstonejson http://hearthstonejson.com/

Only goal of this project was to deserialize AllSets.json and return list of cards to use them in .NET application.

Usage:
```
var loader = new JSONCardLoader(@"TestFiles\Leeroy.json");
var cards = loader.LoadCards();
```
