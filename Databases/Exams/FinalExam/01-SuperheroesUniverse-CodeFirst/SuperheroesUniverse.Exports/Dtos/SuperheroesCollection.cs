namespace SuperheroesUniverse.Exports.Dtos
{
    using System.Xml.Serialization;

    [XmlRoot("superheroes")]
    public class SuperheroesCollection
    {
        [XmlElement("superhero")]
        public SuperheroDto[] Superheroes { get; set; }

        public SuperheroDto this[int i]
        {
            get { return Superheroes[i]; }
        }
    }
}
