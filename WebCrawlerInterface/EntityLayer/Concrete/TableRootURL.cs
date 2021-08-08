using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //2019103008 non-static class usage
    //2019103009  Public and private class, variable and method usage
    //I used interface inheritance 
    public class TableRootURL:IDatabaseEntity
    {
        //2019103001 Used properties for my table !

        [Key]
        public int RootID { get; set; }

        public string RootUrl { get; set; }
    }
}
