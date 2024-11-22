using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfApplication1.ViewModels
{
    public class EmployeeModel 
    {
        
            // wrapping
            private readonly Employee _monEmployee;

            public Employee MonEmployee
            {
                get { return _monEmployee; }
            }


            public EmployeeModel(Employee current)
            {
                this._monEmployee = current;
            }

            public String DisplayBirthDate
            {
                get
                {
                    if (_monEmployee.BirthDate.HasValue)
                    {
                        return _monEmployee.BirthDate.Value.ToShortDateString();
                    }

                    return "";
                }
            }

           public string TitleOfCourtesy
            {
                get { return _monEmployee.TitleOfCourtesy; }
                set { _monEmployee.TitleOfCourtesy = value; 
                }
            }

            public String FullName
            {
                get
                {
                    return String.Format("{0} {1}", _monEmployee.FirstName, _monEmployee.LastName).Trim();
                }
            }

            public String LastName
            {
                get { return _monEmployee.LastName; }
                set { _monEmployee.LastName = value; 
             
                }
            }
            public String FirstName
            {
                get { return _monEmployee.FirstName; }
                set { _monEmployee.FirstName = value; 
              
                }
            }
            public DateTime? BirthDate
            {
                get { return _monEmployee.BirthDate; }
                set { _monEmployee.BirthDate = value; 
            
                }
            }
            public DateTime? HireDate
            {
                get { return _monEmployee.HireDate; }
                set { _monEmployee.HireDate = value; 
               
                
                }
            }
           

       
    }
}
