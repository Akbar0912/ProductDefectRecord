using System;

namespace Product_DefectRecord.Views
{
    public interface IEditDefectView
    {
        string DefectId { get; set; }
        string PartId { get; set; }
        string DefectName { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler EditEvent;

        void Show();
    }
}
