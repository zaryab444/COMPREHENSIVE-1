using System;

namespace WebAPI.Models
{
    public class BaseEnity
    {
        public int Id {get; set;}

        public DateTime LastUpdatedOn {get; set;} = DateTime.Now;

        public int LastUpdatedBy {get; set;}
    }
}
