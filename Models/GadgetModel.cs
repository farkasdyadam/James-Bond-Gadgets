using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_CRUD_App_James_Bond_Gadgets_.Models
{
    public class GadgetModel
    {
       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        //[DisplayName("Appears in this movie")]
        public string AppearsIn { get; set; }
        [Required]
        public string WithThisActor { get; set; }

        public GadgetModel()
        {
            Id = -1;
            Name = "NOTHING";
            Description = "NOTHING";
            AppearsIn = "NOWHER";
            WithThisActor = "WITH NO ONE";
        }

        public GadgetModel(int id, string name, string description, string appersIn, string withThisActor)
        {
            Id = id;
            Name = name;
            Description = description;
            AppearsIn = appersIn;
            WithThisActor = withThisActor;
        }
    }
}
