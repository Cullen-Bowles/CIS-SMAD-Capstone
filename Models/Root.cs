namespace WebApplication4.Models
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Root
    {
        [JsonProperty("sentence")] public string Sentence { get; set; }

        [JsonProperty("sentenceNbr")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long SentenceNbr { get; set; }

        [JsonProperty("tokens")] public string[] Tokens { get; set; }

        //[JsonProperty("pos")] public Po[] Pos { get; set; }

        //[JsonProperty("ner")] public Ner[] Ner { get; set; }

        //[JsonProperty("lemmas")] public string[] Lemmas { get; set; }
    }

    public enum Ner
    {
        CauseOfDeath,
        City,
        Country,
        CriminalCharge,
        Date,
        Duration,
        Ideology,
        Location,
        Misc,
        Nationality,
        Number,
        O,
        Ordinal,
        Organization,
        Person,
        Religion,
        StateOrProvince,
        Time,
        Title,
        Url
    }

    public enum Po
    {
        Cc,
        Cd,
        Dt,
        Empty,
        Fluffy,
        Fw,
        In,
        Jj,
        Jjr,
        Jjs,
        Lrb,
        Ls,
        Md,
        Nn,
        Nnp,
        Nnps,
        Nns,
        Po,
        PoPrp,
        Pos,
        Prp,
        Purple,
        Rb,
        Rbr,
        Rbs,
        Rp,
        Rrb,
        Tentacled,
        To,
        Vb,
        Vbd,
        Vbg,
        Vbn,
        Vbp,
        Vbz,
        Wdt,
        Wp,
        Wrb
    }

    public partial class Root
    {
        public static Root[] FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Root[]>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Root[] self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                NerConverter.Singleton,
                PoConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            }
        };
    }

    internal class NerConverter : JsonConverter
    {
        public static readonly NerConverter Singleton = new NerConverter();

        public override bool CanConvert(Type t)
        {
            return t == typeof(Ner) || t == typeof(Ner?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CAUSE_OF_DEATH":
                    return Ner.CauseOfDeath;
                case "CITY":
                    return Ner.City;
                case "COUNTRY":
                    return Ner.Country;
                case "CRIMINAL_CHARGE":
                    return Ner.CriminalCharge;
                case "DATE":
                    return Ner.Date;
                case "DURATION":
                    return Ner.Duration;
                case "IDEOLOGY":
                    return Ner.Ideology;
                case "LOCATION":
                    return Ner.Location;
                case "MISC":
                    return Ner.Misc;
                case "NATIONALITY":
                    return Ner.Nationality;
                case "NUMBER":
                    return Ner.Number;
                case "O":
                    return Ner.O;
                case "ORDINAL":
                    return Ner.Ordinal;
                case "ORGANIZATION":
                    return Ner.Organization;
                case "PERSON":
                    return Ner.Person;
                case "RELIGION":
                    return Ner.Religion;
                case "STATE_OR_PROVINCE":
                    return Ner.StateOrProvince;
                case "TIME":
                    return Ner.Time;
                case "TITLE":
                    return Ner.Title;
                case "URL":
                    return Ner.Url;
            }

            throw new Exception("Cannot unmarshal type Ner");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (Ner)untypedValue;
            switch (value)
            {
                case Ner.CauseOfDeath:
                    serializer.Serialize(writer, "CAUSE_OF_DEATH");
                    return;
                case Ner.City:
                    serializer.Serialize(writer, "CITY");
                    return;
                case Ner.Country:
                    serializer.Serialize(writer, "COUNTRY");
                    return;
                case Ner.CriminalCharge:
                    serializer.Serialize(writer, "CRIMINAL_CHARGE");
                    return;
                case Ner.Date:
                    serializer.Serialize(writer, "DATE");
                    return;
                case Ner.Duration:
                    serializer.Serialize(writer, "DURATION");
                    return;
                case Ner.Ideology:
                    serializer.Serialize(writer, "IDEOLOGY");
                    return;
                case Ner.Location:
                    serializer.Serialize(writer, "LOCATION");
                    return;
                case Ner.Misc:
                    serializer.Serialize(writer, "MISC");
                    return;
                case Ner.Nationality:
                    serializer.Serialize(writer, "NATIONALITY");
                    return;
                case Ner.Number:
                    serializer.Serialize(writer, "NUMBER");
                    return;
                case Ner.O:
                    serializer.Serialize(writer, "O");
                    return;
                case Ner.Ordinal:
                    serializer.Serialize(writer, "ORDINAL");
                    return;
                case Ner.Organization:
                    serializer.Serialize(writer, "ORGANIZATION");
                    return;
                case Ner.Person:
                    serializer.Serialize(writer, "PERSON");
                    return;
                case Ner.Religion:
                    serializer.Serialize(writer, "RELIGION");
                    return;
                case Ner.StateOrProvince:
                    serializer.Serialize(writer, "STATE_OR_PROVINCE");
                    return;
                case Ner.Time:
                    serializer.Serialize(writer, "TIME");
                    return;
                case Ner.Title:
                    serializer.Serialize(writer, "TITLE");
                    return;
                case Ner.Url:
                    serializer.Serialize(writer, "URL");
                    return;
            }

            throw new Exception("Cannot marshal type Ner");
        }
    }

    internal class PoConverter : JsonConverter
    {
        public static readonly PoConverter Singleton = new PoConverter();

        public override bool CanConvert(Type t)
        {
            return t == typeof(Po) || t == typeof(Po?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "''":
                    return Po.Purple;
                case ",":
                    return Po.Empty;
                case "-LRB-":
                    return Po.Lrb;
                case "-RRB-":
                    return Po.Rrb;
                case ".":
                    return Po.Po;
                case ":":
                    return Po.Tentacled;
                case "CC":
                    return Po.Cc;
                case "CD":
                    return Po.Cd;
                case "DT":
                    return Po.Dt;
                case "FW":
                    return Po.Fw;
                case "IN":
                    return Po.In;
                case "JJ":
                    return Po.Jj;
                case "JJR":
                    return Po.Jjr;
                case "JJS":
                    return Po.Jjs;
                case "LS":
                    return Po.Ls;
                case "MD":
                    return Po.Md;
                case "NN":
                    return Po.Nn;
                case "NNP":
                    return Po.Nnp;
                case "NNPS":
                    return Po.Nnps;
                case "NNS":
                    return Po.Nns;
                case "POS":
                    return Po.Pos;
                case "PRP":
                    return Po.Prp;
                case "PRP$":
                    return Po.PoPrp;
                case "RB":
                    return Po.Rb;
                case "RBR":
                    return Po.Rbr;
                case "RBS":
                    return Po.Rbs;
                case "RP":
                    return Po.Rp;
                case "TO":
                    return Po.To;
                case "VB":
                    return Po.Vb;
                case "VBD":
                    return Po.Vbd;
                case "VBG":
                    return Po.Vbg;
                case "VBN":
                    return Po.Vbn;
                case "VBP":
                    return Po.Vbp;
                case "VBZ":
                    return Po.Vbz;
                case "WDT":
                    return Po.Wdt;
                case "WP":
                    return Po.Wp;
                case "WRB":
                    return Po.Wrb;
                case "``":
                    return Po.Fluffy;
            }

            throw new Exception("Cannot unmarshal type Po");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (Po)untypedValue;
            switch (value)
            {
                case Po.Purple:
                    serializer.Serialize(writer, "''");
                    return;
                case Po.Empty:
                    serializer.Serialize(writer, ",");
                    return;
                case Po.Lrb:
                    serializer.Serialize(writer, "-LRB-");
                    return;
                case Po.Rrb:
                    serializer.Serialize(writer, "-RRB-");
                    return;
                case Po.Po:
                    serializer.Serialize(writer, ".");
                    return;
                case Po.Tentacled:
                    serializer.Serialize(writer, ":");
                    return;
                case Po.Cc:
                    serializer.Serialize(writer, "CC");
                    return;
                case Po.Cd:
                    serializer.Serialize(writer, "CD");
                    return;
                case Po.Dt:
                    serializer.Serialize(writer, "DT");
                    return;
                case Po.Fw:
                    serializer.Serialize(writer, "FW");
                    return;
                case Po.In:
                    serializer.Serialize(writer, "IN");
                    return;
                case Po.Jj:
                    serializer.Serialize(writer, "JJ");
                    return;
                case Po.Jjr:
                    serializer.Serialize(writer, "JJR");
                    return;
                case Po.Jjs:
                    serializer.Serialize(writer, "JJS");
                    return;
                case Po.Ls:
                    serializer.Serialize(writer, "LS");
                    return;
                case Po.Md:
                    serializer.Serialize(writer, "MD");
                    return;
                case Po.Nn:
                    serializer.Serialize(writer, "NN");
                    return;
                case Po.Nnp:
                    serializer.Serialize(writer, "NNP");
                    return;
                case Po.Nnps:
                    serializer.Serialize(writer, "NNPS");
                    return;
                case Po.Nns:
                    serializer.Serialize(writer, "NNS");
                    return;
                case Po.Pos:
                    serializer.Serialize(writer, "POS");
                    return;
                case Po.Prp:
                    serializer.Serialize(writer, "PRP");
                    return;
                case Po.PoPrp:
                    serializer.Serialize(writer, "PRP$");
                    return;
                case Po.Rb:
                    serializer.Serialize(writer, "RB");
                    return;
                case Po.Rbr:
                    serializer.Serialize(writer, "RBR");
                    return;
                case Po.Rbs:
                    serializer.Serialize(writer, "RBS");
                    return;
                case Po.Rp:
                    serializer.Serialize(writer, "RP");
                    return;
                case Po.To:
                    serializer.Serialize(writer, "TO");
                    return;
                case Po.Vb:
                    serializer.Serialize(writer, "VB");
                    return;
                case Po.Vbd:
                    serializer.Serialize(writer, "VBD");
                    return;
                case Po.Vbg:
                    serializer.Serialize(writer, "VBG");
                    return;
                case Po.Vbn:
                    serializer.Serialize(writer, "VBN");
                    return;
                case Po.Vbp:
                    serializer.Serialize(writer, "VBP");
                    return;
                case Po.Vbz:
                    serializer.Serialize(writer, "VBZ");
                    return;
                case Po.Wdt:
                    serializer.Serialize(writer, "WDT");
                    return;
                case Po.Wp:
                    serializer.Serialize(writer, "WP");
                    return;
                case Po.Wrb:
                    serializer.Serialize(writer, "WRB");
                    return;
                case Po.Fluffy:
                    serializer.Serialize(writer, "``");
                    return;
            }

            throw new Exception("Cannot marshal type Po");
        }
    }

    internal class ParseStringConverter : JsonConverter
    {
        public static readonly ParseStringConverter Singleton = new ParseStringConverter();

        public override bool CanConvert(Type t)
        {
            return t == typeof(long) || t == typeof(long?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (long.TryParse(value, out l)) return l;
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
        }
    }
}