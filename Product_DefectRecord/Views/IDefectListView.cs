using System;
using System.Windows.Forms;
using static Product_DefectRecord.Presenters.DefectListPresenter;

namespace Product_DefectRecord.Views
{
    public interface IDefectListView
    {
        string SerialNumber { get; set; }
        string ModelCode { get; set; }
        string ModelNumber { get; set; }
        string StatusText { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }

        event EventHandler<ModelEventArgs> SearchModelNumber;
        event EventHandler ClearEvent;
        event TopDefectEventHandler DefectFilterEvent;
        event EventHandler EditButtonClicked;
        event EventHandler CellClicked;

        void SetDefectListBindingSource(BindingSource defectsBindingSource);
        void FilterByPartId(int partId);
        void ShowPopupForm();
        void Show();
    }

    public class ModelEventArgs : EventArgs
    {
        public string Message { get; set; }

        public ModelEventArgs(string message)
        {
            Message = message;
        }
    }
}
