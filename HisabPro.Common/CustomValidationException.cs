﻿namespace HisabPro.Common
{
    public class CustomValidationException : Exception
    {
        public int StatusCode { get; } = 400;

        public CustomValidationException(string message) : base(message) { }
    }
}
