﻿namespace SystemEmail.API.Utility
{
    public class Response<T> 
    {

        public bool Status { get; set; }

        public T Value { get; set; } 

        public string Message { get; set; }






    }
}
