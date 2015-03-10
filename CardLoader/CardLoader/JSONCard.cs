﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLoader
{
    [JsonObject]
    public class JSONCard
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public int? Cost { get; set; }

        public string Rarity { get; set; }
        
        public string Faction { get; set; }

        public string Race { get; set; }

        public string PlayerClass { get; set; }

        public string InPlayText { get; set; }

        public List<string> Mechanics { get; set; }

        public string Flavor { get; set; }

        public string Artist { get; set; }

        public int? Attack { get; set; }

        public int? Health { get; set; }

        public int? Durability { get; set; }

        public bool Collectible { get; set; }

        public bool Elite { get; set; }

        public string HowToGet { get; set; }

        public string HowToGetGold { get; set; }

        public string Set { get; set; }

        public JSONCard()
        {
            this.Mechanics = new List<string>();
        }
    }
}
