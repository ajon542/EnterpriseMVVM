﻿
using System.Linq;

namespace EnterpriseMVVM.Windows
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public abstract class ViewModel : ObservableObject, IDataErrorInfo
    {
        public string Error
        {
            get { throw new NotSupportedException(); }
        }

        public string this[string columnName]
        {
            get { return OnValidate(columnName); }
        }

        protected virtual string OnValidate(string propertyName)
        {
            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };

            var results = new Collection<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);

            if (!isValid)
            {
                ValidationResult result =
                    results.SingleOrDefault(p =>
                        p.MemberNames.Any(memberName => memberName == propertyName));

                return result == null ? null : result.ErrorMessage;
            }

            return null;
        }
    }
}
