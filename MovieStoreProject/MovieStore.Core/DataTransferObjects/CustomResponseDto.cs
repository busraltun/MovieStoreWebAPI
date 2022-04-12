﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MovieStore.Core.DataTransferObjects
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        //status code client lara dönmeyecek
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }


        //Factory Design Pattern -   Static Factor Method
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T>
            {
                Data = data,
                StatusCode = statusCode,
                //Errors = null
            };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T>
            {

                StatusCode = statusCode,
                //Errors = null
            };
        }
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
                Errors = errors
            };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
                Errors = new List<string> { error }
            };
        }

    }
}