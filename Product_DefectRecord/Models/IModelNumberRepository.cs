namespace Product_DefectRecord.Models
{
    public interface IModelNumberRepository
    {
        ModelCode GetModelNumber(ModelCode model);
    }
}
