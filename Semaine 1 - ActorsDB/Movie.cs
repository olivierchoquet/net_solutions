using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.ipl.domaine;

internal class Movie
{

    private string _title;
    private int _releaseYear;
    private List<Actor> _actors;
    private Director? _director = null;

    public Movie(String title, int releaseYear)
    {
        _actors = new List<Actor>();
        this._title = title;
        this._releaseYear = releaseYear;
    }

    // ? -> nullable
    public Director? Director
    {
        get { return _director; }
        set
        {
            if (value == null)
                return;

            this._director = value;
            _director?.AddMovie(this);

        }
    }

    // Properties with get and set 
    // Use of property 
    // Movie m = new Movie();
    // m.Title = "E.T";
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }


    public int ReleaseYear
    {
        get { return _releaseYear; }
        set { _releaseYear = value; }
    }


    public bool AddActor(Actor actor)
    {
        if (_actors.Contains(actor))
            return false;

        _actors.Add(actor);
        if (!actor.ContainsMovie(this))
            actor.AddMovie(this);

        return true;
    }

    public bool ContainsActor(Actor actor)
    {
        return _actors.Contains(actor);
    }

    public override string ToString()
    {
        return "Movie [title=" + _title + ", releaseYear=" + _releaseYear + "]";
    }

}
