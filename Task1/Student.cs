namespace Task1;

public class Student: IEquatable<Student>
{
    private string _firstName;
    private string _lastName;
    private string _patronymic;
    private string _group;
    private string _project;

    public Student(string firstName = "", string lastName = "", string patronymic = "", string group ="", string project ="")
    {
        if (
            string.IsNullOrEmpty(firstName) ||
            string.IsNullOrEmpty(lastName) ||
            string.IsNullOrEmpty(patronymic) ||
            string.IsNullOrEmpty(group) ||
            string.IsNullOrEmpty(project)
            )
        {
            throw new ArgumentNullException();
        }

        _firstName = firstName;
        _lastName = lastName;
        _patronymic = patronymic;
        _group = group;
        _project = project;
    }

    public string FirstName
    {
        get
        {
            return _firstName;
        }
    }
    
    public string LastName
    {
        get
        {
            return _lastName;
        }
    }
    
    public string Patronymic
    {
        get
        {
            return _patronymic;
        }
    }
    
    public string Group
    {
        get
        {
            return _group;
        }
    }

    public string Project
    {
        get
        {
            return _project;
        }
    }
    
    public int getCourseNumberFromGroup
    {
        get
        {
            string[] groupParts = _group.Split('-');
            
            string yearString = groupParts[2].Substring(0, 4);
            int year;
            if (!int.TryParse(yearString, out year))
            {
                throw new FormatException();
            }

            int currentYear = DateTime.Now.Year;
            int courseNumber = currentYear - year;
            return courseNumber;
        }
    }

    public override string ToString()
    {
        return $"Student: {FirstName} {LastName} {Patronymic}\n" +
               $"Study Group: {Group}\n" +
               $"Practice Course: {Project}\n" +
               $"Course Number: {getCourseNumberFromGroup}";
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, Patronymic, Group, Project);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Student))
        {
            return false;
        }

        return Equals((Student)obj);
    }

    public bool Equals(Student other)
    {
        if (other == null)
        {
            return false;
        }
        
        // return FirstName == other.FirstName &&
        //        LastName == other.LastName &&
        //        Patronymic == other.Patronymic &&
        //        Group == other.Group &&
        //        Project == other.Project;
        // //Можно было сделать и так, и так ?
        return FirstName.Equals(other.FirstName) &&
               LastName.Equals(other.LastName) &&
               Patronymic.Equals(other.Patronymic) &&
               Group.Equals(other.Group) &&
               Project.Equals(other.Project);
    }
}
