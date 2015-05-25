namespace BreadTalk.WebAPI.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using BreadTalk.WebAPI.Models;

    public class PeopleController : ApiController
    {
        private static IList<People> peoples = new List<People>()
                                                   {
                                                       new People { Name = "Khoa Le" }
                                                   };

        public IEnumerable<People> GetPeoples()
        {
            return peoples;
        }

        public IHttpActionResult GetPeople(int id)
        {
            if (id >= peoples.Count)
            {
                return this.NotFound();
            }

            return this.Ok(peoples[id]);
        }

        //public People GetPeople(int id)
        //{
        //    if (id >= peoples.Count)
        //    {
        //        return null;
        //    }

        //    return peoples[id];
        //}

        public IHttpActionResult Post(People people)
        {
            if (people == null)
            {
                throw new ArgumentNullException("people");
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            peoples.Add(people);

            // Hypermedia linking
            var uri = new Uri(this.Url.Link("DefaultApi", new { id = peoples.Count - 1 }));
            return this.Created(uri, people);
        }

        //public void Post(People people)
        //{
        //    if (people == null)
        //    {
        //        throw new ArgumentNullException("people");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        var responseMessage = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
        //        throw new HttpResponseException(responseMessage);
        //    }

        //    peoples.Add(people);
        //}

        public void Put(int id, People people)
        {
            // Do not use Id property in Model
            if (id >= peoples.Count)
            {
                throw new HttpResponseException(
                    this.Request.CreateResponse(HttpStatusCode.NotFound));
            }

            peoples[id] = people;
        }
    }
}