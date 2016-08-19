using System.Runtime.Serialization;

namespace WcfService.Models
{
    [DataContract]
    public class EmployeeModel
    {

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}