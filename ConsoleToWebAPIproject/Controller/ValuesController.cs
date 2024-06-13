﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ConsoleToWebAPIproject.Controller
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("api/get-all")]
        public string Getall ()
        {
            return "Hello get-all";
        }

        [Route("api/get-all-Author")]
        public string GetAllAuthor()
        {
            return "Hello get-all-Author";
        }

        [Route("collage/{id}")]
        public string GetById(int id)
        {
            return "Hello Get By id " + id;
        }

        [Route("collage/{id}/author/{authorid}")]
        public string GetByAuthorId(int id, int authorid)
        {
            return "Hello Get By id " + id + " " + "Author Id is " + authorid;
        }
        [Route("Search")]
        public string SearchBook(string name , int id , string Authorid , float rating , float price) 
        {
            return "Book name : " + name + " | " + "id : " + id + " | " + "Author Id : " + Authorid + " | " + "Rating : " + rating + " | " + "Price :" + price;
        }


    }
}
