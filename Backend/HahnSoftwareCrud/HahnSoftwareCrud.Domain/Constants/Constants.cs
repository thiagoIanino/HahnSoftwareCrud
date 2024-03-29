﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Domain.Constants
{
    public static class Constants
    {
        public const string RequiredIdMessageError = "Id is required";

        public const string ItemNotFound = "The requested Item wasn't found";
        public const string DefaultErrorMessage = "Something went wrong. Try again later";

        public const string ResponseUri = "http://localhost:5001/items/";

    }
}
