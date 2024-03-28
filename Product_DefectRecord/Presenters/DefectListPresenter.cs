using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Product_DefectRecord.Presenters
{
    public class DefectListPresenter
    {
        private readonly IDefectListView view;
        private readonly IDefectRepository defectRepository;
        private readonly IModelNumberRepository modelNumberRepository;
        private readonly BindingSource defectsBindingSource;
        private IEnumerable<DefectModel> defectList;

        public DefectListPresenter(IDefectListView view, IDefectRepository defectRepository, IModelNumberRepository modelNumberRepository)
        {
            this.view = view;
            this.defectRepository = defectRepository;
            this.modelNumberRepository = modelNumberRepository;
            this.view.SearchModelNumber += SearchModelNumber;
            this.view.ClearEvent += ClearAction;
            this.view.DefectFilterEvent += LoadFilterDefect;
            this.view.EditButtonClicked += EditButtonClicked;
            this.view.CellClicked += CellClicked;
            
            defectsBindingSource = new BindingSource();
            this.view.SetDefectListBindingSource(defectsBindingSource);
            LoadAllDefectList();
            this.view.Show();
        }

        private void CellClicked(object sender, EventArgs e)
        {
            var defect = (DefectModel)defectsBindingSource.Current;
            PopUp popUp = new PopUp
            {
                SerialNumber = view.SerialNumber,
                ModelNumber = view.ModelNumber,
                DefectName = defect.DefectName1
            };
            popUp.Show();
        }

        private void EditButtonClicked(object sender, EventArgs e)
        {
            new EditDefectPresenter(new EditDefectView(), defectRepository, (DefectModel)defectsBindingSource.Current);
        }

        private void LoadFilterDefect(object sender, EventArgs e, int id)
        {
            if (id != 0)
            {
                defectList = defectRepository.GetFilter(id);
            }
            else
            {
                defectList = defectRepository.GetAll();
            }
            defectsBindingSource.DataSource = defectList;
        }

        private void ClearAction(object sender, EventArgs e)
        {
            view.StatusText = "No Data";
        }

        private void LoadAllDefectList()
        {
            defectList = defectRepository.GetAll();
            defectsBindingSource.DataSource = defectList;
        }

        public delegate void TopDefectEventHandler(object sender, EventArgs e, int id);
        private void SearchModelNumber(object sender, ModelEventArgs e)
        {
            //string message = e.Message;
            //var searchModel = repository2.GetModelNumber(ModelCode);

            var model = new ModelCode
            {
                modelCode1 = view.ModelCode
            };

            var searchModel = modelNumberRepository.GetModelNumber(model);

            if (searchModel != null)
            {
                view.ModelNumber = searchModel.ModelNumber;
                Console.WriteLine("Value of modelnumber: " + view.ModelNumber);
            }
        }
    }
}
