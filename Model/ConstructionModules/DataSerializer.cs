using System.IO;
using System.Runtime.Serialization;
using Model.ConstructionModules.Saving;

namespace Model.ConstructionModules
{
    class DataSerializer
    {
        public static void SerializeData(string fileName, Memento state)
        {
            var formatter = new DataContractSerializer(typeof(Memento));
            var s = new FileStream(fileName,FileMode.OpenOrCreate);
            formatter.WriteObject(s,state);
            s.Close();
        }

        public static Memento DeserializeState(string fileName)
        {
            var s=new FileStream(fileName, FileMode.Open);
            var formatter=new DataContractSerializer(typeof(Memento));
            return (Memento) formatter.ReadObject(s);
        }
    }
}
