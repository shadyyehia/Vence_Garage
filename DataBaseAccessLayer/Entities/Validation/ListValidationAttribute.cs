﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Validation
{
    public class IsNotEmptyAttribute : ValidationAttribute
    {
        private readonly int _minElements;
        public IsNotEmptyAttribute(int minElements)
        {
            _minElements = minElements;
        }

        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count >= _minElements;
            }
            return false;
        }
    }
}
