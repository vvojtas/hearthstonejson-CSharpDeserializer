# hearthstonejson-CSharpDeserializer
Very little deserializer for data from Hearthstonejson http://hearthstonejson.com/

[Also - all json files in TestFiles folder comes (or are based on) from there]

Only goal of this project was to deserialize AllSets.json and return list of cards to use them in .NET application.
You can use it as a jump start if you (just like me) want to work with Hearthstonejson files.

Usage:
```
var loader = new JSONCardLoader(@"FilePath\AllSets.json");
var cards = loader.LoadCards();
```


#License and Copyright(back to top)

Card names and text are all copyright Blizzard Entertainment.
