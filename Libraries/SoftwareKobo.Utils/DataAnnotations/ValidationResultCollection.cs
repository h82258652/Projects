using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SoftwareKobo.DataAnnotations
{
    public class ValidationResultCollection : IReadOnlyCollection<ValidationResult>
    {
        private readonly ICollection<ValidationResult> _results = new List<ValidationResult>();

        public ValidationResultCollection(object verifyObject)
        {
            if (verifyObject == null)
            {
                throw new ArgumentNullException(nameof(verifyObject));
            }

            var context = new ValidationContext(verifyObject);
            Validator.TryValidateObject(verifyObject, context, _results, true);
        }

        public int Count => _results.Count;

        public string this[string propertyName]
        {
            get
            {
                if (propertyName == null)
                {
                    throw new ArgumentNullException(nameof(propertyName));
                }

                return _results.Where(temp => temp.MemberNames.Contains(propertyName))
                    .Select(temp => temp.ErrorMessage)
                    .FirstOrDefault();
            }
        }

        public IEnumerator<ValidationResult> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _results.Select(temp => temp.ErrorMessage));
        }
    }
}