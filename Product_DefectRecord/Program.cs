using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Windows.Forms;
using System.Configuration;
using Product_DefectRecord.Presenters;

namespace Product_DefectRecord
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["LSBUDBConnection"].ConnectionString;
            IDefectListView view = new DefectListView();
            IDefectRepository repository = new DefectRepository(sqlConnectionString);
            IModelNumberRepository repository2 = new ModelNumberRepository(sqlConnectionString);
            new DefectListPresenter(view, repository, repository2);
            Application.Run((Form)view);
        }
    }
}
