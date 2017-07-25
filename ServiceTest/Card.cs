namespace ServiceTest
{ 
    [System.Xml.Serialization.XmlType(AnonymousType = true)] 
    public partial class cockatrice_carddatabase
    { 
        [System.Xml.Serialization.XmlArrayItem("set", IsNullable = false)]
        public cockatrice_carddatabaseSet[] sets
        {
            get;
            set;
        } 
        [System.Xml.Serialization.XmlArrayItem("card", IsNullable = false)]
        public card[] cards
        {
            get;
            set;
        } 
        [System.Xml.Serialization.XmlAttribute()]
        public byte version
        {
            get;
            set;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cockatrice_carddatabaseSet
    {
        /// <remarks/>
        public string name
        {
            get;
            set;
        }

        /// <remarks/>
        public string longname
        {
            get;
            set;
        }

        /// <remarks/>
        public string settype
        {
            get;
            set;
        }
    }
    public partial class card
    {
        public string name
        {
            get;
            set;
        }
        public string manacost
        {
            get;
            set;
        }
        public string type
        {
            get;
            set;
        }
        public string set
        {
            get;
            set;
        }
        public string text
        {
            get;
            set;
        }
        public string pt
        {
            get;
            set;
        }
    }
}
