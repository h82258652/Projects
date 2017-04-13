using GalaSoft.MvvmLight;
using SoftwareKobo.DataAnnotations;

namespace SoftwareKobo.Models
{
    public class VerifiableObservableObject : ObservableObject, IVerifiable
    {
        private ValidationResultCollection _errors;

        public ValidationResultCollection Errors
        {
            get
            {
                if (_errors == null)
                {
                    _errors = new ValidationResultCollection(this);
                    base.RaisePropertyChanged(nameof(Errors));
                    base.RaisePropertyChanged(nameof(IsValid));
                }
                return _errors;
            }
        }

        public bool IsValid => Errors.Count <= 0;

        public override void RaisePropertyChanged(string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
            _errors = null;
            base.RaisePropertyChanged(nameof(Errors));
            base.RaisePropertyChanged(nameof(IsValid));
        }
    }
}