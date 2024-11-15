using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class GestionnaireTaches
    {
        private IList<Tache> taches;

        public GestionnaireTaches()
        {
            taches = new List<Tache>();
            taches.Add(new Tache("super tâche"));
        }

        public IList<Tache> ListeTaches {
            get { return taches; }
        }
    }

    public class Tache
    {
        private string _description;
        private int _priorité;
        private DateTime _date;
        private bool _termine;

        public Tache(string description)
        {
            _description = description;
            _priorité = 3;
            _date = DateTime.Now;
            _termine = false;
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Priorité
        {
            get { return _priorité; }
            set { _priorité = value; }
        }

        public DateTime Date
        {
            get { return _date.Date; }
            set { _date = value; }
        }

        public bool Termine
        {
            get { return _termine; }
            set { _termine = value; }
        }
    }
}
