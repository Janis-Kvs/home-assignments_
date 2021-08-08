using System;

namespace BackendDeveloper.Assignment3
{
    public class PersonParser
    {
        public void Parse(string sourceType, string file)
        {
            var persons = new PersonList();

            switch (sourceType)
            {
                case "bin":
                {
                    var parser = new BinaryParser(ServiceLocator.Current.GetInstance<BinaryReader>());
                    parser.Open(file);

                    while (!parser.HasReachedEnd)
                    {
                        persons.Add(parser.GetPerson());
                    }

                    parser.Close();
                }
                break;

                case "xml":
                {
                    var parser = new XmlParser(file);
                    parser.StartParse();

                    Person parsedPerson;
                    while ((parsedPerson = parser.GetNextPerson()) != null)
                    {
                        persons.Add(parsedPerson);
                    }

                    parser.FinishParse();
                }
                break;

                case "http":
                {
                    var parser = new SomeApiClient("https://someserver/api/endpoint");
                    parser.Connect();

                    Person parsedPerson;
                    while ((parsedPerson = parser.GetNextPersonAsync().Result) != null)
                    {
                        persons.Add(parsedPerson);
                    }

                    parser.FinishParse();
                }
                break;
            }

            return persons;
        }
    }
}