using System;
using System.Windows.Forms;

namespace Product_DefectRecord.Views
{
    public partial class EditDefectView : Form, IEditDefectView
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public EditDefectView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSave.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    MessageBox.Show("Berhasil");
                }
                MessageBox.Show("Gagal diEdit");
            };

            btnCancel.Click += delegate
            {
                Close();
            };
        }

        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string DefectId
        {
            get { return textDefectId.Text; }
            set { textDefectId.Text = value; }
        }

        public string PartId
        {
            get { return textPartId.Text; }
            set { textPartId.Text = value; }
        }

        public string DefectName
        {
            get { return textDefectName.Text; }
            set { textDefectName.Text = value; }
        }

        public event EventHandler EditEvent;
    }
}
