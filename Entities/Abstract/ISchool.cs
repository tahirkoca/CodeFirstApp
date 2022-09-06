using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface ISchool
    {
        int ID { get; set; }
        string Name { get; set; }
        int NumberOfStudent { get; set; }
        int NumberOfEmployee { get; set; }
        
        //Bire çok bağlantının çok kısmı(Bir okulun birden çok öğretmeni olur) 
        List<Teacher> Teachers { get; set; }
    }
}
