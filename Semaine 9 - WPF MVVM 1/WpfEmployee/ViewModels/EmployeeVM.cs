using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfEmployee.Models;

namespace WpfApplication1.ViewModels
{
    public class EmployeeVM 
    {

        #region fields

        private NorthwindContext dc = new NorthwindContext();
        private List<EmployeeModel> _EmployeesList;
        private List<string> _listTitle;

        #endregion

        

        public List<EmployeeModel> EmployeesList
        {
            get {
                return _EmployeesList = _EmployeesList ?? loadEmployee(); 
               
            }
           
        }
  
        private List<EmployeeModel> loadEmployee()
        {
            List<EmployeeModel> localCollection = new List<EmployeeModel>();
            foreach (var item in dc.Employees)
            {
                localCollection.Add(new EmployeeModel(item));
                
            }
            
            return localCollection;
            
        }


        public List<string> ListTitle
        {
            get { return _listTitle = _listTitle ?? LoadTitleOfCourtesy(); }

        }

        private List<string> LoadTitleOfCourtesy()
        {
            return dc.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        }

       

       
    }
}
