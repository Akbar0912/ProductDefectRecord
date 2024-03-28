using System.ComponentModel;

namespace Product_DefectRecord.Models
{
    public class ModelCode
    {
        private string serialNumber;
        private string modelCode;
        private string modelNumber;

        public string SerialNumber 
        {
            get => serialNumber;
            set => serialNumber = value;
        }


        [DisplayName("modelCode")]
        public string modelCode1
        {
            get => modelCode;
            set => modelCode = value;
        }

        [DisplayName("ModelNumber")]
        public string ModelNumber 
        { 
            get => modelNumber; 
            set => modelNumber = value;
        }
    }
}
