using DatabaseAccessLayer;
using ProductBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProductBooking.Controllers
{
    public class ActivityController:ApiController
    {
        [HttpGet]
        public IEnumerable<Activity> ActivitysList()
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {


                return Entities.Activities.ToList();
            }
        }
        [HttpPost]
        public void AddActivity([FromBody]Activity Activity)
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {
                //int id = Activity.Id;

                var id = Entities.Activities.Max(p => p.Id);
                Activity.Id = id + 1;

                Entities.Activities.Add(Activity);

                Entities.SaveChanges();
                //return Entities.Activitys.Add(Activity);
            }
        }

        [HttpPut]
        public void book([FromBody]ItemUrl obj)
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {
                Activity existActivity = null;
                existActivity = Entities.Activities.Find(obj.id);


                if (obj.type.Equals("book"))
                {
                    if (existActivity != null)
                    {
                        existActivity.Book = 1;
                        Entities.SaveChanges();

                    };
                }

                else if (obj.type.Equals("save"))
                {
                    if (existActivity != null)
                    {
                        existActivity.SaveProduct = 0;
                        Entities.SaveChanges();

                    };
                }

            }



        }



    }
}