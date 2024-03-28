using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Windows.Forms;

namespace Product_DefectRecord.Presenters
{
    public class EditDefectPresenter
    {
        private readonly IEditDefectView view;
        private readonly IDefectRepository repository;

        public EditDefectPresenter(IEditDefectView view, IDefectRepository repository, DefectModel defect)
        {
            this.view = view;
            this.repository = repository;
            this.view.EditEvent += EditEvent;
            SetData(defect);
            this.view.Show();
        }

        private void SetData(DefectModel defect)
        {
            view.DefectId = defect.Id1.ToString();
            view.PartId = defect.PartId1;
            view.DefectName = defect.DefectName1;
            view.IsEdit = true;
        }

        private void EditEvent(object sender, EventArgs e)
        {
            var model = new DefectModel
            {
                Id1 = Convert.ToInt32(view.DefectId),
                PartId1 = view.PartId,
                DefectName1 = view.DefectName
            };
            Console.WriteLine("ini defect" +view.DefectName);

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)
                {
                    repository.Edit(model);
                    view.Message = "Defect telah terubah";
                }
                view.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }

            if (view.IsSuccessful)
            {
                MessageBox.Show("Berhasil");
            }
            else
            {
                MessageBox.Show("Gagal: " + view.Message);
            }
        }
    }
}
